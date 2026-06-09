using FluentAssertions;
using Pdv.Core.Entities;
using Pdv.Core.Exceptions;

namespace Pdv.UnitTests.Core.Entities
{
    public class ProductTests
    {
        [Fact]
        public void Deve_criar_produto_valido()
        {
            var product = new Product("TEC-001", "Teclado", 150, true, 10);

            product.Sku.Should().Be("TEC-001");
            product.Name.Should().Be("Teclado");
            product.Price.Should().Be(150);
            product.ControlsStock.Should().BeTrue();
            product.CurrentStock.Should().Be(10);
            product.IsActive.Should().BeTrue();
        }

        [Fact]
        public void Nao_deve_criar_produto_com_sku_vazio()
        {
            Action act = () => new Product("", "Teclado", 150, true, 10);

            act.Should().Throw<DomainException>()
                .WithMessage("SKU do produto é obrigatório.");
        }

        [Fact]
        public void Nao_deve_criar_produto_com_nome_vazio()
        {
            Action act = () => new Product("TEC-001", "", 150, true, 10);

            act.Should().Throw<DomainException>()
                .WithMessage("Nome do produto é obrigatório.");
        }

        [Fact]
        public void Nao_deve_criar_produto_com_preco_invalido()
        {
            Action act = () => new Product("MOU-001", "Mouse", 0, true, 10);

            act.Should().Throw<DomainException>()
                .WithMessage("Preço do produto deve ser maior que zero.");
        }

        [Fact]
        public void Nao_deve_criar_produto_com_preco_negativo()
        {
            Action act = () => new Product("MOU-001", "Mouse", -10, true, 10);

            act.Should().Throw<DomainException>()
                .WithMessage("Preço do produto deve ser maior que zero.");
        }

        [Fact]
        public void Nao_deve_criar_produto_com_estoque_negativo()
        {
            Action act = () => new Product("MOU-001", "Mouse", 10, true, -1);

            act.Should().Throw<DomainException>()
                .WithMessage("Estoque do produto não pode ser negativo.");
        }

        [Fact]
        public void Deve_desativar_produto()
        {
            var product = new Product("TEC-001", "Teclado", 150, true, 10);

            product.Deactivate();

            product.IsActive.Should().BeFalse();
        }

        [Fact]
        public void Deve_ativar_produto()
        {
            var product = new Product("TEC-001", "Teclado", 150, true, 10);
            product.Deactivate();

            product.Activate();

            product.IsActive.Should().BeTrue();
        }

        [Fact]
        public void Deve_ativar_controle_de_estoque()
        {
            var product = new Product("SER-001", "Servico", 150, false, 0);

            product.ActivateStockControl();

            product.ControlsStock.Should().BeTrue();
        }

        [Fact]
        public void Deve_desativar_controle_de_estoque()
        {
            var product = new Product("TEC-001", "Teclado", 150, true, 10);

            product.DeactivateStockControl();

            product.ControlsStock.Should().BeFalse();
        }
    }
}
