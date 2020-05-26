import { CachedItemFromServer } from "../../../models/cachedItemFromServer";
import { WorkoutPlanCacheModel } from "../models/WorkoutPlanCacheModel";
import { WorkoutPlanCacheThumbnailModel } from '../models/WorkoutPlanCacheThumbnailModel';
import { WorkoutSchedulesCacheModel } from '../models/WorkoutSchedulesCacheModel';
export interface WorkoutPlanState {
    workoutPlans? : Map<string, Map<string, CachedItemFromServer<WorkoutPlanCacheModel>>>
    workoutPlansThumbnails? : CachedItemFromServer<Array<WorkoutPlanCacheThumbnailModel>>
    workoutSchedules?: CachedItemFromServer<Array<WorkoutSchedulesCacheModel>>
}