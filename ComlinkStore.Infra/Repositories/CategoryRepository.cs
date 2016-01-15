using ComlinkStore.Domain.Entities;
using ComlinkStore.Domain.Repositories;
using ComlinkStore.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace ComlinkStore.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ComlinkStoreDataContext _context;

        public CategoryRepository(ComlinkStoreDataContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            _context.Categories.Remove(_context.Categories.Find(id));
        }

        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void Save(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Update(Category category)
        {
            _context.Entry<Category>(category).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
