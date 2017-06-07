using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wincomp.DAL;
using Wincomp.Models;

namespace Wincomp.Controllers
{
    public class DepartamentosController : Controller
    {
        WincompDbContext db = new WincompDbContext();

        // GET: Departamentos
        public ActionResult Index()
        {
            return View(db.Departamentos.ToList());
        }
        public ActionResult Incluir()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Incluir([Bind(Include = "DepartamentoID,DepartamentoNome")]Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                db.Departamentos.Add(departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departamento);
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamentos.Find(id);
            if (departamento == null) return HttpNotFound();
            return View(departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "DepartamentoID,DepartamentoNome")]Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departamento);
        }

        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamentos
                    .Include(i => i.Treinamentos)
                    .Where(i => i.DepartamentoID == id)
                    .Single();
            if (departamento == null) return HttpNotFound();
            return View(departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir([Bind(Include = "DepartamentoID,DepartamentoNome")]Departamento dep)
        {
            Departamento departamento = db.Departamentos
                    .Include(i => i.Treinamentos)
                    .Where(i => i.DepartamentoID == dep.DepartamentoID)
                    .Single();
            db.Departamentos.Remove(departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamentos
                .Include(i => i.Treinamentos)
                .Where(i => i.DepartamentoID == id)
                .Single();
            if (departamento == null) return HttpNotFound();
            return View(departamento);
        }
    }
}