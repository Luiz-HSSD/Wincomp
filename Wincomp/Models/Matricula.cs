using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wincomp.Models
{
    public enum Grade
    {
        A,B,C,D,F
    }
    public class Matricula
    {
        public int MatriculaID { get; set; }
        public int TreinamentoID { get; set; }
        public int AlunoID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Treinamento Treinamento { get;set;}
        public virtual Aluno Aluno { get; set; }
    }
}