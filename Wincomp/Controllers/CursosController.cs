using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Wincomp.DAL;
using PagedList;
using PagedList.Mvc;

namespace Wincomp.Controllers
{
    public class CursosController : Controller
    {
        WincompDbContext db = new WincompDbContext();
        // GET: Cursos
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Index(string ordem, string filtroAtual, string BuscaNome, int? page)
        {
            ViewBag.Ordenacao = ordem;
            ViewBag.OrdemNome = string.IsNullOrEmpty(ordem) ? "nome_desc" : "";
            ViewBag.OrdemDepartamento = ordem == "dep" ? "dep_desc" : "dep";
            ViewBag.OrdemCreditos = ordem == "cred" ? "cred_desc" : "cred";
            var treinamentos = db.Treinamentos.Include(t => t.Departamento);
            if (BuscaNome != null)
                page = 1;
            else
                BuscaNome = filtroAtual;
            ViewBag.FiltroAtual = BuscaNome;


            if (!string.IsNullOrEmpty(BuscaNome))
                treinamentos = treinamentos.Where(s => s.Titulo.ToUpper().Contains(BuscaNome.ToUpper()));

            switch (ordem)
            {
                case "nome_desc":
                    treinamentos = treinamentos.OrderByDescending(s => s.Titulo);
                    break;
                case "dep_desc":
                    treinamentos = treinamentos.OrderByDescending(s => s.Departamento.DepartamentoNome);
                    break;
                case "dep":
                    treinamentos = treinamentos.OrderBy(s => s.Departamento.DepartamentoNome);
                    break;
                default:
                    treinamentos = treinamentos.OrderBy(s => s.Titulo);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(treinamentos.ToPagedList(pageNumber, pageSize));
        }
    }
}