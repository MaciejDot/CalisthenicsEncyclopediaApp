import { ExerciseExecutionCacheModel } from './ExerciseExecutionCacheModel';

export interface WorkoutExecutionPatchModel 
{
    name: string
    description : string
    isPublic : boolean
    mood : number
    fatigue : number
    exercises : Array<ExerciseExecutionCacheModel>,
    executed : Date,
    created: Date,
    externalId: string
}