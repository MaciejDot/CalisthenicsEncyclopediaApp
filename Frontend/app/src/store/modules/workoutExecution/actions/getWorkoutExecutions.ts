import { endpoints } from "../../../../axios/index";
import { moduleActionContext, rootActionContext } from "../../../../store"
import { workoutExecutionModule } from "../index";
import { isCachedItemFromServerExpired } from '@/store/functions/isCachedItemFromServerExpired';
import { profileModule } from '../../profile';
import { WorkoutExecutionCacheModel } from '../models/WorkoutExecutionCacheModel';

export const getWorkoutExecutions = (context: any): Promise<Array<WorkoutExecutionCacheModel> | undefined> => {
    const { commit, state } = moduleActionContext(context, workoutExecutionModule);
    const { getters } = moduleActionContext(context, profileModule);
    if (isCachedItemFromServerExpired(state.workoutExecutionsThumbnails)) {
        return endpoints
            .workoutExecution()
            .get(`/Workout`)
            .then(response => {
                const payload: Array<WorkoutExecutionCacheModel> = response && response.data;
                commit.addOrUpdateWorkoutExecutions({
                    username: getters.username ?? "",
                    payload: payload.map(x => ({
                        payload: x,
                        downloaded: Date.now(),
                        expires: Date.now() + 60 * 60 * 1000
                    }))
                })
                commit.putWorkoutExecutionThumbnails({
                    payload: payload,
                    downloaded: Date.now(),
                    expires: Date.now() + 60 * 60 * 1000
                })
                return state.workoutExecutionsThumbnails?.payload;
            })
    }
    return Promise.resolve(state.workoutExecutionsThumbnails?.payload)
}