import { Module } from "vuex";
import { RootState } from "../../state";
import { WorkoutPlanState } from "./state";
import { actions } from "./actions";
import { getters } from "./getters";
import { mutations } from "./mutations";
import { defineModule } from 'direct-vuex';

export const workoutPlanModule = defineModule(
{
    state() : WorkoutPlanState {
        return {
            workoutPlans: undefined,
            workoutPlansThumbnails: undefined
        }
    }, 
    namespaced: true,
    mutations,
    getters,
    actions,
})