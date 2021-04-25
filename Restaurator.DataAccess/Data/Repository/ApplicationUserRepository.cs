using Restaurator.DataAccess.Data.Repository.IRepository;
using Restaurator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurator.DataAccess.Data.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
