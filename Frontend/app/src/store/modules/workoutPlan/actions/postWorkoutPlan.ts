import { endpoints } from "@/axios/index";
import { moduleActionContext, rootActionContext } from "@/store"
import { workoutPlanModule } from "../index";
import { WorkoutPlanPostModel } from '../models/WorkoutPlanPostModel';
import { profileModule } from '../../profile';
import { WorkoutPlanServerIdentityModel } from '../models/WorkoutPlanServerIdentityModel';

export const postWorkouPlan = (context: any, model: WorkoutPlanPostModel): Promise<unknown> => {
    const { commit } = moduleActionContext(context, workoutPlanModule);
    const { getters } = moduleActionContext(context, profileModule);
    return endpoints
        .workoutPlan()
        .post(
            `/WorkoutPlan`,
            model
        ).then(response => {
            const payload: WorkoutPlanServerIdentityModel = response && response.data;
            commit.addOrUpdateWorkoutPlanView({
                username: getters.username ?? "",
                externalId: payload.externalId,
                workoutPlan: {
                    payload: { ...model, externalId: payload.externalId, created: new Date() },
                    downloaded: Date.now(),
                    expires: Date.now() + 10 * 60 * 1000
                }
            });
        });
}