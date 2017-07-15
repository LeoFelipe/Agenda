using System;

namespace Agenda.Domain.Core.Notifications
{
    public class DomainNotification
    {
        public Guid DomainNotificationId { get; private set; }
        public string MessageKey { get; private set; }
        public string ErrorMessage { get; private set; }

        public DomainNotification(string messageKey, string errorMessage)
        {
            DomainNotificationId = Guid.NewGuid();
            MessageKey = messageKey;
            ErrorMessage = errorMessage;
        }
    }
}
