using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Domain.Core.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }

        public void SetNotification(DomainNotification notification)
        {
            _notifications.Add(notification);
        }

        public void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _notifications.Add(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}
