import { WorkoutPlanState } from '../state';
import { WorkoutSchedulesCacheModel } from '../models/WorkoutSchedulesCacheModel';
import Vue from 'vue';

export const addOrUpdateWorkoutSchedule = (state: WorkoutPlanState, payload: WorkoutSchedulesCacheModel): any => {
    if (state.workoutSchedules !== undefined) {
        state.workoutSchedules.payload = state.workoutSchedules.payload?.filter(x => x.externalId !== payload.externalId);
        state.workoutSchedules.payload?.push(payload);
        Vue.set(state, 'workoutSchedules', state.workoutSchedules);
    }
}