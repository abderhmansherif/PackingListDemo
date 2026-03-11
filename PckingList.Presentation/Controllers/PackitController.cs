using Microsoft.AspNetCore.Mvc;
using PackingList.Application.Abstractions.Commands;
using PackingList.Application.Abstractions.Queries;
using PackingList.Application.Commands;
using PackingList.Application.DTO;
using PackingList.Application.Queries;
using PackingList.Domain.ValueObjects;

namespace PckingList.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackitController: ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public PackitController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;

        }

        [HttpGet]
        [Route("{PackingListId:guid}")]
        public async Task<ActionResult<PackingListDTO>> Get([FromRoute] GetPackingListQuery getPackingListQuery)
        {
            var packingList = await _queryDispatcher.DispatchAsync<GetPackingListQuery, PackingListDTO>(getPackingListQuery);

            if(packingList is null)
            {
                return NotFound();
            }

            return Ok(packingList);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackingListDTO>>> Get([FromQuery] SearchPackingListsQuery searchPackingListsQuery)
        {
            var packingLists = await _queryDispatcher
                    .DispatchAsync<SearchPackingListsQuery, IEnumerable<PackingListDTO>>(searchPackingListsQuery);

            return Ok(packingLists);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePackingListWithItems createPackingListWithItems)
        {
            await _commandDispatcher.DispatchAsync(createPackingListWithItems);
            return CreatedAtAction(nameof(Get), new { PackingListId = createPackingListWithItems.id }, null);
        }

        [HttpPut]
        [Route("{PackingListId:guid}/Items")]
        public async Task<IActionResult> Put([FromBody] AddPackingListItemCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }

        [HttpPut]
        [Route("{PackingListId}/Items/{ItemName}/Pack")]
        public async Task<IActionResult> Put([FromRoute] PackItemCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpDelete]
        [Route("{PackingListId:guid}")]
        public async Task<IActionResult> Delete([FromRoute] RemovePackingListCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpDelete]
        [Route("{PackingListId:guid}/Items/{ItemName}")]
        public async Task<IActionResult> Delete([FromRoute] RemovePackingListItemCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }
    }
}
