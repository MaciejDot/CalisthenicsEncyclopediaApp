import { WorkoutExecutionState } from '../state';
import { WorkoutExecutionIdentityModel } from '../models/WorkoutExecutionIdentityModel';

export const deleteWorkoutExecution = (state: WorkoutExecutionState, payload: WorkoutExecutionIdentityModel) => {
    state.workoutExecutions?.get(payload.username)?.delete(payload.externalId)
}