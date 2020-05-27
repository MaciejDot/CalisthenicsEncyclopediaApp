import { endpoints } from "@/axios/index";
import { moduleActionContext, rootActionContext } from "@/store"
import { workoutPlanModule } from "../index";
import { profileModule } from '../../profile';
import { WorkoutPlanPatchModel } from '../models/WorkoutPlanPatchModel';

export const patchWorkouPlan = (context: any, model: WorkoutPlanPatchModel): Promise<unknown> => {
    const { commit } = moduleActionContext(context, workoutPlanModule);
    const { getters } = moduleActionContext(context, profileModule);
    return endpoints
        .workoutPlan()
        .patch(
            `/WorkoutPlan/${model.externalId}`,
            model
        ).then(response => {
            commit.addOrUpdateWorkoutPlanView({
                username: getters.username ?? "",
                externalId: model.externalId,
                workoutPlan: {
                    payload: model,
                    downloaded: Date.now(),
                    expires: Date.now() + 10 * 60 * 1000
                }
            });
            commit.addOrUpdateWorkoutPlanThumbnails(model);
            commit.updateWorkoutSchedulesForWorkoutPlan({externalId: model.externalId, workoutPlanName: model.name});
        });
}