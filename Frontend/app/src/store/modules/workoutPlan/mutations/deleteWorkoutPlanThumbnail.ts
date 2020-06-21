import { WorkoutPlanState } from '../state';
import { WorkoutPlanCacheModel } from '../models/WorkoutPlanCacheModel';
import Vue from 'vue';

export const deleteWorkoutPlanThumbnail = (state: WorkoutPlanState, externalId: string): any => {
    if (state.workoutPlansThumbnails !== undefined) {
        state.workoutPlansThumbnails.payload = state.workoutPlansThumbnails.payload
            ?.filter(x => x.externalId != externalId);
        Vue.set(state, 'workoutPlansThumbnails', state.workoutPlansThumbnails);
    }
}