import { WorkoutPlanState } from '../state';
import { WorkoutPlanScheduleIdentityModel } from '../models/WorkoutPlanScheduleIdentityModel';

export const deleteWorkoutSchedulesForWorkoutPlan = (state: WorkoutPlanState, externalId: string): any => {
    if (state.workoutSchedules !== undefined) {
        state.workoutSchedules.payload = state.workoutSchedules.payload?.filter(x => x.workoutPlanExternalId != externalId);
    }
}