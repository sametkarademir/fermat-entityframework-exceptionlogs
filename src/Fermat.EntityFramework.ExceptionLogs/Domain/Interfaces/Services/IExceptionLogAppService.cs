using Fermat.EntityFramework.ExceptionLogs.Application.DTOs.ExceptionLogs;
using Fermat.EntityFramework.Shared.DTOs.Pagination;

namespace Fermat.EntityFramework.ExceptionLogs.Domain.Interfaces.Services;

public interface IExceptionLogAppService
{
    Task<ExceptionLogResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<PageableResponseDto<ExceptionLogResponseDto>> GetPageableAndFilterAsync(GetListExceptionLogRequestDto request, CancellationToken cancellationToken = default);
    Task<int> CleanupOldExceptionLogsAsync(DateTime olderThan, CancellationToken cancellationToken = default);

}