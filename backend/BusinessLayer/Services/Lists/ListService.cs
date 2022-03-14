using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Lists;
using Core.Entities;
using EFCore.Repositories.Lists;

namespace BusinessLayer.Services.Lists
{
    public class ListService : IListService
    {
        private readonly IListRepository _listRepository;
        private readonly IMapper _mapper;
        public ListService(IListRepository listRepository, IMapper mapper)
        {
            _mapper = mapper;
            _listRepository = listRepository;
        }

        public async Task<GetListDto> CreateList(CreateListDto createListDto)
        {   
            return _mapper.Map<GetListDto>(await _listRepository.CreateList(_mapper.Map<List>(createListDto)));
        }

        public async System.Threading.Tasks.Task DeleteList(int listId)
        {
            await _listRepository.DeleteList(listId);
        }

        public async Task<List<GetListDto>> GetLists(int userId)
        {
            return _mapper.Map<List<GetListDto>>(await _listRepository.GetLists(userId));
        }

        public async Task<GetListDto> UpdateList(UpdateListDto updateListDto)
        {
            return _mapper.Map<GetListDto>(await _listRepository.UpdateList(_mapper.Map<UpdateListDto, List>(updateListDto, await _listRepository.GetList(updateListDto.Id))));
        }
    }
}