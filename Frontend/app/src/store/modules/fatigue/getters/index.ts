import { FatigueState } from "../state";
import { defineGetters } from 'direct-vuex';
import { FatigueCacheModel } from '../models/FatigueCacheModel';

export const getters = defineGetters<FatigueState>()({
    moods(state) : Array<FatigueCacheModel> | undefined {
        return state.fatigues?.payload
    },
});