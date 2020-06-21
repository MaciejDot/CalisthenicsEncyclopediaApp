import { CachedItemFromServer } from "../../../models/cachedItemFromServer";
import { WorkoutPlanCacheModel } from "../models/WorkoutPlanCacheModel";
import { WorkoutSchedulesCacheModel } from '../models/WorkoutSchedulesCacheModel';
export interface WorkoutPlanState {
    workoutPlans? : Map<string, Map<string, CachedItemFromServer<WorkoutPlanCacheModel>>>
    workoutPlansThumbnails? : CachedItemFromServer<Array<WorkoutPlanCacheModel>>
    workoutSchedules?: CachedItemFromServer<Array<WorkoutSchedulesCacheModel>>
}