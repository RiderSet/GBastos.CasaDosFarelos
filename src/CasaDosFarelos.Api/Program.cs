using CasaDosFarelos.Api.Endpoints;
using CasaDosFarelos.Application.Commands.RelatoriosCommand;
using CasaDosFarelos.Application.Commands.Vendas;
using CasaDosFarelos.Application.Interfaces;
using CasaDosFarelos.Domain.Interfaces;
using CasaDosFarelos.Infrastructure.Persistence.Context;
using CasaDosFarelos.Infrastructure.Persistence.UnitOfWork;
using CasaDosFarelos.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("Bearer")
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = JwtConfig.TokenValidationParameters(builder.Configuration);
});

builder.Services.AddAuthorization();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CriarVendaCommand).Assembly));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn")));

builder.Services.AddTransient<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConn")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddScoped<IRelatorioVendasHandler, RelatorioVendasHandler>();
builder.Services.AddScoped<IClienteReadRepository, ClienteReadRepository>();
builder.Services.AddScoped<IClienteWriteRepository, ClienteWriteRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ListarClientesQuery).Assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapApplicationEndpoints();

app.Run();

public partial class Program { }