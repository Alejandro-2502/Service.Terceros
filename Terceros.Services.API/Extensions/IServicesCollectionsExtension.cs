using Terceros.Applications.Configurations.ApisTerceros;
using Terceros.Applications.Configurations;
using Terceros.Applications.Gateways;
using Terceros.Services.People;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Terceros.Applications.Mappers;

namespace Terceros.Services.API.Extensions;

public static class IServicesCollectionsExtension
{
    public static IServiceCollection Configure(this IServiceCollection services, WebApplicationBuilder webApplicationBuilder, IConfiguration configuration)
    {
        //ConfigHelper.SqlServer = configuration.GetSection(nameof(ConnectionsSqlServer)).Get<ConnectionsSqlServer>();
        ConfigHelper.ApiPeople = configuration.GetSection(nameof(ApiPeople)).Get<ApiPeople>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddMvc();
        AddHttpClient(services);
        IInjectionExtension.AddInjection(services);
        AddConfigureSwagger(services);
        services.AddAutoMapper();


        return services;
    }

    public static IServiceCollection AddConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Api Terceros",
                Version = "v1"
            });
        });

        return services;
    }

    public static IServiceCollection AddHttpClient(this IServiceCollection services)
    {
        try
        {
            services.AddHttpClient<IPeopleGateway, PeopleServices>(ConfigHelper.ApiPeople!.HttpClientName, Client =>
            {
                Client.BaseAddress = new Uri(ConfigHelper.ApiPeople.Endpoint);
            }); 

        }
        catch (Exception ex)
        {
            throw;
        }

        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(typeof(MapperProfile));
        });

        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
        return services;
    }
}
