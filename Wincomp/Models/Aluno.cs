using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wincomp.Models
{
    public class Aluno
    {
        [Key]
        public int AlunoID { get; set; }
        [Required]
        [Column("Nome")]
        [StringLength(40, ErrorMessage = "Nome não pode ter mais de 40 caracteres")]
        [Display(Name = "Nome")]
        public string NomeAluno { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime Data { get; set; }
        [StringLength(50, ErrorMessage = "Sobrenome não pode ter mais de 40 caracteres",MinimumLength =2)]
        public string SobrenomeAluno { get; set; }
        public string Nomecompleto
        {
            get
            {
                return NomeAluno + ", " + SobrenomeAluno;
            }
        }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}