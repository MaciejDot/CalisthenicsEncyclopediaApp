import { WorkoutPlanState } from '../state';
import { WorkoutPlanCacheThumbnailModel } from '../models/WorkoutPlanCacheThumbnailModel';

export const addOrUpdateWorkoutPlanThumbnails = (state: WorkoutPlanState, payload : WorkoutPlanCacheThumbnailModel) : any =>
{
    if(state.workoutPlansThumbnails!==undefined)
    {
        state.workoutPlansThumbnails.payload = state.workoutPlansThumbnails.payload?.filter(x=>x.externalId != payload.externalId);
        state.workoutPlansThumbnails?.payload?.push(payload);
    }
}