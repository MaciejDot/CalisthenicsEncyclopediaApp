import { defineActions } from "direct-vuex";
import {getWorkoutPlanView} from "./getWorkoutPlanView"
import { getWorkoutPlanThumbnails } from './getWorkoutPlanThumbnails';
import { getWorkoutSchedules } from './getWorkoutSchedules';
import { postWorkouPlan } from './postWorkoutPlan';
import { patchWorkouPlan } from './patchWorkoutPlan';
import { deleteWorkouPlan } from './deleteWorkoutPlan';
import { deleteWorkoutSchedule } from './deleteWorkoutSchedule';
import { patchWorkouSchedule } from './patchWorkoutSchedule';
import { postWorkoutSchedule } from './postWorkoutSchedule';
export const actions = defineActions({
    getWorkoutPlanView,
    getWorkoutPlanThumbnails,
    getWorkoutSchedules,
    postWorkouPlan,
    postWorkoutSchedule,
    patchWorkouPlan,
    patchWorkouSchedule,
    deleteWorkouPlan,
    deleteWorkoutSchedule,
});