using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Wincomp.DAL;
using PagedList;
using PagedList.Mvc;
using Wincomp.Models;
using System.Net;

namespace Wincomp.Controllers
{
    public class TreinamentosController : Controller
    {
        WincompDbContext db = new WincompDbContext();
        // GET: Cursos
        private void CarregarListaDepartamento(Departamento deptoSelecionado = null)
        {
            var listaDepartamentos = from d in db.Departamentos
                                     orderby d.DepartamentoNome
                                     select d;
            ViewBag.DepartamentoID = new SelectList(listaDepartamentos, "DepartamentoID", "DepartamentoNome", deptoSelecionado);

        }
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
                case "cred_desc":
                    treinamentos = treinamentos.OrderByDescending(s => s.Creditos);
                    break;
                case "cred":
                    treinamentos = treinamentos.OrderBy(s => s.Creditos);
                    break;
                default:
                    treinamentos = treinamentos.OrderBy(s => s.Titulo);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(treinamentos.ToPagedList(pageNumber, pageSize));
        }
        
        public ActionResult Incluir()
        {
            CarregarListaDepartamento();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Incluir([Bind(Include = "TreinamentoID,DepartamentoID,Titulo,Creditos")]Treinamento treinamento)
        {
            if (ModelState.IsValid)
            {
                db.Treinamentos.Add(treinamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(treinamento);
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treinamento treinamento = db.Treinamentos.Find(id);
            if (treinamento == null) return HttpNotFound();
            CarregarListaDepartamento(treinamento.Departamento);
            return View(treinamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "TreinamentoID,DepartamentoID,Titulo,Creditos")]Treinamento treinamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treinamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CarregarListaDepartamento(treinamento.Departamento);
            return View(treinamento);
        }

        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treinamento treinamento = db.Treinamentos.Find(id);
            if (treinamento == null) return HttpNotFound();
            CarregarListaDepartamento(treinamento.Departamento);
            return View(treinamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir([Bind(Include = "TreinamentoID,DepartamentoID,Titulo,Creditos")]Treinamento treinamento)
        {
            
                db.Treinamentos.Remove(treinamento);
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }
    }

}