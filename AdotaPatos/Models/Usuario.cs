using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdotaPatos.Models {
    public class Usuario {

        public long Id { get; set; }
        [Required(ErrorMessage = " * Campo obrigatório!")]
        [StringLength(10, MinimumLength = 3, ErrorMessage ="Tamanho mínimo 3 caracteres e máximo 10")]
        public string Login { get; set; }

        [Required(ErrorMessage = " * Campo obrigatório!")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Tamanho mínimo 6 e máximo 10")]
        public string Senha { get; set; }

        [Required(ErrorMessage = " * Campo obrigatório!")]
        public string Cargo { get; set; }


        public Usuario(long id, string login, string cargo, string senha) {
            Id = id;
            Login = login;
            Cargo = cargo;
            Senha = senha;
        }

        public Usuario() {

        }
    }
}