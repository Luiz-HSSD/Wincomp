using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wincomp.Models
{
    public class Aluno
    {
        public int AlunoID { get; set; }
        public string NomeAluno { get; set; }
        public string Email { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime Data { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}