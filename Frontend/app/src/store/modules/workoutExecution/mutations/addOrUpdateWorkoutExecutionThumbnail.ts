import { WorkoutExecutionState } from '../state';
import { WorkoutExecutionCacheModel } from '../models/WorkoutExecutionCacheModel';
import Vue from 'vue';

export const addOrUpdateWorkoutExecutionThumbnail = (state: WorkoutExecutionState, payload: WorkoutExecutionCacheModel) => 
    {
        if (state.workoutExecutionsThumbnails !== undefined) {
            state.workoutExecutionsThumbnails.payload = state.workoutExecutionsThumbnails.payload?.filter(x=>x.externalId!== payload.externalId);
            state.workoutExecutionsThumbnails?.payload?.push(payload);
            Vue.set(state, 'workoutExecutionsThumbnails', state.workoutExecutionsThumbnails);
        }
    }