using Pdv.Core.Exceptions;

namespace Pdv.Core.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Sku { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public bool ControlsStock { get; private set; }
        public decimal CurrentStock { get; private set; }
        public decimal Price { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Product() { }

        public Product(string sku, string name, decimal price, bool controlsStock, decimal currentStock)
        {
            Id = Guid.NewGuid();
            Sku = sku;
            Name = name;
            ControlsStock = controlsStock;
            CurrentStock = currentStock;
            Price = price;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;

            Validate();
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

        public void ActivateStockControl()
        {
            ControlsStock = true;
        }

        public void DeactivateStockControl()
        {
            ControlsStock = false;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Sku))
                throw new DomainException("SKU do produto é obrigatório.");

            if (string.IsNullOrWhiteSpace(Name))
                throw new DomainException("Nome do produto é obrigatório.");

            if (Price <= 0)
                throw new DomainException("Preço do produto deve ser maior que zero.");

            if (CurrentStock < 0)
                throw new DomainException("Estoque do produto não pode ser negativo.");
        }
    }
}
