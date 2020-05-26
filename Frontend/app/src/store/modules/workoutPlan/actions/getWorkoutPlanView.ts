import { endpoints } from "../../../../axios/index";
import { moduleActionContext, rootActionContext } from "../../../../store"
import { workoutPlanModule } from "../index";
import { isCachedItemFromServerExpired } from '@/store/functions/isCachedItemFromServerExpired';
import { WorkoutPlanCacheModel } from '../models/WorkoutPlanCacheModel';
import { WorkoutPlanIdentityModel } from '../models/WorkoutPlanIdentityModel';

export const getWorkoutPlanView = (context : any, identity: WorkoutPlanIdentityModel): Promise<WorkoutPlanCacheModel | undefined> =>{
    const { commit , state } = moduleActionContext(context, workoutPlanModule);
    const { username, externalId: workoutId} = identity;
    if(isCachedItemFromServerExpired(state.workoutPlans?.get(username)?.get(workoutId))){
        return endpoints
                .workoutPlan()
                .get(
                    `/WorkoutPlan/${username}/${workoutId}`
                ).then(response => {
                    const payload: WorkoutPlanCacheModel = response && response.data;
                    commit.addOrUpdateWorkoutPlanView({
                        username : username,
                        externalId : workoutId,
                        workoutPlan : {
                            payload : payload,
                            downloaded : Date.now(),
                            expires: Date.now() + 10*60*1000
                        }
                    });
                    return state.workoutPlans?.get(username)?.get(workoutId)?.payload;
                });
    }
    return Promise.resolve(state.workoutPlans?.get(username)?.get(workoutId)?.payload);
}