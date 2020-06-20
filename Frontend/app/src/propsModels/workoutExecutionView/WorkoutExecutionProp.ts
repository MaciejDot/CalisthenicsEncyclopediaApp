import { ExerciseExecutionProp } from './ExerciseExecutionProp';

export interface WorkoutExecutionProp{
    exercises : Array<ExerciseExecutionProp>,
    externalId :string,
    name  :string,
    description  :string,
    created  :Date,
    executed :Date,
    isPublic :boolean,
    mood :number,
    fatigue :number,
}