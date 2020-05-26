import { WorkoutExecutionState } from '../state';
import { WorkoutExecutionCacheModel } from '../models/WorkoutExecutionCacheModel';
import { CachedItemFromServer } from '@/store/models/cachedItemFromServer';
import { WorkoutExecutionsIdentityCacheModel } from '../models/WorkoutExecutionsIdentityCacheModel';

export const addOrUpdateWorkoutExecutions = (state: WorkoutExecutionState, payload: WorkoutExecutionsIdentityCacheModel) => {
    state.workoutExecutions = state.workoutExecutions ?? new Map<string, Map<string, CachedItemFromServer<WorkoutExecutionCacheModel>>>();
    state.workoutExecutions?.set(payload.username, payload.payload.reduce(function (map, obj) {
        map.set(obj.payload?.externalId ?? "", obj)
        return map;
    }, new Map<string, CachedItemFromServer<WorkoutExecutionCacheModel>>())
    )
}