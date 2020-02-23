using LojaNet.Models.Contracts;
using System;
using LojaNet.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaNet.UI.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutosDAL bll;
        public ProdutoController()
        {
            bll = AppContainer.ObterProdutoBLL();
        }
        public ActionResult Incluir()
        {
            return View(new Produto());
        }
        [HttpPost]
        public ActionResult Incluir(Produto produto)
        {
            try
            {
                bll.Incluir(produto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(produto);
            }
        }
        public ActionResult Index()
        {
            return View(bll.ObterTodosProdutos());
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
        public ActionResult Alterar(Produto produto)
        {
            try
            {
                bll.Alterar(produto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(produto);
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
                bll.Excluir(id);
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