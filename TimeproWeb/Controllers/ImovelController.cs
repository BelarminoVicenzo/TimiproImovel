using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Timipro.BLL.Services;
using Timipro.Models;

namespace TimiproImovel.Controllers
{
    public class ImovelController : Controller
    {

        private IImovelService _imovelService;
        private ITipoNegocioService _tpnService;
        private IClienteService _clienteService;

        public ImovelController(IImovelService imovelService, ITipoNegocioService tpnService, IClienteService clienteService)
        {
            _imovelService = imovelService;
            _tpnService = tpnService;
            _clienteService = clienteService;
        }

        public async Task<ActionResult> Index()
        {

            return View(await _imovelService.GetAll());
        }


        public async Task<ActionResult> Details(int id)
        {
            var imovel = await _imovelService.Get(id);
            return View(imovel);
        }



        public async Task<ActionResult> Create()
        {
            await AddViewBagForClienteAndTipoVenda();
            return View();
        }

        private async Task AddViewBagForClienteAndTipoVenda(Cliente recordToBeKept = null)
        {
            ViewBag.IdTipoNegocio = new SelectList(await _tpnService.GetAll(), "Id", "Tipo");
            ViewBag.IdCliente = new SelectList(await FilteredClients(recordToBeKept), "Id", "Email");
        }

        /// <summary>
        /// If this cliente is provided it will be kept in the list
        /// </summary>
        /// <param name="recordToBeKept"></param>
        /// <returns></returns>
        private async Task<IEnumerable<Cliente>> FilteredClients(Cliente recordToBeKept = null)
        {
            var idClientes = (from c in await _imovelService.GetAll() select c.IdCliente).ToArray();
            var allowedCliente = (from c in await _clienteService.GetAll() where c.Ativo == true select c).ToList();


            if (recordToBeKept is null)
            {
                //iterate according the number of Clientes with
                //Imovel associated
                for (int i = 0; i < idClientes.Count(); i++)
                {

                    for (int j = 0; j < allowedCliente.Count; j++)
                    {
                        //remove the ones that already have an association except initializer cliente
                        if (allowedCliente[j].Id == idClientes[i] && allowedCliente[j].Email!= "clienteinicial@timiproimovel.com")
                        {
                            allowedCliente.RemoveAt(j);
                        }

                    }

                }
            }
            else
            {
                for (int i = 0; i < idClientes.Count(); i++)
                {

                    for (int j = 0; j < allowedCliente.Count; j++)
                    {
                        //almost the same as above, but preserve a chosen record
                        if (allowedCliente[j].Id == idClientes[i] 
                            && allowedCliente[j].Email!= "clienteinicial@timiproimovel.com"
                            && allowedCliente[j].Id != recordToBeKept.Id)
                        {
                            allowedCliente.RemoveAt(j);
                        }

                    }

                }
            }


            return allowedCliente;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Imovel imovel)
        {
            try
            {
                await _imovelService.Create(imovel);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }


        public async Task<ActionResult> Edit(int id)
        {
            //when editing assign only to him and another Cliente who has no Imovel
            var imovel = await _imovelService.Get(id);
            var clientToBeKept = await _clienteService.Get(imovel.IdCliente);

            await AddViewBagForClienteAndTipoVenda(clientToBeKept);

            return View(imovel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Imovel imovel)
        {
            try
            {

                await _imovelService.Update(imovel);
                return RedirectToAction($"Details/{imovel.Id}");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }


        public async Task<ActionResult> Delete(int id)
        {
            var imovel = await _imovelService.Get(id);
            return View(imovel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Imovel imovel)
        {
            try
            {

                await _imovelService.Delete(imovel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}