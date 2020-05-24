import { CachedItemFromServer } from "../../../models/cachedItemFromServer";
import { WorkoutPlanCacheModel } from "../models/WorkoutPlanCacheModel";
import { WorkoutPlanCacheThumbnailModel } from '../models/WorkoutPlanCacheThumbnailModel';
export interface WorkoutPlanState {
    workoutPlans? : Map<string, Map<string, CachedItemFromServer<WorkoutPlanCacheModel>>>
    workoutPlansThumbnails? : CachedItemFromServer<Array<WorkoutPlanCacheThumbnailModel>>
}