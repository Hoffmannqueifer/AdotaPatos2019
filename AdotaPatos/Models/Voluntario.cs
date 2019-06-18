using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdotaPatos.Models
{
    public class Voluntario
    {
        public long Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Naturalidade")]
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public string Naturalidade { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public string Sexo { get; set; }

        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Rg")]
        public string Rg { get; set; }

        [Display(Name = "Cpf")]
        public string Cpf { get; set; }

        [Display(Name = "Profissão")]
        public string Profissao { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public string Endereco { get; set; }

        [Display(Name = "Cep")]
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public string Cep { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public string Cidade { get; set; }

        [Display(Name = "Uf")]
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public string Uf { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public string Telefone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "* Campo Obrigatório")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        [Display(Name = "Dia")]
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public string Dia { get; set; }

        [Display(Name = "Turno")]
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public string Turno { get; set; }

        [Display(Name = "Doação")]
        public string Doacao { get; set; }

        [Display(Name = "Serviço de Ajuda")]
        public string ServicoAjuda { get; set; }

        [Display(Name = "Observação. Ex: Dias extras..")]
        public string Observacao { get; set; }

        public Voluntario(long id, string nome, string naturalidade, string sexo, string estadoCivil, DateTime dataNascimento, string rg, string cpf, string profissao, string endereco, string cep, string cidade, string uf, string telefone, string email, string dia, string turno, string doacao, string servicoAjuda, string observacao)
        {
            Id = id;
            Nome = nome;
            Naturalidade = naturalidade;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
            DataNascimento = dataNascimento;
            Rg = rg;
            Cpf = cpf;
            Profissao = profissao;
            Endereco = endereco;
            Cep = cep;
            Cidade = cidade;
            Uf = uf;
            Telefone = telefone;
            Email = email;
            Dia = dia;
            Turno = turno;
            Doacao = doacao;
            ServicoAjuda = servicoAjuda;
            Observacao = observacao;
        }

        public Voluntario()
        {

        }
    }
}