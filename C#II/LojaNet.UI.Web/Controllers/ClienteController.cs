using LojaNet.BLL;
using LojaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaNet.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        ClienteBLL bll;
        public ClienteController()
        {
            this.bll = new ClienteBLL();
        }
        public ActionResult Incluir()
        {
            return View(new Cliente());
        }
        [HttpPost]
        public ActionResult Incluir(Cliente cliente)
        {
            try
            {
                bll.Incluir(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
        }
        public ActionResult Index()
        {
            return View(bll.ObterTodosClientes());
        }
        public ActionResult Detalhes(string id)
        {
            return View(bll.ObterporId(id));
        }
        public ActionResult Alterar(string id)
        {
            return View(bll.ObterporId(id));
        }
        [HttpPost]
        public ActionResult Alterar(Cliente cliente)
        {
            try
            {
                bll.Alterar(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
        }
        public ActionResult Excluir(string id)
        {
            return View(bll.ObterporId(id));
        }
        [HttpPost]
        public ActionResult Excluir(string id, FormCollection form)
        {
            try
            {
                string arquivo = HttpContext.Server.MapPath("~/App_Data/Cliente " + id + ".xml");
                bll.Excluir(id, arquivo);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(bll.ObterporId(id));
            }
        }
    }
}