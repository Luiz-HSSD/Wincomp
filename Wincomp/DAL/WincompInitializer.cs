using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wincomp.Models;

namespace Wincomp.DAL
{
    public class WincompInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<WincompDbContext>
    {
        protected override void Seed(WincompDbContext context)
        {
            var alunos = new List<Aluno>
            {
                new Aluno(){AlunoID=1, NomeAluno="João", SobrenomeAluno="Silva", Email="joao@wincomp.com.br",Data=DateTime.Parse("2014-02-25")},
                new Aluno(){AlunoID=2, NomeAluno="José", SobrenomeAluno=" Oliveira", Email="josé@wincomp.com.br",Data=DateTime.Parse("2014-03-26")},
                new Aluno(){AlunoID=3, NomeAluno="Maria", SobrenomeAluno="Cruz", Email="maria@wincomp.com.br",Data=DateTime.Parse("2014-04-27")}
            };
            alunos.ForEach(s => context.Alunos.Add(s));
            context.SaveChanges();
            var departamentos = new List<Departamento>
            {
                new Departamento{DepartamentoID=1, DepartamentoNome="Matemática"},
                new Departamento{DepartamentoID=2, DepartamentoNome="Informática"},
                new Departamento{DepartamentoID=3, DepartamentoNome="Física"}
            };
            departamentos.ForEach(s => context.Departamentos.Add(s));
            context.SaveChanges();
            var treinamentos = new List<Treinamento>()
            {
                new Treinamento(){TreinamentoID=1, DepartamentoID=1, Titulo="C# básico",Creditos=2},
                new Treinamento(){TreinamentoID=2, DepartamentoID=2, Titulo="ASP .NET Web Forms",Creditos=3},
                new Treinamento(){TreinamentoID=3, DepartamentoID=3, Titulo="ASP .NET MVC",Creditos=5},
            };
            treinamentos.ForEach(s => context.Treinamentos.Add(s));
            context.SaveChanges();
            var matriculas = new List<Matricula>()
            {
                new Matricula(){AlunoID=1, TreinamentoID=1, Grade=Grade.A, DataMatricula=DateTime.Parse("2010-01-01")},
                new Matricula(){AlunoID=1, TreinamentoID=2, Grade=Grade.B, DataMatricula=DateTime.Parse("2010-02-01")},
                new Matricula(){AlunoID=2, TreinamentoID=1, Grade=Grade.A, DataMatricula=DateTime.Parse("2010-01-02")},
                new Matricula(){AlunoID=2, TreinamentoID=2, Grade=Grade.B, DataMatricula=DateTime.Parse("2011-01-01")},
                new Matricula(){AlunoID=2, TreinamentoID=3, Grade=Grade.C, DataMatricula=DateTime.Parse("2011-02-01")},
                new Matricula(){AlunoID=3, TreinamentoID=3, Grade=Grade.D, DataMatricula=DateTime.Parse("2011-01-02")},

            };
            matriculas.ForEach(s => context.Matriculas.Add(s));
            context.SaveChanges();
        }
    }
}