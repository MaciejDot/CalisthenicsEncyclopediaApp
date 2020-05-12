import axios from "axios";
import store from "../store/index";
import { baseUrls } from "../config/index";

const headers = function () {
    return store.getters.loggedIn ? {
        'Content-Type': "application/json",
        'Authorization': `Bearer ${store.getters.token}`
    } : {
            'Content-Type': "application/json"
        }
}

export const endpoints = {
    account: () =>
        axios.create({
            baseURL: baseUrls.accountApiAddress,
            headers: headers(),
            timeout: 50000,
        }),
    workoutExecution: () => axios.create({
        baseURL: baseUrls.workoutExecutionApiAddress,
        headers: headers(),
        timeout: 50000,
    }),

    workoutPlan: () => axios.create({
        baseURL: baseUrls.workoutPlanApiAddress,
        headers: headers(),
        timeout: 50000,
    }),

    exercise: () => axios.create({
        baseURL: baseUrls.exercisesAddress,
        headers: headers(),
        timeout: 50000,
    }),
    mood: () => axios.create({
        baseURL: baseUrls.moodAddress,
        headers: headers(),
        timeout: 50000,
    }),
    fatigue: () => axios.create({
        baseURL: baseUrls.fatigueAddress,
        headers: headers(),
        timeout: 50000,
    })
};