using DebitosTributarios.Domain.DTOs.Contribuinte.Request;

namespace DebitosTributarios.Tests.Application.Contribuintes.CriarContribuinte
{
    public static class CriarContribuinteUseCaseTestData
    {
        public static RequestCreateContribuinteDTO RequestValido()
            => new("João da Silva", "940.703.420-87");

        public static RequestCreateContribuinteDTO SemCpf()
            => new("João", string.Empty);

        public static RequestCreateContribuinteDTO SemNome()
            => new(string.Empty, "73.539.111/0001-44");
    }
}
