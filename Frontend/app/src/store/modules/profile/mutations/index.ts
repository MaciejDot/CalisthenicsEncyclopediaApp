import { MutationTree } from "vuex";
import { ProfileState } from "../state";
import { CachedItemFromServer } from "../../../models/cachedItemFromServer";
import { defineMutations } from 'direct-vuex';
import Vue from 'vue';

export const mutations = defineMutations<ProfileState>()({
    putToken: (state, token : CachedItemFromServer<string>) => Vue.set(state,"token",token),
    putUsername: (state, username: CachedItemFromServer<string>) => Vue.set(state,'username',username),
});