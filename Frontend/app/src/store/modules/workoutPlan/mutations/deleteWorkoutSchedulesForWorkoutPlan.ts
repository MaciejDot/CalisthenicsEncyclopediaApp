import { WorkoutPlanState } from '../state';
import { WorkoutPlanScheduleIdentityModel } from '../models/WorkoutPlanScheduleIdentityModel';
import Vue from 'vue'

export const deleteWorkoutSchedulesForWorkoutPlan = (state: WorkoutPlanState, externalId: string): any => {
    if (state.workoutSchedules !== undefined) {
        state.workoutSchedules.payload = state.workoutSchedules.payload?.filter(x => x.workoutPlanExternalId != externalId);
        Vue.set(state,'workoutSchedules', state.workoutSchedules);
    }
}