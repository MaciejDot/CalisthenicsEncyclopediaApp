import { MutationTree } from "vuex";
import { FatigueState } from "../state";
import { CachedItemFromServer } from "../../../models/cachedItemFromServer";
import { defineMutations } from 'direct-vuex';
import { FatigueCacheModel } from '../models/FatigueCacheModel';
import Vue from 'vue';
export const mutations = defineMutations<FatigueState>()({
    putFatigues: (state, payload: CachedItemFromServer<Array<FatigueCacheModel>>) => {
        state.fatigues = payload;
        Vue.set(state,'fatigues', state.fatigues);
    }
});