import { WorkoutPlanState } from '../state';
import { WorkoutPlanCacheThumbnailModel } from '../models/WorkoutPlanCacheThumbnailModel';
import { CachedItemFromServer } from '@/store/models/cachedItemFromServer';

export const putWorkoutPlanThumbnails = (state: WorkoutPlanState, payload : CachedItemFromServer<Array<WorkoutPlanCacheThumbnailModel>>) : any =>
{
    state.workoutPlansThumbnails = payload;
}