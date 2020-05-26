import { ExerciseExecutionCacheModel } from './ExerciseExecutionCacheModel';

export interface WorkoutExecutionCacheModel{
    externalId :string,
    name  :string,
    description  :string,
    created  :Date,
    executed :Date,
    isPublic :boolean,
    mood :number,
    fatigue :number,
    exercises : Array<ExerciseExecutionCacheModel>
}