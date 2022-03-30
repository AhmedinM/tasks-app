using BusinessLayer.Services.Lists;
using Core.DTOs.Lists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ListController : BaseApiController
    {
        private readonly IListService _listService;
        public ListController(IListService listService)
        {
            _listService = listService;
        }

        [Authorize(Roles = "User")]
        [HttpGet("one/{listId}")]
        public async Task<ActionResult<GetListDto>> GetList(int listId)
        {
            var result = await _listService.GetList(listId);

            return (result == null) ?
                NotFound() :
                Ok(result);
        }

        [Authorize(Roles = "User")]
        [HttpGet("all/{userId}")]
        public async Task<ActionResult<List<GetListDto>>> GetLists(int userId)
        {
            var result = await _listService.GetLists(userId);

            return (result == null) ?
                NotFound() :
                Ok(result);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<ActionResult<GetListDto>> CreateList(CreateListDto createListDto)
        {
            var result = await _listService.CreateList(createListDto);

            return (result == null) ?
                NotFound() :
                Ok(result);
        }

        [Authorize(Roles = "User")]
        [HttpPut("{listId}")]
        public async Task<ActionResult> UpdateList(int listId, UpdateListDto updateListDto)
        {
            if (listId != updateListDto.Id) return BadRequest("IDs are not the same");

            var result = await _listService.UpdateList(updateListDto);
            
            return (result == null) ?
                NotFound() :
                Ok(result);
        }

        [Authorize(Roles = "User")]
        [HttpDelete("{listId}")]
        public async Task<ActionResult> DeleteList(int listId)
        {
            await _listService.DeleteList(listId);
            
            return NoContent();
        }
    }
}