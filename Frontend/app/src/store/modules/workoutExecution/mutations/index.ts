import { defineMutations } from 'direct-vuex';
import { WorkoutExecutionState } from '../state';
import { addOrUpdateWorkoutExecution } from './addOrUpdateWorkoutExecution';
import { addOrUpdateWorkoutExecutions } from './addOrUpdateWorkoutExecutions';
import { putWorkoutExecutionThumbnails } from './putWorkoutExecutionThumbnails';

export const mutations = defineMutations<WorkoutExecutionState>()
({
    addOrUpdateWorkoutExecution,
    addOrUpdateWorkoutExecutions,
    putWorkoutExecutionThumbnails
})