import { endpoints } from "@/axios/index";
import { moduleActionContext, rootActionContext } from "@/store"
import { workoutPlanModule } from "../index";
import { WorkoutScheduleIdentityModel } from '../models/WorkoutScheduleIdentityModel';
import { WorkoutSchedulePatchModel } from '../models/WorkoutSchedulePatchModel';

export const patchWorkouSchedule = (context: any, model: WorkoutSchedulePatchModel): Promise<unknown> => {
    const { commit } = moduleActionContext(context, workoutPlanModule);
    return endpoints
        .workoutPlan()
        .post(
            `/WorkoutSchedule/${model.externalId}`,
            model
        ).then(response => {
            commit.addOrUpdateWorkoutSchedule(model);
        });
}