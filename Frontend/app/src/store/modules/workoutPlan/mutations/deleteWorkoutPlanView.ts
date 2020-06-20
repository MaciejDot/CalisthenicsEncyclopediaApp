import { WorkoutPlanState } from '../state';
import { WorkoutPlanIdentityModel } from '../models/WorkoutPlanIdentityModel';
import Vue from 'vue';

export const deleteWorkoutPlanView = (state: WorkoutPlanState, payload: WorkoutPlanIdentityModel): any => {
    if (state.workoutPlans != undefined && state.workoutPlans.has(payload.username)) {

        state.workoutPlans.get(payload.username)?.delete(payload.externalId);
        Vue.set(state, 'workoutPlans', state.workoutPlans);
    }
}