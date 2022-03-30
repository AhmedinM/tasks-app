using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Repositories.Accounts;
using EFCore.Repositories.Lists;
using EFCore.Repositories.Tasks;
using EFCore.Repositories.Users;

namespace EFCore.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository {get;}
        IListRepository ListRepository {get;}
        ITaskRepository TaskRepository {get;}
        IUserRepository UserRepository {get;}
        // Task<bool> Complete();
        // bool HasChanges();
    }
}