import { defineActions } from "direct-vuex";
import {getWorkoutPlanView} from "./getWorkoutPlanView"
import { getWorkoutPlanThumbnails } from './getWorkoutPlanThumbnails';
import { getWorkoutSchedules } from './getWorkoutSchedules';
export const actions = defineActions({
    getWorkoutPlanView,
    getWorkoutPlanThumbnails,
    getWorkoutSchedules
});