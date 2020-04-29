using CacheManager.Core;
using Dapper;
using ExerciseService.DataAccessPoint.Cache;
using ExerciseService.DataAccessPoint.Database;
using System.Threading;
using System.Threading.Tasks;

namespace ExerciseService.DataAccessPoint.Jobs
{
    public class UpdateExercisesJob : IUpdateExercisesJob
    {

        private static bool alreadyRunning = false;
        private readonly IDatabaseAccessService _databaseAccessService;
        private readonly ICacheAccessService _cacheAccessService;
        public UpdateExercisesJob(
            IDatabaseAccessService databaseAccessService,
            ICacheAccessService cacheAccessService)
        {
            _databaseAccessService = databaseAccessService;
            _cacheAccessService = cacheAccessService;
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            if (!alreadyRunning)
            {
                alreadyRunning = true;
                try
                {
                    await GetItemFromDatabaseAndSaveToCache();
                }
                finally
                {
                    alreadyRunning = false;
                }
            }
        }

        private async Task GetItemFromDatabaseAndSaveToCache() {
            var exercises = await _databaseAccessService.GetAllExercises();
            _cacheAccessService.SetExercises(exercises);
        }

    }
}
