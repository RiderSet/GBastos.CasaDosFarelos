using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using CasaDosFarelos.Infrastructure.Persistence.Context;

namespace CasaDosFarelos.Infrastructure.Persistence;

public class AppDbContextFactory
    : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=KILLWANGY;Database=CasaDosFarelos;Trusted_Connection=True;TrustServerCertificate=True");

        return new AppDbContext(optionsBuilder.Options);
    }
}