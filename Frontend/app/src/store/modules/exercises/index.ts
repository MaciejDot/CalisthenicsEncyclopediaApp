import { ExerciseState } from "./state";
import { actions } from "./actions";
import { getters } from "./getters";
import { mutations } from "./mutations";
import { defineModule } from 'direct-vuex';

export const exerciseModule = defineModule(
{
    state() : ExerciseState {
        return {}
    }, 
    namespaced: true,
    mutations,
    getters,
    actions,
})