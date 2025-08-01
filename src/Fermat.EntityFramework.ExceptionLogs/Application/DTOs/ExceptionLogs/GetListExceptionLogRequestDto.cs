using System.Text.Json.Serialization;
using Fermat.EntityFramework.Shared.DTOs.Sorting;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Fermat.EntityFramework.ExceptionLogs.Application.DTOs.ExceptionLogs;

public class GetListExceptionLogRequestDto
{
    public int Page { get; set; } = 1;
    public int PerPage { get; set; } = 25;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SortOrderTypes Order { get; set; } = SortOrderTypes.Desc;
    public string? Field { get; set; } = null;

    public string? ExceptionType { get; set; }
    public string? Code { get; set; }
    public int? StatusCode { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public Guid? SnapshotId { get; set; }
    public Guid? SessionId { get; set; }
    public Guid? CorrelationId { get; set; }
}

public class GetListExceptionLogRequestValidation : AbstractValidator<GetListExceptionLogRequestDto>
{
    public GetListExceptionLogRequestValidation()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0);

        RuleFor(x => x.PerPage)
            .InclusiveBetween(1, 100);

        RuleFor(x => x.Field)
            .MaximumLength(100)
            .Matches(@"^[a-zA-Z0-9_]+$");

        RuleFor(x => x.Order)
            .IsInEnum();
        
        RuleFor(x => x.ExceptionType)
            .MaximumLength(256)
            .Matches(@"^[a-zA-Z0-9_.]+$");
        
        RuleFor(x => x.Code)
            .MaximumLength(100)
            .Matches(@"^[a-zA-Z0-9_.-]+$");

        RuleFor(x => x.StartDate)
            .LessThan(x => x.EndDate)
            .LessThanOrEqualTo(DateTime.Today);

        RuleFor(x => x.EndDate)
            .LessThanOrEqualTo(DateTime.Today)
            .GreaterThan(x => x.StartDate);

        RuleFor(x => x.SnapshotId)
            .Must(x => x == null || x != Guid.Empty);

        RuleFor(x => x.SessionId)
            .Must(x => x == null || x != Guid.Empty);

        RuleFor(x => x.CorrelationId)
            .Must(x => x == null || x != Guid.Empty);
    }
}