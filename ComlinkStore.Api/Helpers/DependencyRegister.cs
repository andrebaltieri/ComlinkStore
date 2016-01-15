using ComlinkStore.Domain.Repositories;
using ComlinkStore.Infra.Data;
using ComlinkStore.Infra.Repositories;
using Microsoft.Practices.Unity;

namespace ComlinkStore.Api.Helpers
{
    public static class DependencyRegister
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<ComlinkStoreDataContext, ComlinkStoreDataContext>
                (new HierarchicalLifetimeManager());

            container.RegisterType<IUserRepository, UserRepository>
                (new HierarchicalLifetimeManager());
            container.RegisterType<IProductRepository, ProductRepository>
                (new HierarchicalLifetimeManager());
        }
    }
}