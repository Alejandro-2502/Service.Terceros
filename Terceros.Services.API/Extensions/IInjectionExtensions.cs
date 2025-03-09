using Terceros.Applications.Gateways;
using Terceros.Applications.Interactors.Common;
using Terceros.Applications.Interactors.People;
using Terceros.Applications.Interfaces.ICommon;
using Terceros.Applications.Interfaces.People;
using Terceros.Services.People;

namespace Terceros.Services.API.Extensions;

public static class IInjectionExtension
{
    public static IServiceCollection AddInjection(this IServiceCollection services)
    {
        services.AddSingleton<IPeopleGateway, PeopleServices>();
        services.AddSingleton<IPeopleInteractor, PeopleInteractor>();

        services.AddSingleton<ILogServices>(new LogServices("logfileTerceros.txt"));
        services.AddScoped<ResponseHttp>();

        return services;
    }
}
