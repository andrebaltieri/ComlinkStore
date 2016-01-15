using System;
using ComlinkStore.Infra.Data;

namespace ComlinkStore.Infra.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private ComlinkStoreDataContext _context;

        public UnitOfWork(ComlinkStoreDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Não faz nada
        }
    }
}
