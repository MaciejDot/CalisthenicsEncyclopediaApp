import { WorkoutPlanState } from "../state";
import { isCachedItemFromServerExpired } from "@/store/functions/isCachedItemFromServerExpired";
import { defineGetters } from 'direct-vuex';

export const getters = defineGetters<WorkoutPlanState>()({
});