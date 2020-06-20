import { WorkoutExecutionState } from '../state';
import { WorkoutExecutionServerIdentityModel } from '../models/WorkoutExecutionServerIdentityModel';
import Vue from 'vue';

export const deleteWorkoutExecutionThumbnail = (state: WorkoutExecutionState, payload: WorkoutExecutionServerIdentityModel) => {
    if (state.workoutExecutionsThumbnails != undefined) {
        state.workoutExecutionsThumbnails.payload = state.workoutExecutionsThumbnails?.payload?.filter(x => x.externalId != payload.externalId)
        Vue.set(state, 'workoutExecutionsThumbnails', state.workoutExecutionsThumbnails);
    }
}