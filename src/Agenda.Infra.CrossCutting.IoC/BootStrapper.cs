using Agenda.Application.Services;
using Agenda.Domain.Core.Bus;
using Agenda.Domain.Core.Notifications;
using Agenda.Domain.Services;
using Agenda.Infra.CrossCutting.Bus;
using Agenda.Infra.Data.Context;
using Agenda.Infra.Data.Repositories;
using Agenda.Infra.Data.UoW;
using SimpleInjector;
using System.Linq;

namespace Agenda.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterApplicationServices(Container container)
        {
            var appServiceAssembly = typeof(ClienteAppService).Assembly;

            var appServiceRegistrations =
                from type in appServiceAssembly.GetExportedTypes()
                where type.Namespace == "Agenda.Application.Services"
                where type.GetInterfaces().Any()
                select new { Interface = type.GetInterfaces().Where(i => i.Name == "I" + type.Name).FirstOrDefault(), Implementation = type };

            foreach (var reg in appServiceRegistrations)
                container.Register(reg.Interface, reg.Implementation, Lifestyle.Scoped);
        }

        public static void RegisterDomainServices(Container container)
        {
            var domainServiceAssembly = typeof(ClienteService).Assembly;

            var serviceRegistrations =
                from type in domainServiceAssembly.GetExportedTypes()
                where type.Namespace == "Agenda.Domain.Services"
                where type.GetInterfaces().Any() && !type.Name.StartsWith("Service")
                select new { Interface = type.GetInterfaces().Where(i => i.Name == "I" + type.Name).FirstOrDefault(), Implementation = type };

            foreach (var reg in serviceRegistrations)
                container.Register(reg.Interface, reg.Implementation, Lifestyle.Scoped);

            container.Register<IDomainNotificationHandler, DomainNotificationHandler>(Lifestyle.Scoped);
        }

        public static void RegisterInfraServices(Container container)
        {
            var repositoryAssembly = typeof(ClienteRepository).Assembly;

            var repositoryRegistrations =
                from type in repositoryAssembly.GetExportedTypes()
                where type.Namespace == "Agenda.Infra.Data.Repositories"
                where type.GetInterfaces().Any() && !type.Name.StartsWith("Repository")
                select new { Interface = type.GetInterfaces().Where(i => i.Name == "I" + type.Name).FirstOrDefault(), Implementation = type };

            foreach (var reg in repositoryRegistrations)
                container.Register(reg.Interface, reg.Implementation, Lifestyle.Scoped);

            container.Register<IBus, InMemoryBus>(Lifestyle.Scoped);
            container.Register<IUnityOfWork, UnityOfWork>(Lifestyle.Scoped);
            container.Register<AgendaContext>(Lifestyle.Scoped);
        }
    }
}