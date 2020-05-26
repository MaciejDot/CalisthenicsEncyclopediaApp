import { WorkoutPlanState } from '../state';
import { WorkoutPlanCacheThumbnailModel } from '../models/WorkoutPlanCacheThumbnailModel';

export const deleteWorkoutPlanThumbnail = (state: WorkoutPlanState, externalId : string) : any =>
{
    if(state.workoutPlansThumbnails!==undefined)
    {
        state.workoutPlansThumbnails.payload = state.workoutPlansThumbnails.payload?.filter(x=>x.externalId != externalId);
    }
}