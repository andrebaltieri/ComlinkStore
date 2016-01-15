using ComlinkStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComlinkStore.Domain.Entities;
using ComlinkStore.Infra.Data;
using ComlinkStore.Domain.Specs;

namespace ComlinkStore.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ComlinkStoreDataContext _context;

        public UserRepository(ComlinkStoreDataContext context)
        {
            _context = context;
        }

        public User GetByUsername(string username)
        {
            return _context
                .Users
                .Where(UserSpecs.GetByUsername(username))
                .FirstOrDefault();
        }
    }
}
