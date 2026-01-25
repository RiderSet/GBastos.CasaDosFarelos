using CasaDosFarelos.IntegrationTests.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CasaDosFarelos.IntegrationTests.Infrastructure;

public class ApiFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddAuthentication("Test")
                .AddScheme<AuthenticationSchemeOptions, FakeAuthHandler>(
                    "Test", _ => { });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Gerente",
                    policy => policy.RequireAssertion(_ => true));
            });
        });
    }
}