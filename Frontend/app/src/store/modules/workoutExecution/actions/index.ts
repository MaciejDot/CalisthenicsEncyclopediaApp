import { defineActions } from 'direct-vuex';
import { getWorkoutExecutions } from './getWorkoutExecutions';
import { getWorkoutExecution } from './getWorkoutExecution';
import { deleteWorkoutExecution } from './deleteWorkoutExecution';
import { postWorkoutExecution } from './postWorkoutExecution';

export const actions = defineActions({
    getWorkoutExecutions,
    getWorkoutExecution, 
    deleteWorkoutExecution,
    postWorkoutExecution
})