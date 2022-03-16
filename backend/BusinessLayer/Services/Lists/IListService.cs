using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Lists;

namespace BusinessLayer.Services.Lists
{
    public interface IListService
    {
        Task<GetListDto> GetList(int listId);
        Task<List<GetListDto>> GetLists(int userId);
        Task<GetListDto> CreateList(CreateListDto createListDto);
        Task<GetListDto> UpdateList(UpdateListDto updateListDto);
        Task DeleteList(int listId);
    }
}