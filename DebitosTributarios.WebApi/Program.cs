using DebitosTributarios.Application.Extensions.UseCases;
using DebitosTributarios.Infrastructure.Extensions;
using DebitosTributarios.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplicationUseCases()
    .ConfigureInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DisplayRequestDuration();
    });
}

app.Services.ConfigureMigrations();

app.MapEndpoints();

app.Run();