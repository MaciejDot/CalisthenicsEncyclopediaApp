import { WorkoutExecutionState } from '../state';
import { WorkoutExecutionCacheModel } from '../models/WorkoutExecutionCacheModel';
import { CachedItemFromServer } from '@/store/models/cachedItemFromServer';

export const putWorkoutExecutionThumbnails = (state: WorkoutExecutionState, payload:CachedItemFromServer<Array< WorkoutExecutionCacheModel>>) => {
    state.workoutExecutionsThumbnails = payload;
}