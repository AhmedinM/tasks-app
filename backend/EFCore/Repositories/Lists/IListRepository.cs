using Core.Entities;

namespace EFCore.Repositories.Lists
{
    public interface IListRepository
    {
        Task<List<List>> GetLists(int userId);
        Task<List> CreateList(List list);
        Task<List> UpdateList(List list);
        System.Threading.Tasks.Task DeleteList(int listId);
        Task<List> GetList(int listId);
    }
}