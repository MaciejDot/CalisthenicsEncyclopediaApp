import { FatigueState } from "./state";
import { actions } from "./actions";
import { getters } from "./getters";
import { mutations } from "./mutations";
import { defineModule } from 'direct-vuex';

export const fatigueModule = defineModule(
{
    state() : FatigueState {
        return {}
    }, 
    namespaced: true,
    mutations,
    getters,
    actions,
})