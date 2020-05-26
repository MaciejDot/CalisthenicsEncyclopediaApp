import { endpoints } from "@/axios/index";
import { moduleActionContext, rootActionContext } from "@/store"
import { workoutPlanModule } from "../index";
import { profileModule } from '../../profile';

export const deleteWorkoutSchedule = (context: any, externalId: string): Promise<unknown> => {
    const { commit } = moduleActionContext(context, workoutPlanModule);
    const { getters } = moduleActionContext(context, profileModule);
    return endpoints
        .workoutPlan()
        .delete(
            `/WorkoutSchedule/${externalId}`
        ).then(response => {
            commit.deleteWorkoutSchedule(externalId);
        });
}