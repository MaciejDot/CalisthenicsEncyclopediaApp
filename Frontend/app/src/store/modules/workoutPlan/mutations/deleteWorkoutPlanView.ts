import { WorkoutPlanState } from '../state';
import { WorkoutPlanIdentityModel } from '../models/WorkoutPlanIdentityModel';

export const deleteWorkoutPlanView = (state: WorkoutPlanState, payload : WorkoutPlanIdentityModel) : any =>
{
    if(state.workoutPlans==undefined || !state.workoutPlans.has(payload.username))
    {
        return;
    }
    state.workoutPlans.get(payload.username)?.delete(payload.externalId);
}