import { WorkoutPlanState } from "../state";
import { defineMutations } from 'direct-vuex';
import { addOrUpdateWorkoutPlanView } from './addOrUpdateWorkoutPlanView';
import { putWorkoutPlanThumbnails } from './putWorkoutPlanThumbnails';
import { putWorkoutSchedules } from './putWorkoutSchedules';
import { addOrUpdateWorkoutPlanThumbnails } from './addOrUpdateWorkoutPlanThumbnail';
import { deleteWorkoutPlanThumbnail } from './deleteWorkoutPlanThumbnail';
import { deleteWorkoutPlanView } from './deleteWorkoutPlanView';
import { deleteWorkoutSchedule } from './deleteWorkoutSchedule';
import { addOrUpdateWorkoutSchedule } from './addOrUpdateWorkoutSchedule';
import { deleteWorkoutSchedulesForWorkoutPlan } from './deleteWorkoutSchedulesForWorkoutPlan';
import { updateWorkoutSchedulesForWorkoutPlan } from './updateWorkoutSchedulesForWorkoutPlan';

export const mutations = defineMutations<WorkoutPlanState>()({
    addOrUpdateWorkoutPlanView,
    putWorkoutPlanThumbnails,
    putWorkoutSchedules,
    addOrUpdateWorkoutPlanThumbnails,
    deleteWorkoutPlanThumbnail,
    deleteWorkoutPlanView,
    deleteWorkoutSchedule,
    addOrUpdateWorkoutSchedule,
    deleteWorkoutSchedulesForWorkoutPlan,
    updateWorkoutSchedulesForWorkoutPlan
});