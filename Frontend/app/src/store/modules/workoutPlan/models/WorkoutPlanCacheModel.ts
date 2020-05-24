import { ExerciseExecutionPlanModel } from './ExerciseExecutionPlanModel';

export interface WorkoutPlanCacheModel
{
    externalId : string,
    name : string,
    description : string,
    created : Date,
    IsPublic : Boolean,
    Exercises : Array<ExerciseExecutionPlanModel>
}