using Fermat.EntityFramework.ExceptionLogs.Application.DTOs.ExceptionLogs;
using Fermat.EntityFramework.ExceptionLogs.Domain.Interfaces.Services;
using Fermat.EntityFramework.Shared.DTOs.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fermat.EntityFramework.ExceptionLogs.Presentation.Controllers;

[ApiController]
[Route("api/exception-logs")]
public class ExceptionLogController(
    IExceptionLogAppService exceptionLogAppService)
    : ControllerBase
{
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ExceptionLogResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await exceptionLogAppService.GetByIdAsync(id, cancellationToken);
        return Ok(result);
    }

    [HttpGet("pageable")]
    [ProducesResponseType(typeof(PageableResponseDto<ExceptionLogResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetPageableAndFilterAsync([FromQuery] GetListExceptionLogRequestDto request, CancellationToken cancellationToken = default)
    {
        var result = await exceptionLogAppService.GetPageableAndFilterAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("cleanup")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CleanupOldExceptionLogsAsync([FromQuery] DateTime olderThan, CancellationToken cancellationToken = default)
    {
        var result = await exceptionLogAppService.CleanupOldExceptionLogsAsync(olderThan, cancellationToken);
        return Ok(result);
    }
}