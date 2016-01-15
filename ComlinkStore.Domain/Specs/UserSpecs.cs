using ComlinkStore.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace ComlinkStore.Domain.Specs
{
    public static class UserSpecs
    {
        public static Expression<Func<User, bool>> GetByUsername(string username)
        {
            return x => x.Username == username;
        }
    }
}
