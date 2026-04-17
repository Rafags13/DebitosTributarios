using Microsoft.AspNetCore.Http;

namespace DebitosTributarios.Domain.Errors.Common
{
    public record DatabaseError()
        : BaseError("Ocorreu algum erro inesperado ao realizar a operação. Por favor, tente novamente mais tarde.", nameof(DatabaseError), StatusCodes.Status500InternalServerError);
}
