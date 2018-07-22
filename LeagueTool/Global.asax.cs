using Autofac;
using Autofac.Integration.Mvc;
using LeagueTool.Services;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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

        private void ConfigureIoc()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(LeagueTool).Assembly);

            builder.RegisterType<ConfigService>().AsSelf().SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
