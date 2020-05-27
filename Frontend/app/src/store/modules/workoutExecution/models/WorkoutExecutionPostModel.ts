import { ExerciseExecutionCacheModel } from './ExerciseExecutionCacheModel';

export interface WorkoutExecutionPostModel {
    name: string
    description : string
    isPublic : boolean
    mood : number
    fatigue : number
    exercises : Array<ExerciseExecutionCacheModel>,
    executed : Date
}