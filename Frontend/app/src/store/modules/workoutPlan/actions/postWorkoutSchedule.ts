import { endpoints } from "@/axios/index";
import { moduleActionContext, rootActionContext } from "@/store"
import { workoutPlanModule } from "../index";
import { WorkoutSchedulePostModel } from '../models/WorkoutSchedulePostModel';
import { WorkoutScheduleIdentityModel } from '../models/WorkoutScheduleIdentityModel';

export const postWorkoutSchedule = (context: any, model: WorkoutSchedulePostModel): Promise<unknown> => {
    const { commit } = moduleActionContext(context, workoutPlanModule);
    return endpoints
        .workoutPlan()
        .post(
            `/WorkoutSchedule`,
            model
        ).then(response => {
            const payload: WorkoutScheduleIdentityModel = response && response.data;
            commit.addOrUpdateWorkoutSchedule({ ...model, externalId: payload.externalId });
        });
}