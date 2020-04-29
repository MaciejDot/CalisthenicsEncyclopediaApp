using Dapper;
using ExerciseService.DataAccessPoint.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseService.DataAccessPoint.Database
{
    public class DatabaseAccessService : IDatabaseAccessService
    {
        private readonly SqlConnection _sqlConnection;

        public DatabaseAccessService(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public Task<IEnumerable<RepositoryExerciseDTO>> GetAllExercises()
        {
            return _sqlConnection
                        .QueryAsync<RepositoryExerciseDTO>("Workout.[sp_exercise_getAll]");
        }
    }
}
