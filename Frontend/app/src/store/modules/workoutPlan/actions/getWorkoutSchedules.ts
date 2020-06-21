import { endpoints } from "../../../../axios/index";
import { moduleActionContext, rootActionContext } from "../../../../store"
import { workoutPlanModule } from "../index";
import { isCachedItemFromServerExpired } from '@/store/functions/isCachedItemFromServerExpired';
import { WorkoutPlanCacheModel } from '../models/WorkoutPlanCacheModel';
import { WorkoutPlanIdentityModel } from '../models/WorkoutPlanIdentityModel';
import { WorkoutSchedulesCacheModel } from '../models/WorkoutSchedulesCacheModel';

export const getWorkoutSchedules = (context : any): Promise<Array<WorkoutSchedulesCacheModel> | undefined> =>{
    const { commit , state } = moduleActionContext(context, workoutPlanModule);
    if(isCachedItemFromServerExpired(state.workoutSchedules)){
        return endpoints
                .workoutPlan()
                .get(
                    `/WorkoutSchedules`
                ).then(response => {
                    const payload: Array<WorkoutSchedulesCacheModel> = response && response.data;
                    commit.putWorkoutSchedules({
                            payload : payload,
                            downloaded : Date.now(),
                            expires: Date.now() + 10*60*1000
                    });
                    return state.workoutSchedules?.payload;
                });
    }
    return Promise.resolve(state.workoutSchedules?.payload);
}