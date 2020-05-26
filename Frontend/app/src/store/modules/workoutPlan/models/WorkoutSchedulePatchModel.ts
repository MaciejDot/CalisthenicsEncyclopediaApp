export interface WorkoutSchedulePatchModel {
    recurrence?: number
    firstDate: Date
    recurringTimes?: number
    workoutPlanExternalId: string
    workoutPlanName: string
    externalId: string
}