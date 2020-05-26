import { WorkoutPlanState } from '../state';
import { CachedItemFromServer } from '@/store/models/cachedItemFromServer';
import { WorkoutSchedulesCacheModel } from '../models/WorkoutSchedulesCacheModel';

export const putWorkoutSchedules = (state: WorkoutPlanState, payload : CachedItemFromServer<Array<WorkoutSchedulesCacheModel>>) : any =>
{
    state.workoutSchedules = payload;
}