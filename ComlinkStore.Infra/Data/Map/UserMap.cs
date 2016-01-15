using ComlinkStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ComlinkStore.Infra.Data.Map
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");

            HasKey(x => x.Id);
            Property(x => x.Username).HasMaxLength(20).IsRequired();
            Property(x => x.Password).HasMaxLength(20).IsRequired();
        }
    }
}
