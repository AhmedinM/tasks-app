using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Lists;
using Core.Entities;
using EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repositories.Lists
{
    public class ListRepository : IListRepository
    {
        private readonly DataContext _context;
        public ListRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List> CreateList(List list)
        {
            await _context.Lists.AddAsync(list);
            await _context.SaveChangesAsync();

            return list;
        }

        public async System.Threading.Tasks.Task DeleteList(int listId)
        {
            var list = await GetList(listId);

            _context.Lists.Remove(list);

            await _context.SaveChangesAsync();
        }

        public async Task<List> GetList(int listId)
        {
            return await _context.Lists.SingleOrDefaultAsync(l => l.Id == listId);
        }

        public Task<List<List>> GetLists(int userId)
        {
            return _context.Lists.Where(l => l.UserId == userId).OrderByDescending(l => l.CreatedAt).ToListAsync();
        }

        public async Task<List> UpdateList(List list)
        {
            _context.Lists.Update(list);
            await _context.SaveChangesAsync();
            
            return await GetList(list.Id);
        }
    }
}