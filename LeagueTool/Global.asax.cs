using Autofac;
using Autofac.Integration.Mvc;
using LeagueTool.Services;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LeagueTool.Factories;
using RiotSharp.Interfaces;

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

            builder.RegisterType<ConfigService>().AsSelf().SingleInstance();
            builder.RegisterType<RiotApiFactory>().AsSelf().SingleInstance();
            builder.Register(c => c.Resolve<RiotApiFactory>().CreateRiotApi()).AsSelf().SingleInstance();
            builder.Register(c => c.Resolve<RiotApiFactory>().CreateStaticRiotApi()).AsSelf().SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
