import { MutationTree } from "vuex";
import { ExerciseState } from "../state";
import { CachedItemFromServer } from "../../../models/cachedItemFromServer";
import { defineMutations } from 'direct-vuex';
import { ExerciseCacheModel } from '../models/ExerciseCacheModel';
import Vue from 'vue';

export const mutations = defineMutations<ExerciseState>()({
    putExercises: (state, payload: CachedItemFromServer<Array<ExerciseCacheModel>>) => {
        state.exercises = payload;
        Vue.set(state, 'exercises', state.exercises);
    }
});