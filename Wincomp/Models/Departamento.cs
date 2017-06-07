using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wincomp.Models
{
    public partial class Departamento
    {
        [Key]
        public int DepartamentoID { get; set; }
        [Display(Name = "Departamento")]
        public string DepartamentoNome { get; set; }
        public virtual ICollection<Departamento> Departamentos { get; set; }
        public virtual ICollection<Treinamento> Treinamentos { get; set; }
    }
}