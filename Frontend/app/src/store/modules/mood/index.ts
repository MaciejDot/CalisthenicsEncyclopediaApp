import { MoodState } from "./state";
import { actions } from "./actions";
import { getters } from "./getters";
import { mutations } from "./mutations";
import { defineModule } from 'direct-vuex';

export const moodModule = defineModule(
{
    state() : MoodState {
        return {}
    }, 
    namespaced: true,
    mutations,
    getters,
    actions,
})