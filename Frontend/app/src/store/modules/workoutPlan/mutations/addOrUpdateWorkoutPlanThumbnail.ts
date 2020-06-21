import { WorkoutPlanState } from '../state';
import { WorkoutPlanCacheModel } from '../models/WorkoutPlanCacheModel';
import Vue from 'vue';
export const addOrUpdateWorkoutPlanThumbnails = (state: WorkoutPlanState, payload : WorkoutPlanCacheModel) : any =>
{
    if(state.workoutPlansThumbnails!==undefined)
    {
        state.workoutPlansThumbnails.payload = state.workoutPlansThumbnails.payload?.filter(x=>x.externalId != payload.externalId);
        state.workoutPlansThumbnails?.payload?.push(payload);
        Vue.set(state,'workoutPlansThumbnails', state.workoutPlansThumbnails);
    }
}