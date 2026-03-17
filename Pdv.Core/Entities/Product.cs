using Pdv.Core.Exceptions;

namespace Pdv.Core.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public decimal Price { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        private Product() { }
        public Product(string name, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }
        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Nome do produto é obrigatório.");

            Name = name;
        }
        public void UpdatePrice(decimal price)
        {
            if (price <= 0)
                throw new DomainException("Preço do produto deve ser maior que zero.");
            Price = price;
        }
        public void Deactivate()
        {
            IsActive = false;
        }
        public void Activate()
        {
            IsActive = true;
        }
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new DomainException("Nome do produto é obrigatório.");
            if (Price <= 0)
                throw new DomainException("Preço do produto deve ser maior que zero.");
        }
    }
}
