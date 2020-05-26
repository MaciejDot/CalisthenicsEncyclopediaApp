import { ExerciseExecutionPlanModel } from "./ExerciseExecutionPlanModel";
export interface WorkoutPlanPostModel {
    name: string
    description?: string
    isPublic: boolean
    exercises: Array<ExerciseExecutionPlanModel>

}