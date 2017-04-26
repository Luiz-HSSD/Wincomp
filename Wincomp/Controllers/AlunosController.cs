using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wincomp.Models;
using Wincomp.DAL;

namespace Wincomp.Controllers
{
    public class AlunosController:Controller
    {
        WincompDbContext db = new WincompDbContext();

        public ActionResult Index()
        {
            return View(db.Alunos.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}