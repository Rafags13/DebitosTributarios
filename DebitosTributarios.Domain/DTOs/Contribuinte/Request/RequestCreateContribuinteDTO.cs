using DebitosTributarios.Domain.Annotations;
using System.Text.Json.Serialization;

namespace DebitosTributarios.Domain.DTOs.Contribuinte.Request
{
    public record RequestCreateContribuinteDTO(
        string Nome,
        [property: JsonConverter(typeof(OnlyNumbers))]
        string CpfCnpj);
}
