using ComlinkStore.Domain.Entities;
using System.Collections.Generic;

namespace ComlinkStore.Domain.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category Get(int id);
        void Save(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
