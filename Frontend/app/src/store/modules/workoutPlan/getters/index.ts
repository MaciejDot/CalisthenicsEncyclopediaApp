import { WorkoutPlanState } from "../state";
import { isCachedItemFromServerExpired } from "@/store/functions/isCachedItemFromServerExpired";
import { defineGetters } from 'direct-vuex';
import { WorkoutSchedulesCacheModel } from '../models/WorkoutSchedulesCacheModel';
import { WorkoutPlanCacheModel } from '../models/WorkoutPlanCacheModel';

export const getters = defineGetters<WorkoutPlanState>()({
    workoutPlansThumbnailsAreActual(state): boolean {
        return !isCachedItemFromServerExpired(state?.workoutPlansThumbnails)
    },
    workoutPlansThumbnails(state): Array<WorkoutPlanCacheModel> | undefined {
        return !isCachedItemFromServerExpired(state?.workoutPlansThumbnails) ?
            state?.workoutPlansThumbnails?.payload :
            undefined
    },
    getAllWorkoutPlans(state): WorkoutPlanCacheModel[] | undefined {
        const result = new Array<WorkoutPlanCacheModel>();
        state?.workoutPlans?.forEach(map => map.forEach(entry => {
            if (!isCachedItemFromServerExpired(entry) && entry.payload != undefined) {
                result.push(entry.payload)
            }
        }))
        return result;
    },
    workoutSchedules(state): WorkoutSchedulesCacheModel[] | undefined {
        return !isCachedItemFromServerExpired(state?.workoutSchedules) ?
            state?.workoutSchedules?.payload :
            undefined
    }
});