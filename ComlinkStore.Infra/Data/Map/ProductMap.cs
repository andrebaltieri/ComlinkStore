using ComlinkStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ComlinkStore.Infra.Data.Map
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");

            HasKey(x => x.Id);

            Property(x => x.Name).HasMaxLength(80).IsRequired();
            Property(x => x.Price).HasColumnType("money");

            HasRequired(x => x.Category).WithMany(x => x.Products);

        }
    }
}
