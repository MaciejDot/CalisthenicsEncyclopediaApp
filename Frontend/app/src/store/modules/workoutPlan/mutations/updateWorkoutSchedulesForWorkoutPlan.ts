import { WorkoutPlanState } from '../state';
import { WorkoutPlanScheduleIdentityModel } from '../models/WorkoutPlanScheduleIdentityModel';
import Vue from 'vue';

export const updateWorkoutSchedulesForWorkoutPlan = (state: WorkoutPlanState, model: WorkoutPlanScheduleIdentityModel): any => {
    if (state.workoutSchedules !== undefined) {
        const otherWorkouts = state.workoutSchedules.payload?.filter(x => x.workoutPlanExternalId != model.externalId);
        const workoutsForUpdate = state.workoutSchedules.payload?.filter(x => x.workoutPlanExternalId == model.externalId);
        workoutsForUpdate?.forEach(x => {
            x.workoutPlanName = model.workoutPlanName
            otherWorkouts?.push(x);
        }
        );
        state.workoutSchedules.payload = otherWorkouts;
        Vue.set(state, 'workoutSchedules', state.workoutSchedules);
    }
}