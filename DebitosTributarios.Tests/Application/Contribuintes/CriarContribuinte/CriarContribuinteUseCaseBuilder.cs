using DebitosTributarios.Application.UseCases.Contribuinte.Commands;
using DebitosTributarios.Domain.DTOs.Contribuinte.Request;
using DebitosTributarios.Domain.Interfaces.Repository;
using DebitosTributarios.Domain.Interfaces.UoW;
using Moq;

namespace DebitosTributarios.Tests.Application.Contribuintes.CriarContribuinte
{
    public class CriarContribuinteUseCaseBuilder
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
        private readonly Mock<IContribuinteRepository> _repoMock = new();

        public CriarContribuinteUseCaseBuilder()
        {
            _unitOfWorkMock
                .Setup(x => x.ContribuinteRepository)
                .Returns(_repoMock.Object);
        }

        public CriarContribuinteUseCaseBuilder ComCpfJaCadastrado(bool valor)
        {
            _repoMock
                .Setup(x => x.CpfCnpjJaCadastrado(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(valor);

            return this;
        }

        public CriarContribuinteUseCaseBuilder ComCriacaoSucesso(bool valor)
        {
            _repoMock
                .Setup(x => x.CriarAsync(It.IsAny<RequestCreateContribuinteDTO>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(valor);

            return this;
        }

        public CriarContribuinteUseCase Build()
            => new(_unitOfWorkMock.Object);
    }
}
