using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wincomp.DAL;
using System.Data.Entity;
using PagedList.Mvc;
using PagedList;

namespace Wincomp.Controllers
{
    public class MatriculasController : Controller
    {
        WincompDbContext db = new WincompDbContext();
        // GET: Matriculas
        public ActionResult Index(string ordem, string filtroAtual, string BuscaNome, int? page)
        {
            ViewBag.Ordenacão = ordem;
            ViewBag.OrdemNome=string.IsNullOrEmpty(ordem) ? "nome_desc" : "";
            ViewBag.OrdemDepartamento = ordem == "dep" ? "dep_desc" : "dep";
            ViewBag.OrdemTreinamento = ordem == "tre" ? "tre_desc" : "tre";
            ViewBag.OrdemData = ordem == "data" ? "data_desc" : "data";

            var matriculas = db.Matriculas.Include(m => m.Alunos).Include(m => m.Treinamentos).Include(m => m.Treinamento.Departamento);
            if (BuscaNome != null)
                page = 1;
            else
                BuscaNome = filtroAtual;
            ViewBag.FiltroAtual = BuscaNome;


            if (!string.IsNullOrEmpty(BuscaNome))
                matriculas = matriculas.Where(s => s.Aluno.NomeAluno.ToUpper().Contains(BuscaNome.ToUpper()));

            switch (ordem)
            {
                case "data":
                    matriculas = matriculas.OrderBy(m => m.DataMatricula);
                    break;
                case "data_desc":
                    matriculas = matriculas.OrderByDescending(m => m.DataMatricula);
                    break;
                case "dep":
                    matriculas = matriculas.OrderBy(m => m.Treinamento.Departamento.DepartamentoNome);
                    break;
                case "dep_desc":
                    matriculas = matriculas.OrderByDescending(m => m.Treinamento.Departamento.DepartamentoNome);
                    break;
                case "tre":
                    matriculas = matriculas.OrderBy(m => m.Treinamento.Titulo);
                    break;
                case "tre_desc":
                    matriculas = matriculas.OrderByDescending(m => m.Treinamento.Titulo);
                    break;
                case "nome_desc":
                    matriculas = matriculas.OrderByDescending(m => m.Aluno.NomeAluno);
                    break;
                default:
                    matriculas = matriculas.OrderBy(m => m.Aluno.NomeAluno);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(matriculas.ToPagedList(pageNumber, pageSize));
        }
    }
}