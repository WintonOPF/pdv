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
            var product = new Product("Teclado", 150);

            product.Name.Should().Be("Teclado");
            product.Price.Should().Be(150);
            product.IsActive.Should().BeTrue();
        }
        [Fact]
        public void Nao_deve_criar_produto_com_nome_vazio()
        {
            Action act = () => new Product("", 150);
            act.Should().Throw<DomainException>()
                .WithMessage("Nome do produto é obrigatório.");
        }
        [Fact]
        public void Nao_deve_criar_produto_com_preco_invalido()
        {
            Action act = () => new Product("Mouse", 0);

            act.Should().Throw<DomainException>()
                .WithMessage("Preço deve ser maior que zero.");
        }
        [Fact]
        public void Nao_deve_criar_produto_com_preco_negativo()
        {
            Action act = () => new Product("Mouse", -10);

            act.Should().Throw<DomainException>()
                .WithMessage("Preço deve ser maior que zero.");
        }
    }
}
