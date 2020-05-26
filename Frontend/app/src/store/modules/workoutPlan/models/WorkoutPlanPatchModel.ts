import { ExerciseExecutionPlanModel } from "./ExerciseExecutionPlanModel";
export interface WorkoutPlanPatchModel {
    externalId: string,
    name: string
    description?: string
    isPublic: boolean
    exercises: Array<ExerciseExecutionPlanModel>
    created: Date
}