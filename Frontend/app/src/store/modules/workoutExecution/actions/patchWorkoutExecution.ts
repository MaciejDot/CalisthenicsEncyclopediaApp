import { endpoints } from "../../../../axios/index";
import { moduleActionContext, rootActionContext } from "../../../../store"
import { workoutExecutionModule } from "../index";
import { WorkoutExecutionServerIdentityModel } from '../models/WorkoutExecutionServerIdentityModel';
import { profileModule } from '../../profile';
import { WorkoutExecutionPatchModel } from '../models/WorkoutExecutionPatchModel';

export const postWorkoutExecution = (context: any, model: WorkoutExecutionPatchModel): Promise<any> => {
    const { commit } = moduleActionContext(context, workoutExecutionModule);
    const { getters } = moduleActionContext(context, profileModule);
    return endpoints
        .workoutExecution()
        .patch(`/Workout/${model.externalId}`, model)
        .then(response => {
            const payload: WorkoutExecutionServerIdentityModel = response && response.data;
            commit.addOrUpdateWorkoutExecution({
                username: getters.username ?? "",
                externalId: payload.externalId,
                payload: {
                    payload: { ...model, externalId: payload.externalId },
                    expires: Date.now() * 60 * 60 * 1000,
                    downloaded: Date.now()
                }
            });
            commit.addOrUpdateWorkoutExecutionThumbnail({ ...model, externalId: payload.externalId });
        })
}