using CasaDosFarelos.Api.Endpoints;
using CasaDosFarelos.Api.Helpers;
using CasaDosFarelos.Application.Interfaces.Cliente;
using CasaDosFarelos.Application.Interfaces.Cliente.PJ;
using CasaDosFarelos.Application.Interfaces.Fornecedores;
using CasaDosFarelos.Infrastructure.Persistence.Context;
using CasaDosFarelos.Infrastructure.Repositories;
using CasaDosFarelos.Infrastructure.Repositories.Clientes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Reflection;
using System.Security.Claims;
using System.Text.Encodings.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn"));
});

builder.Services.AddScoped<IDbConnection>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConn");
    return new SqlConnection(connectionString);
});

// Produtos
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

// Fornecedores
builder.Services.AddScoped<IFornecedorReadRepository, FornecedorReadRepository>();
builder.Services.AddScoped<IFornecedorWriteRepository, FornecedorWriteRepository>();

// Clientes PF/PJ
builder.Services.AddScoped<IClienteWritePFRepository, ClienteWritePFRepository>();
builder.Services.AddScoped<IClienteWritePJRepository, ClienteWritePJRepository>();
builder.Services.AddScoped<IClienteReadRepository, ClienteReadRepository>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

builder.Services.AddAuthentication("FakeScheme")
    .AddScheme<AuthenticationSchemeOptions, FakeAuthHandler>("FakeScheme", options => { });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Gerente", policy =>
        policy.RequireRole("Gerente"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CasaDosFarelos API", Version = "v1" });

    // Configuração JWT para Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT no formato: Bearer {seu_token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapApplicationEndpoints();

var token = TokenGenerator.GerarTokenGerente();
Console.WriteLine(token);

app.Run();

Console.WriteLine(TokenGenerator.GerarTokenGerente());

public class FakeAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public FakeAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
                           ILoggerFactory logger,
                           UrlEncoder encoder,
                           ISystemClock clock)
        : base(options, logger, encoder, clock) { }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "DevUser"),
            new Claim(ClaimTypes.Role, "Gerente") // Vai passar na política "Gerente"
        };
        var identity = new ClaimsIdentity(claims, "Fake");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, "Fake");

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}

public partial class Program { }