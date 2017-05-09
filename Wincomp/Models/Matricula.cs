using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key]
        public int MatriculaID { get; set; }
        [ForeignKey("Treinamento")]
        public int TreinamentoID { get; set; }
        [ForeignKey("Aluno")]
        public int AlunoID { get; set; }
        public Grade? Grade { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataMatricula { get; set; }
        public virtual Treinamento Treinamento { get;set;}
        public virtual Aluno Aluno { get; set; }
        public virtual ICollection<Treinamento> Treinamentos { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}