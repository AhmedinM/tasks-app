using AutoMapper;
using Core.DTOs.Lists;
using Core.Entities;
using EFCore.Repositories.Lists;
using EFCore.Repositories.UnitOfWork;

namespace BusinessLayer.Services.Lists
{
    public class ListService : IListService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ListService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetListDto> CreateList(CreateListDto createListDto)
        {   
            return _mapper.Map<GetListDto>(await _unitOfWork.ListRepository.CreateList(_mapper.Map<List>(createListDto)));
        }

        public async System.Threading.Tasks.Task DeleteList(int listId)
        {
            await _unitOfWork.ListRepository.DeleteList(listId);
        }

        public async Task<GetListDto> GetList(int listId)
        {
            return _mapper.Map<GetListDto>(await _unitOfWork.ListRepository.GetList(listId));
        }

        public async Task<List<GetListDto>> GetLists(int userId)
        {
            return _mapper.Map<List<GetListDto>>(await _unitOfWork.ListRepository.GetLists(userId));
        }

        public async Task<GetListDto> UpdateList(UpdateListDto updateListDto)
        {
            return _mapper.Map<GetListDto>(await _unitOfWork.ListRepository.UpdateList(_mapper.Map<UpdateListDto, List>(updateListDto, await _unitOfWork.ListRepository.GetList(updateListDto.Id))));
        }
    }
}