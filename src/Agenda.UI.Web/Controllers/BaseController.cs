using Agenda.Domain.Core.Bus;
using System.Web.Mvc;

namespace Agenda.UI.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IBus _bus;

        public BaseController(IBus bus)
        {
            _bus = bus;
        }

        /// <summary>
        /// Validate the Operation
        /// </summary>
        /// <param name="successMessage">Message when Operation is Valid</param>
        /// <returns>If valid returns TRUE if not return FALSE</returns>
        protected bool ValidOperation(string successMessage = null)
        {
            if (_bus.HasInMemoryBusNotifications())
            {
                foreach (var erro in _bus.GetInMemoryBusNotifications())
                    ModelState.AddModelError(string.Empty, erro.ErrorMessage);

                return false;
            }

            TempData["Sucesso"] = successMessage;
            return true;
        }
    }
}