import { WorkoutExecutionState } from '../state';
import { WorkoutExecutionServerIdentityModel } from '../models/WorkoutExecutionServerIdentityModel';

export const deleteWorkoutExecutionThumbnail = (state: WorkoutExecutionState, payload: WorkoutExecutionServerIdentityModel) => {
    if (state.workoutExecutionsThumbnails != undefined) {
        state.workoutExecutionsThumbnails.payload = state.workoutExecutionsThumbnails?.payload?.filter(x => x.externalId != payload.externalId)
    }
}