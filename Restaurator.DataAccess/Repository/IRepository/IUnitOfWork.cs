using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurator.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
