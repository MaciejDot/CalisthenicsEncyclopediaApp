import { defineMutations } from 'direct-vuex';
import { WorkoutExecutionState } from '../state';
import { addOrUpdateWorkoutExecution } from './addOrUpdateWorkoutExecution';
import { addOrUpdateWorkoutExecutions } from './addOrUpdateWorkoutExecutions';
import { putWorkoutExecutionThumbnails } from './putWorkoutExecutionThumbnails';
import { deleteWorkoutExecutionThumbnail } from './deleteWorkoutExecutionThumbnail';
import { deleteWorkoutExecution } from './deleteWorkoutExecution';
import { addOrUpdateWorkoutExecutionThumbnail } from './addOrUpdateWorkoutExecutionThumbnail';

export const mutations = defineMutations<WorkoutExecutionState>()
({
    addOrUpdateWorkoutExecution,
    addOrUpdateWorkoutExecutions,
    putWorkoutExecutionThumbnails,
    deleteWorkoutExecutionThumbnail,
    deleteWorkoutExecution,
    addOrUpdateWorkoutExecutionThumbnail
})