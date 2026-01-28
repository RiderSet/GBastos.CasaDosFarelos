using CasaDosFarelos.Api.Endpoints;
using CasaDosFarelos.Application.Commands.ClientesCommand.CriarClientePJ;
using CasaDosFarelos.Application.Commands.FornecedorCommand.AtualizarFornecedor;
using CasaDosFarelos.Application.Commands.RelatoriosCommand;
using CasaDosFarelos.Application.Commands.Vendas;
using CasaDosFarelos.Application.Interfaces.Cliente.PF;
using CasaDosFarelos.Application.Interfaces.Fornecedores;
using CasaDosFarelos.Application.Interfaces.Venda;
using CasaDosFarelos.Application.Validators;
using CasaDosFarelos.Domain.Interfaces;
using CasaDosFarelos.Infrastructure.Persistence.Context;
using CasaDosFarelos.Infrastructure.Persistence.UnitOfWork;
using CasaDosFarelos.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CasaDosFarelos API",
        Version = "v1"
    });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header usando Bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, Array.Empty<string>() }
    });
});

// -----------------------------
// Auth
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            JwtConfig.TokenValidationParameters(builder.Configuration);
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Gerente", policy =>
        policy.RequireRole("Gerente"));
});

// -----------------------------
// FluentValidation + MediatR
builder.Services.AddValidatorsFromAssemblyContaining<
    AtualizarFornecedorPFCommandValidator>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(AtualizarFornecedorCommandPF).Assembly,
    typeof(CriarVendaCommand).Assembly,
    typeof(ListarClientesQuery).Assembly,
    typeof(CriarClientePJCommand).Assembly
));

// Pipeline de validação automática
builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>)
);

// -----------------------------
// Infra
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConn")));

builder.Services.AddTransient<IDbConnection>(_ =>
    new SqlConnection(
        builder.Configuration.GetConnectionString("DefaultConn")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddScoped<IClienteReadPFRepository, ClienteReadRepository>();
builder.Services.AddScoped<IRelatorioVendasHandler, RelatorioVendasHandler>();
builder.Services.AddScoped<IFornecedorReadRepository, FornecedorReadRepository>();
builder.Services.AddScoped<IFornecedorWriteRepository, FornecedorWriteRepository>();

// -----------------------------
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapApplicationEndpoints();

app.Run();

public partial class Program { }