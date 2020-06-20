import { WorkoutPlanState } from '../state';
import { WorkoutPlanCacheThumbnailModel } from '../models/WorkoutPlanCacheThumbnailModel';
import { CachedItemFromServer } from '@/store/models/cachedItemFromServer';
import Vue from 'vue';

export const putWorkoutPlanThumbnails = (state: WorkoutPlanState, payload : CachedItemFromServer<Array<WorkoutPlanCacheThumbnailModel>>) : any =>
{
    state.workoutPlansThumbnails = payload;
    Vue.set(state,'workoutPlansThumbnails', state.workoutPlansThumbnails);
}