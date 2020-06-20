import { WorkoutPlanState } from '../state';
import Vue from 'vue';

export const deleteWorkoutSchedule = (state: WorkoutPlanState, externalId: string): any => {
    if (state.workoutSchedules !== undefined) {
        state.workoutSchedules.payload = state.workoutSchedules.payload?.filter(x => x.externalId !== externalId);
        Vue.set(state, 'workoutSchedules', state.workoutSchedules);
    }
}