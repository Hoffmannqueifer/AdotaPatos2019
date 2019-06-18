using AdotaPatos.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdotaPatos.DAO
{
    public class AdocaoDAO : DAO
    {

        public void Salvar(Adocao adocao)
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                var query = @"insert into adocao (Id, AnimalId, NomeDoAdotante, RgAdotante, CpfAdotante, DataAdocao, Telefone, Profissao, Logradouro, numero, Estado, Cidade)values(@Id, @AnimalId, @NomeDoAdotante, @RgAdotante, @CpfAdotante, @DataAdocao, @Telefone, @Profissao, @Logradouro, @numero, @Estado, @Cidade)";
                sqlConnection.Execute(query, adocao);
            }
        }

        public IEnumerable<Adocao> Listar()
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                return sqlConnection.Query<Adocao>(@"select Id, NomeDoAdotante, RgAdotante, CpfAdotante, DataAdocao, Telefone, Profissao, Logradouro, numero, Estado, Cidade from adocao");
            }
        }

        public Adocao PorId(long id)
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                return sqlConnection.Query<Adocao>(@"select Id, NomeDoAdotante, RgAdotante, CpfAdotante, DataAdocao, Telefone, Profissao, Logradouro, numero, Estado, Cidade from adocao where Id = @id", new { Id = id }).First();
            }
        }

        public void Delete(long? id)
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                var query = @"delete from adocao where Id = @id";
                sqlConnection.Execute(query, new { Id = id });
            }
        }

        public void Atualizar(Adocao adocao)
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                var query = @"update adocao set NomeDoAdotante = @NomeDoAdotante, RgAdotante = @RgAdotante, CpfAdotante = @CpfAdotante, DataAdocao = @DataAdocao, Telefone = @Telefone, Profissao = @Profissao, Logradouro = @Logradouro, numero = @numero, Estado = @Estado, Cidade = @Cidade where Id = @Id";
                sqlConnection.Execute(query, adocao);
            }
        }

        public IEnumerable<Adocao> Search(string pesquisa)
        {

            using (var sqlConnection = GetMySqlConnection())
            {
                return sqlConnection.Query<Adocao>("select Id, NomeDoAdotante, RgAdotante, CpfAdotante, DataAdocao, Telefone, Profissao, Logradouro, numero, Estado, Cidade from adocao where NomeDoAdotante like " +
                    "@NomeDoAdotante", new { NomeDoAdotante = pesquisa + "%" });

            }
        }
    }
}