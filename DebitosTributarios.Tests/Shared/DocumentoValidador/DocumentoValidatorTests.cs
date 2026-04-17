using FluentAssertions;
using DebitosTributarios.Domain.Helpers;

namespace DebitosTributarios.Tests.Shared.DocumentoValidador
{
    public class DocumentoValidadorTests
    {
        [Theory(DisplayName = "Deve validar CPFs válidos")]
        [InlineData("52998224725")]
        [InlineData("529.982.247-25")]
        public void Deve_validar_cpfs_validos(string cpf)
        {
            // Act
            var resultado = ValidateCpfCnpjHelper.ValidarCpf(cpf);

            // Assert
            resultado.Should().BeTrue();
        }

        [Theory(DisplayName = "Deve invalidar CPFs com dígito verificador incorreto")]
        [InlineData("52998224724")]
        [InlineData("529.982.247-24")]
        public void Deve_invalidar_cpfs_com_digito_incorreto(string cpf)
        {
            // Act
            var resultado = ValidateCpfCnpjHelper.ValidarCpf(cpf);

            // Assert
            resultado.Should().BeFalse();
        }

        [Theory(DisplayName = "Deve invalidar CPFs com tamanho incorreto")]
        [InlineData("123")]
        [InlineData("1234567890")]
        [InlineData("123456789000")]
        public void Deve_invalidar_cpfs_tamanho_invalido(string cpf)
        {
            // Act
            var resultado = ValidateCpfCnpjHelper.ValidarCpf(cpf);

            // Assert
            resultado.Should().BeFalse();
        }

        [Theory(DisplayName = "Deve invalidar CPFs com sequência repetida")]
        [InlineData("11111111111")]
        [InlineData("00000000000")]
        public void Deve_invalidar_cpfs_repetidos(string cpf)
        {
            // Act
            var resultado = ValidateCpfCnpjHelper.ValidarCpf(cpf);

            // Assert
            resultado.Should().BeFalse();
        }

        [Theory(DisplayName = "Deve invalidar CPFs nulos ou vazios")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Deve_invalidar_cpfs_nulos_ou_vazios(string cpf)
        {
            // Act
            var resultado = ValidateCpfCnpjHelper.ValidarCpf(cpf);

            // Assert
            resultado.Should().BeFalse();
        }

        [Theory(DisplayName = "Deve validar CNPJs válidos")]
        [InlineData("04252011000110")]
        [InlineData("04.252.011/0001-10")]
        public void Deve_validar_cnpjs_validos(string cnpj)
        {
            // Act
            var resultado = ValidateCpfCnpjHelper.ValidarCnpj(cnpj);

            // Assert
            resultado.Should().BeTrue();
        }

        [Theory(DisplayName = "Deve invalidar CNPJs com dígito verificador incorreto")]
        [InlineData("04252011000111")]
        [InlineData("04.252.011/0001-11")]
        public void Deve_invalidar_cnpjs_com_digito_incorreto(string cnpj)
        {
            // Act
            var resultado = ValidateCpfCnpjHelper.ValidarCnpj(cnpj);

            // Assert
            resultado.Should().BeFalse();
        }

        [Theory(DisplayName = "Deve invalidar CNPJs com tamanho incorreto")]
        [InlineData("123")]
        [InlineData("1234567890123")]
        [InlineData("123456789012345")]
        public void Deve_invalidar_cnpjs_tamanho_invalido(string cnpj)
        {
            // Act
            var resultado = ValidateCpfCnpjHelper.ValidarCnpj(cnpj);

            // Assert
            resultado.Should().BeFalse();
        }

        [Theory(DisplayName = "Deve invalidar CNPJs com sequência repetida")]
        [InlineData("11111111111111")]
        [InlineData("00000000000000")]
        public void Deve_invalidar_cnpjs_repetidos(string cnpj)
        {
            // Act
            var resultado = ValidateCpfCnpjHelper.ValidarCnpj(cnpj);

            // Assert
            resultado.Should().BeFalse();
        }

        [Theory(DisplayName = "Deve invalidar CNPJs nulos ou vazios")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Deve_invalidar_cnpjs_nulos_ou_vazios(string cnpj)
        {
            // Act
            var resultado = ValidateCpfCnpjHelper.ValidarCnpj(cnpj);

            // Assert
            resultado.Should().BeFalse();
        }
    }
}
