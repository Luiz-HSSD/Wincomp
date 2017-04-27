using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wincomp.Models;
using Wincomp.DAL;
using System.Data.Entity;

namespace Wincomp.Controllers
{
    public class AlunosController:Controller
    {
        WincompDbContext db = new WincompDbContext();

        public ActionResult Index()
        {
            return View(db.Alunos.ToList());
        }
        public ActionResult Detalhes(int? id)
        {
            Aluno aluno = db.Alunos.Find(id);
            return View(aluno);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Editar(int? id)
        {
            Aluno aluno = db.Alunos.Find(id);
            return View(aluno);
        }
        [HttpPost]
        public ActionResult Editar([Bind(Include = "AlunoID,NomeAluno,Email,Data")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aluno);
        }
        public ActionResult Excluir(int? id)
        {
            Aluno aluno = db.Alunos.Find(id);
            return View(aluno);
        }
        [HttpPost]
        public ActionResult Excluir(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            db.Alunos.Remove(aluno);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Incluir()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Incluir([Bind(Include = "AlunoID,NomeAluno,Email,Data")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Alunos.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aluno);
        }
    }
}