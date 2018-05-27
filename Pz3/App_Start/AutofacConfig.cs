using System.Configuration;
using System.Web.Hosting;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Pz3.Services;
using Pz3.Services.Interfaces;

namespace Pz3
{
    public static class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var connectionString = ConfigurationManager.AppSettings["ConnectionString"]
                .Replace("%dir%", HostingEnvironment.ApplicationPhysicalPath);

            builder.RegisterType<ToDoService>()
                .As<IToDoService>()
                .WithParameter("connectionString", connectionString);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}