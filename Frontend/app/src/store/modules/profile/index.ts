import { Module } from "vuex";
import { RootState } from "../../state";
import { ProfileState } from "./state";
import { actions } from "./actions";
import { getters } from "./getters";
import { mutations } from "./mutations";
import { defineModule } from 'direct-vuex';

export const profileModule = defineModule(
{
    state() : ProfileState {
        return {}
    }, 
    namespaced: true,
    mutations,
    getters,
    actions,
})