import {WorkoutPlanCacheModel} from "./WorkoutPlanCacheModel";
import { CachedItemFromServer } from '@/store/models/cachedItemFromServer';
export interface WorkoutPlanCacheIdentityModel
{
    workoutPlan : CachedItemFromServer<WorkoutPlanCacheModel>
    username : string,
    workoutId : string
}