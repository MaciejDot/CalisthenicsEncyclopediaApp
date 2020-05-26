import { MoodState } from "../state";
import { defineGetters } from 'direct-vuex';
import { MoodsCacheModel } from '../models/MoodCacheModel';

export const getters = defineGetters<MoodState>()({
    moods(state) : Array<MoodsCacheModel> | undefined {
        return state.moods?.payload
    },
});