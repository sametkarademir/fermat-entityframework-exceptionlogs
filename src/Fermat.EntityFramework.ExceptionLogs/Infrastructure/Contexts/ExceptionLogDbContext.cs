using Fermat.EntityFramework.ExceptionLogs.Domain.Entities;
using Fermat.EntityFramework.ExceptionLogs.Infrastructure.EntityConfigurations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Fermat.EntityFramework.ExceptionLogs.Infrastructure.Contexts;

public class ExceptionLogDbContext : DbContext
{
    public DbSet<ExceptionLog> ExceptionLogs { get; set; }

    public ExceptionLogDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ExceptionLogConfiguration).Assembly);
    }
}