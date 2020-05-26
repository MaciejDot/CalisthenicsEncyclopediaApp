export interface WorkoutSchedulesCacheModel{
    externalId : string,
    recurrance? : number,
    firstDate: Date,
    recurringTimes?: number,
    workoutPlanExternalId: string,
    workoutPlanName: string
}