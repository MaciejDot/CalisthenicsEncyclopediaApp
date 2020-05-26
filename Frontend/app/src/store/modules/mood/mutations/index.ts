import { MutationTree } from "vuex";
import { MoodState } from "../state";
import { CachedItemFromServer } from "../../../models/cachedItemFromServer";
import { defineMutations } from 'direct-vuex';
import { MoodsCacheModel } from '../models/MoodCacheModel';

export const mutations = defineMutations<MoodState>()({
    putMoods : (state, payload : CachedItemFromServer<Array<MoodsCacheModel>>) => state.moods = payload
});