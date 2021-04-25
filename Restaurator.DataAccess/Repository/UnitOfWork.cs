using Restaurator.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurator.DataAccess.Repository
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
