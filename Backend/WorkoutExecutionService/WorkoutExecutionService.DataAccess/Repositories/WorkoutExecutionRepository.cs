using CacheManager.Core;
using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Cache;
using WorkoutExecutionService.DataAccess.Database.Query;
using WorkoutExecutionService.DataAccess.DTO;
using WorkoutExecutionService.DataAccess.Hangfire;
using WorkoutExecutionService.DataAccess.Jobs;

namespace WorkoutExecutionService.DataAccess.Repositories
{
    public sealed class WorkoutExecutionRepository : IWorkoutExecutionRepository
    {
        private readonly IWorkoutExecutionCacheService _workoutExecutionCacheService;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IFatiguesRepository _fatiguesRepository;
        private readonly IMoodsRepository _moodsRepository;
        private readonly IQueryProcessor _queryProcessor;
        private readonly IBackgroundJobClientService _backgroundJobClientService;

        public WorkoutExecutionRepository(
            IWorkoutExecutionCacheService workoutExecutionCacheService,
            IFatiguesRepository fatiguesRepository,
            IMoodsRepository moodsRepository,
            IUserRepository userRepository,
            IExerciseRepository exerciseRepository,
            IBackgroundJobClientService backgroundJobClientService,
            IQueryProcessor queryProcessor)
        {
            _moodsRepository = moodsRepository;
            _fatiguesRepository = fatiguesRepository;
            _workoutExecutionCacheService = workoutExecutionCacheService;
            _exerciseRepository = exerciseRepository;
            _userRepository = userRepository;
            _backgroundJobClientService = backgroundJobClientService;
            _queryProcessor = queryProcessor;
        }

        public async Task AddWorkoutPlanAsync(string username, WorkoutExecutionDTO workout)
        {
            await ValidateWorkout(workout);
            await _userRepository.AddUserIfNotExists(username);
            AddWorkoutPlanToCache(username, workout);
            _backgroundJobClientService.Enqueue<IAddWorkoutExecutionJob>(x => x.Run(username, workout));
        }

        public async Task UpdateWorkoutPlanAsync(string username, WorkoutExecutionDTO workout)
        {

            await ValidateWorkout(workout);
            if (!await UserWorkoutPlanExistsAsync(username, workout.ExternalId))
            {
                throw new Exception("there is no such workout");
            };
            UpdateWorkoutInCache(username, workout);
            _backgroundJobClientService.Enqueue<IUpdateWorkoutExecutionJob>(x => x.Run(username, workout));
        }

        public async Task DeleteWorkoutPlanAsync(string username, Guid externalId)
        {
            if (!await UserWorkoutPlanExistsAsync(username, externalId))
            {
                throw new Exception("there is no such workout");
            };
            DeleteWorkoutFromCache(username, externalId);
            _backgroundJobClientService.Enqueue<IDeleteWorkoutExecutionJob>(x => x.Run(username, externalId));
        }

        private void AddWorkoutPlanToCache(string username, WorkoutExecutionDTO workout)
        {
            var saveWorkouts = _workoutExecutionCacheService.Get(username)?.Value.ToList() ??
                new List<WorkoutExecutionDTO>();
            saveWorkouts.Add(workout);
            _workoutExecutionCacheService.Put(username, saveWorkouts);
        }

        private void DeleteWorkoutFromCache(string username, Guid externalId)
        {
            var workouts = _workoutExecutionCacheService.Get(username).Value;
            _workoutExecutionCacheService.Put(username, workouts.Where(x => x.ExternalId != externalId));
        }

        private void UpdateWorkoutInCache(string username, WorkoutExecutionDTO workout)
        {
            var workouts = _workoutExecutionCacheService.Get(username).Value;
            var saveWorkouts = workouts.Where(x => x.ExternalId != workout.ExternalId)
                .ToList();
            saveWorkouts.Add(workout);
            _workoutExecutionCacheService.Put(username, saveWorkouts);
        }

        public Task<IEnumerable<WorkoutExecutionDTO>> GetAllUserWorkutPlansAsync(string username)
        {
            var cachedItem = _workoutExecutionCacheService.Get(username);
            return HandleReturnedCacheItem(cachedItem, username);
        }

        private async Task<IEnumerable<WorkoutExecutionDTO>> HandleReturnedCacheItem(CacheItem<IEnumerable<WorkoutExecutionDTO>> cachedItem, string username)
        {
            if (cachedItem == null)
            {
                return await HandleNullCacheItem(username);
            }
            else
            {
                return cachedItem.Value;
            }
        }

        private async Task<IEnumerable<WorkoutExecutionDTO>> HandleNullCacheItem(string username)
        {
            var workoutsFromDatabase = await _queryProcessor.Process(new GetWorkoutsExecutionsQuery { Username = username }, default);
            _workoutExecutionCacheService.Put(username, workoutsFromDatabase);
            return workoutsFromDatabase;
        }

        private Task ValidateWorkout(WorkoutExecutionDTO workoutExecutionDTO)
        {
            return Task.WhenAll(ValidateExercisesAsync(workoutExecutionDTO), ValidateFatigue(workoutExecutionDTO), ValidateMood(workoutExecutionDTO));
        }

        private async Task ValidateMood(WorkoutExecutionDTO workoutExecutionDTO)
        {
            var moods = await _moodsRepository.GetAll();
            if (moods.Any(mood => mood.Id == workoutExecutionDTO.MoodId))
            {
                throw new Exception("That mood does not exist");
            }
        }

        private async Task ValidateFatigue(WorkoutExecutionDTO workoutExecutionDTO)
        {
            var fatigues = await _fatiguesRepository.GetAll();
            if (fatigues.Any(fatigue => fatigue.Id == workoutExecutionDTO.FatigueId))
            {
                throw new Exception("That fatigue does not exist");
            }
        }

        private async Task ValidateExercisesAsync(WorkoutExecutionDTO workoutExecutionDTO)
        {
            ValidateExerciseOrder(workoutExecutionDTO);
            await ValidateExercisesNamesAsync(workoutExecutionDTO);
        }

        private async Task ValidateExercisesNamesAsync(WorkoutExecutionDTO workoutExecutionDTO)
        {
            var exercises = await _exerciseRepository.GetAllExercisesAsync();
            if (!workoutExecutionDTO.Exercises.All(x => exercises.Any(y => y.Id == x.ExerciseId && y.Name == x.ExerciseName)))
            {
                throw new Exception("Invalid Exercises");
            };
        }

        private void ValidateExerciseOrder(WorkoutExecutionDTO workoutExecutionDTO)
        {
            if (workoutExecutionDTO.Exercises.Count()
                != workoutExecutionDTO.Exercises.Select(x => x.Order).Distinct().Count())
            {
                throw new Exception("Orders are not distinct");
            }
        }

        private async Task<bool> UserWorkoutPlanExistsAsync(string username, Guid externalId)
        {
            var workouts = await GetAllUserWorkutPlansAsync(username);
            return workouts.Any(x => x.ExternalId == externalId);
        }
    }
}
