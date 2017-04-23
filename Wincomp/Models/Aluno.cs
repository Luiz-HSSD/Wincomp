using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wincomp.Models
{
    public class Aluno
    {
        public int AlunoID { get; set; }
        public string NomeAluno { get; set; }
        public string Email { get; set; }
        public DateTime Data { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}