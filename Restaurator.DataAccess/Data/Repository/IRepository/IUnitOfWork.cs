using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurator.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationUserRepository ApplicationUser { get;}
        void Save();
    }
}
