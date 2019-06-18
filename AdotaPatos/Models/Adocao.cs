using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdotaPatos.Models
{
    public class Adocao
    {
        public long Id { get; set; }

        [Display(Name = "ClienteId")]
        public long AnimalId { get; set; }

        [Display(Name = "Nome do Adotante")]
        [Required(ErrorMessage = "* Campo Obrigatório!")]
        public string NomeDoAdotante { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = " * Campo obrigatório!")]
        public string RgAdotante { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = " * Campo obrigatório!")]
        public string CpfAdotante { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = " * Campo obrigatório!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataAdocao { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = " * Campo obrigatório!")]
        public string Telefone { get; set; }

        [Display(Name = "Profissão")]
        public string Profissao { get; set; }

        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Número")]
        public int numero { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        public Adocao(long id, string nomeAdotante, string rgAdotante, string cpfAdotante, DateTime dataAdocao, string telefone, string profissao, string logradouro, int numeroCasa, string estado, string cidade)
        {
            Id = id;
            NomeDoAdotante = nomeAdotante;
            RgAdotante = rgAdotante;
            CpfAdotante = cpfAdotante;
            DataAdocao = dataAdocao;
            Telefone = telefone;
            Profissao = profissao;
            Logradouro = logradouro;
            numero = numeroCasa;
            Estado = estado;
            Cidade = cidade;
        }

        public Adocao()
        {

        }
    }
}