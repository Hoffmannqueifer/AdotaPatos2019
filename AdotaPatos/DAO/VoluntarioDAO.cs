using AdotaPatos.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdotaPatos.DAO
{
    public class VoluntarioDAO : DAO
    {

        public void Salvar(Voluntario voluntario)
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                var query = @"insert into voluntario (Id, Nome, Naturalidade, Sexo, EstadoCivil, DataNascimento, Rg, Cpf, Profissao, Endereco, Cep, Cidade, Uf, Telefone, Email, Dia, Turno, Doacao, ServicoAjuda, Observacao)values(@Id, @Nome, @Naturalidade, @Sexo, @EstadoCivil, @DataNascimento, @Rg, @Cpf, @Profissao, @Endereco, @Cep, @Cidade, @Uf, @Telefone, @Email, @Dia, @Turno, @Doacao, @ServicoAjuda, @observacao)";
                sqlConnection.Execute(query, voluntario);
            }
        }

        public IEnumerable<Voluntario> Listar()
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                return sqlConnection.Query<Voluntario>(@"select Id, Nome, Telefone, Email, Dia, Turno, Observacao from voluntario");
            }
        }

        public Voluntario PorId(long id)
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                return sqlConnection.Query<Voluntario>(@"select Id, Nome, Naturalidade, Sexo, EstadoCivil, DataNascimento, Rg, Cpf, Profissao, Endereco, Cep, Cidade, Uf, Telefone, Email, Dia, Turno, ServicoAjuda, Doacao, Observacao from voluntario where Id = @id", new { Id = id }).First();
            }
        }

        public void Delete(long? id)
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                var query = @"delete from voluntario where Id = @id";
                sqlConnection.Execute(query, new { Id = id });
            }
        }

        public void Atualizar(Voluntario voluntario)
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                var query = @"update voluntario set Nome = @Nome, Naturalidade = @Naturalidade, Sexo = @Sexo, EstadoCivil = @EstadoCivil, DataNascimento = @DataNascimento, Rg = @Rg, Cpf = @Cpf, Profissao = @Profissao, Endereco = @Endereco, Cep = @Cep, Cidade = @Cidade, Uf = @Uf, Telefone = @Telefone, Email = @Email, Dia = @Dia, Turno = @Turno, ServicoAjuda = @ServicoAjuda, Doacao = @Doacao, Observacao = @Observacao where Id = @Id";
                sqlConnection.Execute(query, voluntario);
            }
        }

        public IEnumerable<Voluntario> Search(string pesquisa)
        {

            using (var sqlConnection = GetMySqlConnection())
            {
                return sqlConnection.Query<Voluntario>("select Id, Nome, Telefone, Email, Dia, Turno from voluntario where Nome like " +
                    "@nome", new { Nome = pesquisa + "%" });

            }
        }
    }
}