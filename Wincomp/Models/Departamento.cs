using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wincomp.Models
{
    public class Departamento
    {
        [Key]
        public int DepartamentoID { get; set; }
        [Display(Name ="Nome")]
        public string DepartamentoNome { get; set; }
        public virtual ICollection<Departamento> Departamentos { get; set; }
    }
}