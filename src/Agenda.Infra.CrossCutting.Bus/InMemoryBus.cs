using Agenda.Domain.Core.Bus;
using Agenda.Domain.Core.Notifications;
using System.Collections.Generic;

namespace Agenda.Infra.CrossCutting.Bus
{
    public class InMemoryBus : IBus
    {
        private readonly IDomainNotificationHandler _dnh;

        public InMemoryBus(IDomainNotificationHandler dnh)
        {
            _dnh = dnh;
        }

        public List<DomainNotification> GetInMemoryBusNotifications()
        {
            return _dnh.GetNotifications();
        }

        public bool HasInMemoryBusNotifications()
        {
            return _dnh.HasNotifications();
        }
    }
}
