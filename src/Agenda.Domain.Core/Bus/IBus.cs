using Agenda.Domain.Core.Notifications;
using System.Collections.Generic;

namespace Agenda.Domain.Core.Bus
{
    public interface IBus
    {
        bool HasInMemoryBusNotifications();
        List<DomainNotification> GetInMemoryBusNotifications();
        //bool HasParameters
    }
}
