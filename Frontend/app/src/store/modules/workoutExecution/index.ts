import { WorkoutExecutionState } from "./state";
import { actions } from "./actions";
import { getters } from "./getters";
import { mutations } from "./mutations";
import { defineModule } from 'direct-vuex';

export const workoutExecutionModule = defineModule(
{
    state() : WorkoutExecutionState {
        return {}
    }, 
    namespaced: true,
    mutations,
    getters,
    actions,
})