using Agenda.Domain.Core.Notifications;
using Agenda.Infra.Data.Context;
using System;

namespace Agenda.Infra.Data.UoW
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly AgendaContext _ctx;
        private readonly IDomainNotificationHandler _notifications;
        private bool _disposed;

        public UnityOfWork(
            AgendaContext ctx,
            IDomainNotificationHandler notifications)
        {
            _ctx = ctx;
            _notifications = notifications;
            _disposed = false;
        }

        public void Commit()
        {
            var rowsAffected = _ctx.SaveChanges();
            if (rowsAffected == 0)
                _notifications.SetNotification(new DomainNotification("Commit", "Ocorreu um erro ao salvar os dados no banco"));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
