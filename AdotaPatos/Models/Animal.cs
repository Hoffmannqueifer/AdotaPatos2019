using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdotaPatos.Models
{
    public class Animal
    {
        public long IdAnimal { get; set; }

        [Display(Name = "Nome do Animal")]
        public string NomeAnimal { get; set; }

        [Display(Name = "Tipo Animal")]
        [Required(ErrorMessage = " * Campo obrigatório!")]
        public string TipoAnimal { get; set; }

        [Display(Name = "Nome do Voluntario")]
        [Required(ErrorMessage = " * Campo obrigatório!")]
        public string NomeVoluntario { get; set; }

        [Display(Name = "Lar Temporario")]
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public string LarTemporario { get; set; }

        [Required(ErrorMessage = "* Campo Obrigatório")]
        [Display(Name = "Data de Resgate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataResgate { get; set; }

        [Display(Name = "Sexo do Animal")]
        [Required(ErrorMessage = " * Campo obrigatório!")]
        public string Sexo { get; set; }

        [Display(Name = "Raça do Animal")]
        public string Raca { get; set; }

        //[Display(Name = "Idade do Animal")]
        public int Idade { get; set; }

        [Display(Name = "Castrado?")]
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public string TipoCastrado { get; set; }

        public string ImagemAntes { get; set; }

        public string ImagemDepois { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}