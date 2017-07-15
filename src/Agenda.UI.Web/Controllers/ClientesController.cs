using System.Net;
using System.Web.Mvc;
using Agenda.Application.ViewModels.Cliente;
using Agenda.Application.Interfaces;
using Agenda.Domain.Core.Bus;

namespace Agenda.UI.Web.Controllers
{
    public class ClientesController : BaseController
    {
        private readonly IClienteAppService _clienteAppService;
        private readonly IBus _bus;

        public ClientesController(IClienteAppService clienteAppService, IBus bus)
            : base(bus)
        {
            _clienteAppService = clienteAppService;
            _bus = bus;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterAtivos());
        }

        [HttpGet]
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
                return HttpNotFound();

            return View(clienteViewModel);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Adicionar(clienteViewModel);

                if (!ValidOperation("Cliente cadastrado com Sucesso!"))
                    return View(clienteViewModel);

                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        [HttpGet]
        public ActionResult Editar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
                return HttpNotFound();

            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);

                if (!ValidOperation("Cliente editado com Sucesso!"))
                    return View(clienteViewModel);

                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        [HttpGet]
        public ActionResult Excluir(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            _clienteAppService.Remover(id.Value);

            ValidOperation("Cliente excluído com Sucesso!");            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _clienteAppService.Dispose();

            base.Dispose(disposing);
        }
    }
}
