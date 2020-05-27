import { endpoints } from "@/axios/index";
import { moduleActionContext, rootActionContext } from "@/store"
import { workoutPlanModule } from "../index";
import { profileModule } from '../../profile';

export const deleteWorkouPlan = (context: any, externalId: string): Promise<unknown> => {
    const { commit } = moduleActionContext(context, workoutPlanModule);
    const { getters } = moduleActionContext(context, profileModule);
    return endpoints
        .workoutPlan()
        .delete(
            `/WorkoutPlan/${externalId}`
        ).then(response => {
            commit.deleteWorkoutPlanThumbnail(externalId);
            commit.deleteWorkoutPlanView({ externalId, username: getters.username ?? "" });
            commit.deleteWorkoutSchedulesForWorkoutPlan(externalId);
        });
}