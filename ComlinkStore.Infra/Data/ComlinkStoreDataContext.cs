using ComlinkStore.Domain.Entities;
using ComlinkStore.Infra.Data.Map;
using System.Data.Entity;

namespace ComlinkStore.Infra.Data
{
    public class ComlinkStoreDataContext : DbContext
    {
        public ComlinkStoreDataContext() : base("CnnStr")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
        }
    }
}
