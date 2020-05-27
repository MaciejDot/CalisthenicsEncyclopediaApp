import { endpoints } from "../../../../axios/index";
import { moduleActionContext, rootActionContext } from "../../../../store"
import { workoutExecutionModule } from "../index";
import { isCachedItemFromServerExpired } from '@/store/functions/isCachedItemFromServerExpired';
import { WorkoutExecutionCacheModel } from '../models/WorkoutExecutionCacheModel';
import { WorkoutExecutionIdentityModel } from '../models/WorkoutExecutionIdentityModel';

export const getWorkoutExecution = (context: any, model : WorkoutExecutionIdentityModel): Promise<WorkoutExecutionCacheModel | undefined> => {
    const { commit, state } = moduleActionContext(context, workoutExecutionModule);
    if (isCachedItemFromServerExpired(state.workoutExecutions?.get(model.username)?.get(model.externalId))) {
        return endpoints
            .workoutExecution()
            .get(`/Workout/${model.username}/${model.externalId}`)
            .then(response => {
                const payload: WorkoutExecutionCacheModel = response && response.data;
                commit.addOrUpdateWorkoutExecution({
                    username : model.username,
                    externalId : model.externalId,
                    payload : {
                        payload: payload,
                        expires : Date.now() + 60 * 60 *1000,
                        downloaded : Date.now()
                    }
                })
                return state.workoutExecutions?.get(model.username)?.get(model.externalId)?.payload;
            })
    }
    return Promise.resolve(state.workoutExecutions?.get(model.username)?.get(model.externalId)?.payload)
}