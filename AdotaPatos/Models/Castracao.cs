using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdotaPatos.Models
{
    public class Castracao
    {
        public long Id { get; set; }

        [Display(Name = "Nome do Evento")]
        [Required(ErrorMessage = " * Campo obrigatório!")]
        public string NomeEvento { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = " * Campo obrigatório!")]
        public DateTime Dia { get; set; }

        [Display(Name = "Tipo de Animais")]
        public string TipoAnimal { get; set; }

        public string Sexo { get; set; }

        public string Descricao { get; set; }

        [Display(Name = "Total de Castrações")]
        [Required(ErrorMessage = " * Campo obrigatório!")]
        public int Total { get; set; }

        public Castracao()
        {

        }

        public Castracao(long id, string nomeEvento, DateTime dia, string tipoAnimal, string sexo, string descricao, int total)
        {
            Id = id;
            NomeEvento = nomeEvento;
            Dia = dia;
            TipoAnimal = tipoAnimal;
            Sexo = sexo;
            Descricao = descricao;
            Total = total;
        }
    }
}