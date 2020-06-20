import { WorkoutExecutionState } from '../state';
import { WorkoutExecutionIdentityModel } from '../models/WorkoutExecutionIdentityModel';
import Vue from 'vue';

export const deleteWorkoutExecution = (state: WorkoutExecutionState, payload: WorkoutExecutionIdentityModel) => {
    state.workoutExecutions?.get(payload.username)?.delete(payload.externalId)
    Vue.set(state, 'workoutExecutions', state.workoutExecutions);
}