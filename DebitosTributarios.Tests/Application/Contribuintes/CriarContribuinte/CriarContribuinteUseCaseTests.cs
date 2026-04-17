using DebitosTributarios.Domain.Errors.Common;
using DebitosTributarios.Domain.Errors.Contribuinte;
using FluentAssertions;

namespace DebitosTributarios.Tests.Application.Contribuintes.CriarContribuinte
{
    public class CriarContribuinteUseCaseTests
    {
        [Fact(DisplayName = "Deve retornar erro quando CPF/CNPJ não for informado")]
        public async Task Deve_retornar_erro_quando_CpfCnpj_for_nulo()
        {
            // Arrange
            var request = CriarContribuinteUseCaseTestData.SemCpf();

            var useCase = new CriarContribuinteUseCaseBuilder()
                .Build();

            // Act
            var result = await useCase.CriarAsync(request);

            // Assert
            result.IsT1.Should().BeTrue();
            result.AsT1.Should().BeOfType<CpfCnpjEhObrigatorioError>();
        }

        [Fact(DisplayName = "Deve retornar erro quando nome não for informado")]
        public async Task Deve_retornar_erro_quando_Nome_for_nulo()
        {
            // Arrange
            var request = CriarContribuinteUseCaseTestData.SemNome();

            var useCase = new CriarContribuinteUseCaseBuilder()
                .Build();

            // Act
            var result = await useCase.CriarAsync(request);

            // Assert
            result.IsT1.Should().BeTrue();
            result.AsT1.Should().BeOfType<NomeEhObrigatorioError>();
        }

        [Fact(DisplayName = "Deve retornar erro quando CPF/CNPJ já estiver cadastrado")]
        public async Task Deve_retornar_erro_quando_Cpf_ja_cadastrado()
        {
            // Arrange
            var request = CriarContribuinteUseCaseTestData.RequestValido();

            var useCase = new CriarContribuinteUseCaseBuilder()
                .ComCpfJaCadastrado(true)
                .Build();

            // Act
            var result = await useCase.CriarAsync(request);

            // Assert
            result.IsT1.Should().BeTrue();
            result.AsT1.Should().BeOfType<CpfCnpjJaCadastradoError>();
        }

        [Fact(DisplayName = "Deve retornar erro de banco quando falha ao persistir contribuinte")]
        public async Task Deve_retornar_erro_quando_falha_no_banco()
        {
            // Arrange
            var request = CriarContribuinteUseCaseTestData.RequestValido();

            var useCase = new CriarContribuinteUseCaseBuilder()
                .ComCpfJaCadastrado(false)
                .ComCriacaoSucesso(false)
                .Build();

            // Act
            var result = await useCase.CriarAsync(request);

            // Assert
            result.IsT1.Should().BeTrue();
            result.AsT1.Should().BeOfType<DatabaseError>();
        }

        [Fact(DisplayName = "Deve criar contribuinte com sucesso quando dados são válidos")]
        public async Task Deve_criar_contribuinte_com_sucesso()
        {
            // Arrange
            var request = CriarContribuinteUseCaseTestData.RequestValido();

            var useCase = new CriarContribuinteUseCaseBuilder()
                .ComCpfJaCadastrado(false)
                .ComCriacaoSucesso(true)
                .Build();

            // Act
            var result = await useCase.CriarAsync(request);

            // Assert
            result.IsT0.Should().BeTrue();
            result.AsT0.Should().BeTrue();
        }
    }
}
