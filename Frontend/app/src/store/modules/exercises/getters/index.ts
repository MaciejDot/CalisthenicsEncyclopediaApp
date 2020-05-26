import { ExerciseState } from "../state";
import { defineGetters } from 'direct-vuex';
import { ExerciseCacheModel } from '../models/ExerciseCacheModel';

export const getters = defineGetters<ExerciseState>()({
    exercises(state) : Array<ExerciseCacheModel> | undefined {
        return state.exercises?.payload
    },
});