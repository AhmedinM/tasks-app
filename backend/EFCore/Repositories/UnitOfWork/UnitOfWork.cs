using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using EFCore.Context;
using EFCore.Repositories.Accounts;
using EFCore.Repositories.Lists;
using EFCore.Repositories.Tasks;
using EFCore.Repositories.Users;
using Microsoft.AspNetCore.Identity;

namespace EFCore.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        public UnitOfWork(DataContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IAccountRepository AccountRepository => new AccountRepository(_context, UserRepository,  _userManager);

        public IListRepository ListRepository => new ListRepository(_context);

        public ITaskRepository TaskRepository => new TaskRepository(_context);

        public IUserRepository UserRepository => new UserRepository(_context);

        // public async Task<bool> Complete()
        // {
        //     return await _context.SaveChangesAsync() > 0;
        // }

        // public bool HasChanges()
        // {
        //     return _context.ChangeTracker.HasChanges();
        // }
    }
}