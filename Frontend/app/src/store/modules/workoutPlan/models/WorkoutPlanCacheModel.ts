import { ExerciseExecutionPlanModel } from './ExerciseExecutionPlanModel';

export interface WorkoutPlanCacheModel
{
    externalId : string,
    name : string,
    description? : string,
    created : Date,
    isPublic : Boolean,
    exercises : Array<ExerciseExecutionPlanModel>
}