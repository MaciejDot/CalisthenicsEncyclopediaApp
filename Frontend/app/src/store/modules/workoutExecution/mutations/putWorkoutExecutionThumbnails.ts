import { WorkoutExecutionState } from '../state';
import { WorkoutExecutionCacheModel } from '../models/WorkoutExecutionCacheModel';
import { CachedItemFromServer } from '@/store/models/cachedItemFromServer';
import Vue from 'vue';

export const putWorkoutExecutionThumbnails = (state: WorkoutExecutionState, payload:CachedItemFromServer<Array< WorkoutExecutionCacheModel>>) => {
    state.workoutExecutionsThumbnails = payload;
    Vue.set(state, 'workoutExecutionsThumbnails', state.workoutExecutionsThumbnails);
}