import { WorkoutExecutionCacheModel } from '../models/WorkoutExecutionCacheModel';
import { CachedItemFromServer } from '@/store/models/cachedItemFromServer';

export interface WorkoutExecutionState
{
    workoutExecutions? : Map<string, Map<string, CachedItemFromServer<WorkoutExecutionCacheModel>>>
    workoutExecutionsThumbnails? : CachedItemFromServer<Array<WorkoutExecutionCacheModel>>
}