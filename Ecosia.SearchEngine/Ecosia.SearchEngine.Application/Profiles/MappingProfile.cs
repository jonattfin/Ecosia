using AutoMapper;
using Ecosia.SearchEngine.Application.Features.Projects.Commands.CreateProject;
using Ecosia.SearchEngine.Application.Features.Projects.Commands.UpdateProject;
using Ecosia.SearchEngine.Application.Features.Projects.Queries.GetProjectDetail;
using Ecosia.SearchEngine.Application.Features.Projects.Queries.GetProjectsList;
using Ecosia.SearchEngine.Application.Features.Reports.Queries.GetReportDetail;
using Ecosia.SearchEngine.Domain.Entities;

namespace Ecosia.SearchEngine.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Project, ProjectListVm>().ReverseMap();
        CreateMap<Project, ProjectDetailVm>().ReverseMap();
        CreateMap<CreateProjectCommand, Project>();
        CreateMap<Project, CreateProjectCommand>().ReverseMap();
        CreateMap<Project, UpdateProjectCommand>().ReverseMap();
        
        // CreateMap<Report, ReportList>().ReverseMap();
        CreateMap<Report, ReportDetailVm>().ReverseMap();
    }
}