using Fermat.EntityFramework.ExceptionLogs.Domain.Entities;
using Fermat.EntityFramework.ExceptionLogs.Domain.Interfaces.Repositories;
using Fermat.EntityFramework.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fermat.EntityFramework.ExceptionLogs.Infrastructure.Repositories;

public class ExceptionLogRepository<TContext> : EfRepositoryBase<ExceptionLog, Guid, TContext>, IExceptionLogRepository where TContext : DbContext
{
    public ExceptionLogRepository(TContext context) : base(context)
    {
    }
}