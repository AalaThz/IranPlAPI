using AutoMapper;
using Iranpl.ApplicationCore.Profiles;
using Iranpl.ApplicationCore.Services.Implementations;
using Iranpl.ApplicationCore.Services.Intefaces;
using Iranpl.Domain.Models.ApiModels;
using Iranpl.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Iranpl.Ioc
{
    public static class DependencyContainers
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            #region DI
            service.AddScoped<ILoginService, LoginService>();
            //service.AddScoped<IStateRepository, StateReository>();
            //service.AddScoped<StateService>();
            //service.AddScoped<IHttpService, HttpService>();
            #endregion

            #region AutoMapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            service.AddSingleton(mapper);
            #endregion
        }
    }
}
