using System;
using System.Collections.Generic;

namespace ComlinkStore.Domain.Entities
{
    public class Category
    {
        protected Category() { }
        public Category(string name)
        {
            if (name.Length <= 0)
                throw new Exception("Nome inválido");

            Name = name;
            Products = new List<Product>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        public void ChangeName(string name)
        {
            Name = name;
        }
    }
}
