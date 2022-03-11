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
            var list = _mapper.Map<List>(createListDto);
            var result = await _listRepository.CreateList(list);
            
            return _mapper.Map<GetListDto>(result);
        }

        public async System.Threading.Tasks.Task DeleteList(int listId)
        {
            await _listRepository.DeleteList(listId);
        }

        public async Task<List<GetListDto>> GetLists(int userId)
        {
            var lists = await _listRepository.GetLists(userId);

            return _mapper.Map<List<GetListDto>>(lists);
        }

        public async Task<GetListDto> UpdateList(UpdateListDto updateListDto)
        {
            var list = await _listRepository.GetList(updateListDto.Id);
            
            var listToUpdate = _mapper.Map<UpdateListDto, List>(updateListDto, list);

            var result = await _listRepository.UpdateList(list);

            return _mapper.Map<GetListDto>(result);
        }
    }
}