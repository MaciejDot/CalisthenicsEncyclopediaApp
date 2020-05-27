import { WorkoutPlanState } from '../state';
import { WorkoutPlanScheduleIdentityModel } from '../models/WorkoutPlanScheduleIdentityModel';

export const updateWorkoutSchedulesForWorkoutPlan = (state: WorkoutPlanState, model: WorkoutPlanScheduleIdentityModel) : any =>
{
    if (state.workoutSchedules !== undefined) {
        let otherWorkouts = state.workoutSchedules.payload?.filter(x => x.workoutPlanExternalId != model.externalId);
        let workoutsForUpdate = state.workoutSchedules.payload?.filter(x => x.workoutPlanExternalId == model.externalId);
        workoutsForUpdate?.forEach(x => {
            x.workoutPlanName = model.workoutPlanName
            otherWorkouts?.push(x);
        }
        );
        state.workoutSchedules.payload = otherWorkouts;
    }
}