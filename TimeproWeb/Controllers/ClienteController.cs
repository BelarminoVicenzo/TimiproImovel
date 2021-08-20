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
    public class ClienteController : Controller
    {
        private IClienteService _clienteService;
       

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
                  }
        // GET: Cliente
        public async Task<ActionResult> Index()
        {

            return View(await _clienteService.GetAll());
        }

       
        public async Task<ActionResult> Details(int id)
        {
            var cliente = await _clienteService.Get(id);
            return View(cliente);
        }


        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            try
            {
                await _clienteService.Create(cliente);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public async Task<ActionResult> Edit(int id)
        {
            var cliente = await _clienteService.Get(id);   
            return View(cliente);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Cliente cliente)
        {
            try
            {

                await _clienteService.Update(cliente);
                return RedirectToAction($"Details/{cliente.Id}");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

       
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await _clienteService.Get(id);
            return View(cliente);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Cliente cliente)
        {
            try
            {

                await _clienteService.Delete(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
