import { MutationTree } from "vuex";
import { MoodState } from "../state";
import { CachedItemFromServer } from "../../../models/cachedItemFromServer";
import { defineMutations } from 'direct-vuex';
import { MoodsCacheModel } from '../models/MoodCacheModel';
import Vue from 'vue';

export const mutations = defineMutations<MoodState>()({
    putMoods: (state, payload: CachedItemFromServer<Array<MoodsCacheModel>>) => {
        state.moods = payload;
        Vue.set(state, 'moods', state.moods);
    }
});