using Fermat.EntityFramework.ExceptionLogs.Domain.Entities;
using Fermat.EntityFramework.Shared.Interfaces;

namespace Fermat.EntityFramework.ExceptionLogs.Domain.Interfaces.Repositories;

public interface IExceptionLogRepository : IRepository<ExceptionLog, Guid>
{

}