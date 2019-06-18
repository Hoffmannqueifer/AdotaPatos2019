using AdotaPatos.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdotaPatos.DAO
{
    public class AnimalDAO : DAO
    {
        public void Salvar(Animal animal)
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                var query = @"insert into animal (IdAnimal, NomeAnimal, TipoAnimal, NomeVoluntario, LarTemporario, DataResgate, Sexo, Raca, Idade, TipoCastrado, ImagemAntes, ImagemDepois, Descricao)values(@IdAnimal, @NomeAnimal, @TipoAnimal, @NomeVoluntario, @LarTemporario, @DataResgate, @Sexo, @Raca, @Idade, @TipoCastrado, @ImagemAntes, @ImagemDepois, @Descricao)";
                sqlConnection.Execute(query, animal);
            }
        }

        public IEnumerable<Animal> Listar()
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                return sqlConnection.Query<Animal>(@"select IdAnimal, TipoAnimal, NomeAnimal, NomeVoluntario, TipoCastrado, DataResgate, Raca from animal");
            }
        }

        public Animal PorId(int id)
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                return sqlConnection.Query<Animal>(@"select IdAnimal, NomeAnimal, TipoAnimal, NomeVoluntario, LarTemporario, DataResgate, Sexo, Raca, Idade, TipoCastrado, ImagemAntes, ImagemDepois, Descricao from animal where AnimalId = @animalId", new { AnimalId = id }).First();
            }
        }

        public void Delete(int? id)
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                var query = @"delete from animal where IdAnimal = @IdAnimal";
                sqlConnection.Execute(query, new { AnimalId = id });
            }
        }

        public void Atualizar(Animal animal)
        {
            using (var sqlConnection = GetMySqlConnection())
            {
                var query = @"update animal set NomeAnimal = @NomeAnimal, TipoAnimal = @TipoAnimal, NomeVoluntario = @NomeVoluntario, LarTemporario = @LarTemporario, DataResgate = @DataResgate, Sexo = @sexo, Raca = @Raca, Idade = @Idade, TipoCastrado = @TipoCastrado, ImagemAntes = @ImagemAntes, ImagemDepois = @ImagemDepois, Descricao = @Descricao where IdAnimal = @IdAnimal";
                sqlConnection.Execute(query, animal);
            }
        }

        public IEnumerable<Animal> Search(string pesquisa)
        {

            using (var sqlConnection = GetMySqlConnection())
            {
                return sqlConnection.Query<Animal>("select IdAnimal, TipoAnimal, NomeAnimal, NomeVoluntario, TipoCastrado, DataResgate from animal where NomeAnimal like " +
                    "@nomeAnimal", new { NomeAnimal = pesquisa + "%" });

            }
        }
    }
}