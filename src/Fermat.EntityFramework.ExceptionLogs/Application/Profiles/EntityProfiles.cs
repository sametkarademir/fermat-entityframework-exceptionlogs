using AutoMapper;
using Fermat.EntityFramework.ExceptionLogs.Application.DTOs.ExceptionLogs;
using Fermat.EntityFramework.ExceptionLogs.Domain.Entities;

namespace Fermat.EntityFramework.ExceptionLogs.Application.Profiles;

public class EntityProfiles : Profile
{
    public EntityProfiles()
    {
        CreateMap<ExceptionLog, ExceptionLogResponseDto>();
    }
}