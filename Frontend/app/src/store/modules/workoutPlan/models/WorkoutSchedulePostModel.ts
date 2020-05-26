export interface WorkoutSchedulePostModel {
    recurrence?: number
    firstDate: Date
    recurringTimes?: number
    workoutPlanExternalId: string
    workoutPlanName: string
}