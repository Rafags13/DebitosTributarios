using DebitosTributarios.WebApi.Endpoints;

namespace DebitosTributarios.WebApi.Extensions
{
    public static class MapEndpointExtensions
    {
        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder endpoint)
        {
            return endpoint
                .MapContribuinteEndpoints()
                .MapDebitoEndpoints();
        }
    }
}
