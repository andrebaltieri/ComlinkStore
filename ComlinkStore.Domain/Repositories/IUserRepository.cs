using ComlinkStore.Domain.Entities;

namespace ComlinkStore.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
    }
}
