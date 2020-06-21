import { WorkoutPlanState } from '../state';
import { WorkoutPlanCacheModel } from '../models/WorkoutPlanCacheModel';
import { CachedItemFromServer } from '@/store/models/cachedItemFromServer';
import Vue from 'vue';

export const putWorkoutPlanThumbnails = (state: WorkoutPlanState, payload : CachedItemFromServer<Array<WorkoutPlanCacheModel>>) : any =>
{
    Vue.set(state,'workoutPlansThumbnails', payload);
}