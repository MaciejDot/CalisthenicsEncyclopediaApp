import { WorkoutPlanState } from "../state";
import { isCachedItemFromServerExpired } from "@/store/functions/isCachedItemFromServerExpired";
import { defineGetters } from 'direct-vuex';
import { WorkoutPlanCacheThumbnailModel } from '../models/WorkoutPlanCacheThumbnailModel';

export const getters = defineGetters<WorkoutPlanState>()({
    workoutPlansThumbnailsAreActual(state): boolean {
        return !isCachedItemFromServerExpired(state?.workoutPlansThumbnails)
    },
    workoutPlansThumbnails(state): Array<WorkoutPlanCacheThumbnailModel> | undefined {
        return !isCachedItemFromServerExpired(state?.workoutPlansThumbnails) ?
            state?.workoutPlansThumbnails?.payload:
            undefined
    } 
});