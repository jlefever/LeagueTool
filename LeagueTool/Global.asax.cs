using System.Net.Http;
using Autofac;
using Autofac.Integration.Mvc;
using LeagueTool.Services;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;

namespace LeagueTool
{
    public class LeagueTool : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ConfigureIoc();
        }

        private static void ConfigureIoc()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(LeagueTool).Assembly);

            builder.RegisterType<HttpClient>().AsSelf().SingleInstance();
            builder.RegisterType<ConfigService>().As<IConfigService>().SingleInstance();
            builder.RegisterType<RestService>().As<IRestService>().SingleInstance();
            builder.RegisterType<DataDragonService>().As<IDataDragonService>().SingleInstance();

            ConfigureAutoMapper(builder);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void ConfigureAutoMapper(ContainerBuilder builder)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(typeof(LeagueTool).Assembly);
            });

            config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();

            builder.RegisterInstance(mapper).As<IMapper>().SingleInstance();
        }
    }
}
