import { endpoints } from "../../../../axios/index";
import { moduleActionContext, rootActionContext } from "../../../../store"
import { workoutPlanModule } from "../index";
import { isCachedItemFromServerExpired } from '@/store/functions/isCachedItemFromServerExpired';
import { WorkoutPlanCacheThumbnailModel } from '../models/WorkoutPlanCacheThumbnailModel';

export const getWorkoutPlanThumbnails = (context : any): Promise<Array<WorkoutPlanCacheThumbnailModel> | undefined> =>{
    const { commit , state } = moduleActionContext(context, workoutPlanModule);
    if(isCachedItemFromServerExpired(state.workoutPlansThumbnails)){
    return endpoints
        .workoutPlan()
        .get("/WorkoutPlan")
        .then( response => {
            const payload: Array<WorkoutPlanCacheThumbnailModel> = response && response.data;
            commit.putWorkoutPlanThumbnails({
                downloaded : Date.now(),
                expires: Date.now() + 60 * 60 *1000,
                payload: payload
            });
            return state.workoutPlansThumbnails?.payload;
        });
    }
    return Promise.resolve(state.workoutPlansThumbnails?.payload);
}