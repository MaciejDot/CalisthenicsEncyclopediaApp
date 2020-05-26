import { WorkoutPlanCacheIdentityModel } from '../models/WorkoutPlanCacheIdentityModel';
import { WorkoutPlanState } from '../state';
import { CachedItemFromServer } from '@/store/models/cachedItemFromServer';
import { WorkoutPlanCacheModel } from '../models/WorkoutPlanCacheModel';

export const addOrUpdateWorkoutPlanView = (state: WorkoutPlanState, payload : WorkoutPlanCacheIdentityModel) : any =>
{
    state.workoutPlans = state.workoutPlans ?? new Map<string, Map<string, CachedItemFromServer<WorkoutPlanCacheModel>>>();
    if(!state.workoutPlans.has(payload.username))
    {
        state.workoutPlans.set(payload.username, new Map<string, CachedItemFromServer<WorkoutPlanCacheModel>>());
    }
    state.workoutPlans.get(payload.username)?.set(payload.externalId, payload.workoutPlan);
}