using AutoMapper;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Refit;
using TeamBuilder.TeamMemberList.Application;
using TeamBuilder.TeamMembers.Application.AddTeamMembers;
using TeamBuilder.TeamMembers.Application.Interfaces;
using TeamBuilder.TeamMembers.Application.Models;
using TeamBuilder.TeamMembers.Application.Services;
using TeamBuilder.TeamMembers.Application.ViewModel;
using TeamBuilder.TeamMembers.Application.ViewModels;
using TeamBuilder.TeamMembers.Domain;
using TeamBuilder.TeamMembers.Domain.Entities;
using TeamBuilder.TeamMembers.Infrastructure;
using TeamBuilder.TeamMembers.Infrastructure.Models;
using TeamBuilder.TeamMembers.Infrastructure.Models.Responses;

namespace TeamBuilder;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .RegisterRefitClient()
            .RegisterMapper()
            .RegisterRepositories()
            .RegisterPages()
            .RegisterViewModels();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
    public static MauiAppBuilder RegisterRefitClient(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddRefitClient<ITeamMemberClient>()
           .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://10.0.2.2:5076"));

        return mauiAppBuilder;
    }
    public static MauiAppBuilder RegisterMapper(this MauiAppBuilder mauiAppBuilder)
    {
        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<TeamMemberResponseModel, TeamMemberEntity>();
            cfg.CreateMap<TeamMemberEntity, TeamMemberResponseModel>();
            cfg.CreateMap<TeamMemberRequestModel, TeamMemberEntity>();
            cfg.CreateMap<TeamMemberEntity, TeamMemberRequestModel>();
            cfg.CreateMap<TeamMemberEntity, TeamMemberViewModel>();
            cfg.CreateMap<TeamMemberViewModel, TeamMemberEntity>();//TeamMemberRequestModel//TeamMemberEntity
          
            // Add more mappings as needed
        });
        IMapper mapper = config.CreateMapper();
        mauiAppBuilder.Services.AddSingleton(mapper);

        return mauiAppBuilder;
    }
    public static MauiAppBuilder RegisterRepositories(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ITeamMembersRepository, TeamMembersRepository>();
        mauiAppBuilder.Services.AddSingleton<IAlertService, AlertService>();

        return mauiAppBuilder;
    }
    public static MauiAppBuilder RegisterPages(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<AddTeamMembersPage>();
        mauiAppBuilder.Services.AddSingleton<TeamMembersPage>();

        return mauiAppBuilder;
    }
    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<TeamMembersViewModel>();//AddTeamMembersViewModel
        mauiAppBuilder.Services.AddSingleton<AddTeamMembersViewModel>();

        return mauiAppBuilder;
    }
}

