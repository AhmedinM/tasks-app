using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services.Lists;
using Core.DTOs.Lists;
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

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<GetListDto>>> GetLists(int userId)
        {
            var result = await _listService.GetLists(userId);

            return (result == null) ?
                NotFound() :
                Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GetListDto>> CreateList(CreateListDto createListDto)
        {
            var result = await _listService.CreateList(createListDto);

            return (result == null) ?
                NotFound() :
                Ok(result);
        }

        [HttpPut("{listId}")]
        public async Task<ActionResult> UpdateList(int listId, UpdateListDto updateListDto)
        {
            if (listId != updateListDto.Id) return BadRequest("IDs are not the same");

            var result = await _listService.UpdateList(updateListDto);
            
            return (result == null) ?
                NotFound() :
                Ok(result);
        }

        [HttpDelete("{listId}")]
        public async Task<ActionResult> DeleteList(int listId)
        {
            await _listService.DeleteList(listId);
            
            return NoContent();
        }
    }
}