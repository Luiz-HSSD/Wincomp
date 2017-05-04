using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wincomp.Models;
using Wincomp.DAL;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;

namespace Wincomp.Controllers
{
    public class AlunosController:Controller
    {
        WincompDbContext db = new WincompDbContext();

        public ActionResult Index(string ordem, string filtroAtual, string BuscaNome, int? page)
        {
            ViewBag.Ordenacao = ordem;
            ViewBag.OrdemNome = string.IsNullOrEmpty(ordem) ? "nome_desc" : "";
            ViewBag.OrdemData = ordem == "data" ? "data_desc" : "data";

            var alunos = from s in db.Alunos select s;
            if (BuscaNome != null)
                page = 1;
            else
                BuscaNome = filtroAtual;
            ViewBag.FiltroAtual = BuscaNome;


            if (!string.IsNullOrEmpty(BuscaNome))
                alunos = alunos.Where(s => s.NomeAluno.ToUpper().Contains(BuscaNome.ToUpper()));

            switch (ordem)
            {
                case "nome_desc":
                    alunos = alunos.OrderByDescending(s => s.NomeAluno);
                    break;
                case "data_desc":
                    alunos = alunos.OrderByDescending(s => s.Data);
                    break;
                case "data":
                    alunos = alunos.OrderBy(s => s.Data);
                    break;
                default:
                    alunos = alunos.OrderBy(s => s.NomeAluno);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1 );
            return View(alunos.ToPagedList(pageNumber,pageSize));
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
        public ActionResult Editar([Bind(Include = "AlunoID,NomeAluno,SobrenomeAluno,Email,Data")] Aluno aluno)
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
            if (aluno == null)
            {
                return HttpNotFound();
            }
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
        public ActionResult Incluir([Bind(Include = "AlunoID,NomeAluno,SobrenomeAluno,Email,Data")] Aluno aluno)
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