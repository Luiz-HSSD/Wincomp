using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wincomp.Models
{
    public class Treinamento
    {
        [Key]
        public int TreinamentoID {get; set;}
        [ForeignKey("Departamento")]
        public int DepartamentoID { get; set; }
        [Display(Name = "Treinamento")]
        public string Titulo  {get; set;}
        [Display(Name ="Créditos")]
        public int Creditos {get; set;}
        public virtual ICollection<Matricula> Matriculas { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}