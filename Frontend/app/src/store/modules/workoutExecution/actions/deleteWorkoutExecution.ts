import { endpoints } from "../../../../axios/index";
import { moduleActionContext, rootActionContext } from "../../../../store"
import { workoutExecutionModule } from "../index";
import { WorkoutExecutionServerIdentityModel } from '../models/WorkoutExecutionServerIdentityModel';
import { profileModule } from '../../profile';

export const deleteWorkoutExecution = (context: any, model: WorkoutExecutionServerIdentityModel): Promise<any> => {
    const { commit } = moduleActionContext(context, workoutExecutionModule);
    const { getters } = moduleActionContext(context, profileModule);
    return endpoints
        .workoutExecution()
        .delete(`/Workout/${model.externalId}`)
        .then(() => {
            commit.deleteWorkoutExecution({username: getters.username ?? "", externalId: model.externalId})
            commit.deleteWorkoutExecutionThumbnail(model);
        })
}