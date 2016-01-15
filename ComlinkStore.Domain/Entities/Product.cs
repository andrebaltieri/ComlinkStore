using System;

namespace ComlinkStore.Domain.Entities
{
    public class Product
    {
        protected Product() { }
        public Product(string name, decimal price, int quantityOnHand, Category category)
        {
            Name = name;
            Price = price;
            QuantityOnHand = quantityOnHand;
            Category = category;

            Register();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int QuantityOnHand { get; private set; }

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public void Register()
        {
            if (Name.Length <= 3)
                throw new Exception("Nome inválido");

            if (Price <= 0)
                throw new Exception("Preço inválido");

            if (QuantityOnHand < 0)
                throw new Exception("Quantidade Inválida");
        }

        public void UpdateInventory(int quantity)
        {
            if (quantity <= 0)
                throw new Exception("Quantidade Inválida");

            if (quantity > QuantityOnHand)
                throw new Exception("A quantidade solicitada ultrapassa a quantidade em estoque. Quantidade disponível: " + QuantityOnHand);
        }
    }
}
