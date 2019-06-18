using AdotaPatos.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdotaPatos.DAO
{
    public class CastracaoDAO : DAO
    {
        public void Salvar(Castracao castracao)
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                var query = @"insert into Castracao (Id, NomeEvento, Dia, TipoAnimal, Sexo, Descricao, Total) values(@Id, @NomeEvento, @Dia, @TipoAnimal, @Sexo, @Descricao, @Total)";
                sqlConnection.Execute(query, castracao);
            }
        }

        public IEnumerable<Castracao> Listar()
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                return sqlConnection.Query<Castracao>(@"select Id, NomeEvento,  Dia, TipoAnimal, Sexo, Descricao, Total from castracao");
            }
        }

        public Castracao PorId(long Idcastracao)
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                return sqlConnection.Query<Castracao>(@"select  Id, NomeEvento, Dia, TipoAnimal, Sexo, Descricao, Total from castracao where Id = @Id", new { Id = Idcastracao }).First();
            }
        }

        public void Delete(long? Idcastracao)
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                var query = @"delete from Castracao where Id = @Id";
                sqlConnection.Execute(query, new { Id = Idcastracao });
            }
        }

        public void Atualizar(Castracao castracao)
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                var query = @"update castracao set NomeEvento = @NomeEvento, Dia =@Dia, TipoAnimal = @TipoAnimal, Sexo= @Sexo, Descricao=@descricao, Total = @Total where Id = @Id";
                sqlConnection.Execute(query, castracao);
            }
        }

        public IEnumerable<Castracao> Search(string pesquisa)
        {

            using (var sqlConnection = GetMySqlConnection())
            {
                return sqlConnection.Query<Castracao>("select Id, NomeEvento, Dia, TipoAnimal, Sexo, Descricao, Total from castracao where NomeEvento like " +
                    "@NomeEvento", new { NomeEvento = pesquisa + "%" });

            }
        }
    }
}