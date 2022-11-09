using AutoMapper;
using Ecosia.SearchEngine.Application.Features.Projects.Commands;
using Ecosia.SearchEngine.Application.Features.Projects.Queries;
using Ecosia.SearchEngine.Application.Features.Reports.Commands;
using Ecosia.SearchEngine.Application.Features.Reports.Queries;
using Ecosia.SearchEngine.Application.Features.Search.Queries;
using Ecosia.SearchEngine.Domain.Entities;

namespace Ecosia.SearchEngine.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Project, ProjectListVm>().ReverseMap();
        CreateMap<Tag, TagListVm>().ReverseMap();
        
        CreateMap<Project, ProjectDetailVm>().ReverseMap();
        CreateMap<Tag, TagDetailVm>().ReverseMap();
        
        CreateMap<CreateProjectCommand, Project>();
        CreateMap<Project, CreateProjectCommand>().ReverseMap();
        CreateMap<Project, UpdateProjectCommand>().ReverseMap();
        
        CreateMap<Report, ReportListVm>().ReverseMap();
        CreateMap<CategoryInvestment, CategoryInvestmentVm>().ReverseMap();
        CreateMap<CountryInvestment, CountryInvestmentVm>().ReverseMap();
        
        CreateMap<Report, ReportDetailVm>().ReverseMap();
        CreateMap<CategoryInvestment, CategoryDetailInvestmentVm>().ReverseMap();
        CreateMap<CountryInvestment, CountryDetailInvestmentVm>().ReverseMap();
        
        CreateMap<CreateReportCommand, Report>();
        CreateMap<Report, CreateReportCommand>().ReverseMap();
        CreateMap<Report, UpdateReportCommand>().ReverseMap();

        CreateMap<Search, SearchesListVm>().ReverseMap();
    }
}