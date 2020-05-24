import { WorkoutPlanState } from "../state";
import { defineMutations } from 'direct-vuex';
import { addWorkoutPlanView } from './addWorkoutPlanView';
import { putWorkoutPlanThumbnails } from './putWorkoutPlanThumbnails';

export const mutations = defineMutations<WorkoutPlanState>()({
    addWorkoutPlanView,
    putWorkoutPlanThumbnails
});