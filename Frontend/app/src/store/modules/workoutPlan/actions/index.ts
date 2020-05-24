import { defineActions } from "direct-vuex";
import {getWorkoutPlanView} from "./getWorkoutPlanView"
import { getWorkoutPlanThumbnails } from './getWorkoutPlanThumbnails';
export const actions = defineActions({
    getWorkoutPlanView,
    getWorkoutPlanThumbnails
});