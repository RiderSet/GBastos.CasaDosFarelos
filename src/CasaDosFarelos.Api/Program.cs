using CasaDosFarelos.Api.Endpoints;
using CasaDosFarelos.Application.Interfaces.Cliente;
using CasaDosFarelos.Application.Interfaces.Cliente.PJ;
using CasaDosFarelos.Application.Interfaces.Fornecedores;
using CasaDosFarelos.Infrastructure.Persistence.Context;
using CasaDosFarelos.Infrastructure.Repositories;
using CasaDosFarelos.Infrastructure.Repositories.Clientes;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// ===============================
// Configuração do DbContext
// ===============================
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn"));
});

builder.Services.AddScoped<IDbConnection>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConn");
    return new SqlConnection(connectionString);
});

// ===============================
// Registro dos Repositórios
// ===============================

// Produtos
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

// Fornecedores
builder.Services.AddScoped<IFornecedorReadRepository, FornecedorReadRepository>();
builder.Services.AddScoped<IFornecedorWriteRepository, FornecedorWriteRepository>();

// Clientes PF/PJ
builder.Services.AddScoped<IClienteWritePFRepository, ClienteWritePFRepository>();
builder.Services.AddScoped<IClienteWritePJRepository, ClienteWritePJRepository>();
builder.Services.AddScoped<IClienteReadRepository, ClienteReadRepository>();

// ===============================
// Registro do MediatR
// ===============================
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

// ===============================
// Adicionando Minimal API services
// ===============================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ===============================
// Configuração Swagger
// ===============================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapApplicationEndpoints();

app.Run();

public partial class Program { }