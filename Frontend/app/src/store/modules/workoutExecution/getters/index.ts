import { WorkoutExecutionState } from "../state";
import { defineGetters } from 'direct-vuex';
import { isCachedItemFromServerExpired } from '@/store/functions/isCachedItemFromServerExpired';
import { WorkoutExecutionCacheModel } from '../models/WorkoutExecutionCacheModel';

export const getters = defineGetters<WorkoutExecutionState>()({
    workoutExecutionsThumbnails(state): WorkoutExecutionCacheModel[] | undefined {
        return !isCachedItemFromServerExpired(state.workoutExecutionsThumbnails) ?
            state.workoutExecutionsThumbnails?.payload : 
            undefined;
    }
});