import { Module } from "vuex";
import { RootState } from "../../state";
import { WorkoutPlanState } from "./state";
import { actions } from "./actions";
import { getters } from "./getters";
import { mutations } from "./mutations";

export const workoutPlanModule : Module<WorkoutPlanState, RootState>=
{
    actions,
    getters,
    mutations
}