import { Module } from "vuex";
import { RootState } from "../../state";
import { ProfileState } from "./state";
import { actions } from "./actions";
import { getters } from "./getters";
import { mutations } from "./mutations";

export const profileModule : Module<ProfileState, RootState>=
{
    actions,
    getters,
    mutations
}