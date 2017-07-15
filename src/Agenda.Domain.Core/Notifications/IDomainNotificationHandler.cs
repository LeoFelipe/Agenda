using FluentValidation.Results;
using System.Collections.Generic;

namespace Agenda.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler
    {
        bool HasNotifications();
        List<DomainNotification> GetNotifications();
        void SetNotification(DomainNotification notification);
        void NotificarValidacoesErro(ValidationResult validationResult);
    }
}
