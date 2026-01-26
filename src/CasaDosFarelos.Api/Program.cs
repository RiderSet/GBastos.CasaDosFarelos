using CasaDosFarelos.Api.Endpoints;
using CasaDosFarelos.Application.Commands.RelatoriosCommand;
using CasaDosFarelos.Application.Commands.Vendas;
using CasaDosFarelos.Application.Interfaces;
using CasaDosFarelos.Domain.Interfaces;
using CasaDosFarelos.Infrastructure.Persistence.Context;
using CasaDosFarelos.Infrastructure.Persistence.UnitOfWork;
using CasaDosFarelos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddScoped<IRelatorioVendasHandler, RelatorioVendasHandler>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapApplicationEndpoints();


app.Run();

public partial class Program { }