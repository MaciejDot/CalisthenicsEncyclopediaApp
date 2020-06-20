import { WorkoutExecutionState } from '../state';
import { WorkoutExecutionCacheModel } from '../models/WorkoutExecutionCacheModel';
import { CachedItemFromServer } from '@/store/models/cachedItemFromServer';
import { WorkoutExecutionIdentityCacheModel } from '../models/WorkoutExecutionIdentityCacheModel';
import Vue from 'vue';

export const addOrUpdateWorkoutExecution = (state: WorkoutExecutionState, payload: WorkoutExecutionIdentityCacheModel) => {
    state.workoutExecutions = state.workoutExecutions ?? new Map<string, Map<string, CachedItemFromServer<WorkoutExecutionCacheModel>>>();
    state.workoutExecutions?.set(payload.username, state.workoutExecutions?.get(payload.username) ?? new Map<string, CachedItemFromServer<WorkoutExecutionCacheModel>>());
    state.workoutExecutions?.get(payload.username)?.set(payload.externalId, payload.payload);
    Vue.set(state, 'workoutExecutions', state.workoutExecutions);
}