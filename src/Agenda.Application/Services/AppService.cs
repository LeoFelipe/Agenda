using Agenda.Infra.Data.UoW;

namespace Agenda.Application.Services
{
    public abstract class AppService
    {
        protected readonly IUnityOfWork _uow;

        public AppService(IUnityOfWork uow)
        {
            _uow = uow;
        }
    }
}
