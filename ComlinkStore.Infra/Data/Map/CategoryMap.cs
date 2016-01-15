using ComlinkStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ComlinkStore.Infra.Data.Map
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Category");

            HasKey(x => x.Id);
            Property(x => x.Name).HasMaxLength(60).IsRequired();
        }
    }
}
