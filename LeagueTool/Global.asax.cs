using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using LeagueTool.Services;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LeagueTool.Factories;
using MediatR;

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
            builder.RegisterType<RiotClientFactory>().AsSelf().SingleInstance();
            builder.Register(c => c.Resolve<RiotClientFactory>().CreateRiotClient()).AsSelf().SingleInstance();

            ConfigureMediatr(builder);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void ConfigureMediatr(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(INotificationHandler<>)
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(typeof(LeagueTool).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
        }
    }
}
