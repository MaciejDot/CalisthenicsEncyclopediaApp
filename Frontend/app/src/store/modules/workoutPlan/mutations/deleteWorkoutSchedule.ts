import { WorkoutPlanState } from '../state';

export const deleteWorkoutSchedule = (state: WorkoutPlanState, externalId: string): any => {
    if (state.workoutSchedules !== undefined) {
        state.workoutSchedules.payload = state.workoutSchedules.payload?.filter(x => x.externalId !== externalId);
    }
}