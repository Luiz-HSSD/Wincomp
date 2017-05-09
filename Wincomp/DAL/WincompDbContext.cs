using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Wincomp.Models;

namespace Wincomp.DAL
{
    public class WincompDbContext:DbContext
    {
        public WincompDbContext() : base("WincompDbContext")
        {

        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Treinamento> Treinamentos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}