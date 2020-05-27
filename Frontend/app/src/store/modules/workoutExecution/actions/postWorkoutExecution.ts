import { endpoints } from "../../../../axios/index";
import { moduleActionContext, rootActionContext } from "../../../../store"
import { workoutExecutionModule } from "../index";
import { WorkoutExecutionServerIdentityModel } from '../models/WorkoutExecutionServerIdentityModel';
import { profileModule } from '../../profile';
import { WorkoutExecutionPostModel } from '../models/WorkoutExecutionPostModel';

export const postWorkoutExecution = (context: any, model: WorkoutExecutionPostModel): Promise<any> => {
    const { commit } = moduleActionContext(context, workoutExecutionModule);
    const { getters } = moduleActionContext(context, profileModule);
    return endpoints
        .workoutExecution()
        .post(`/Workout`, model)
        .then(response => {
            const payload: WorkoutExecutionServerIdentityModel = response && response.data;
            commit.addOrUpdateWorkoutExecution({
                username: getters.username ?? "",
                externalId: payload.externalId,
                payload: {
                    payload: { ...model, externalId: payload.externalId, created: new Date() },
                    expires: Date.now() * 60 * 60 * 1000,
                    downloaded: Date.now()
                }
            });
            commit.addOrUpdateWorkoutExecutionThumbnail({ ...model, externalId: payload.externalId, created: new Date() });
        })
}