import Vue from "vue";
import Vuex from "vuex";
import { profileModule } from "./modules/profile";
import { workoutPlanModule } from "./modules/workoutPlan";
import { RootState } from './state';
import localforage from "localforage";
import VuexPersistence from 'vuex-persist';
import { createDirectStore } from 'direct-vuex';
import { exerciseModule } from './modules/exercises';
import { moodModule } from './modules/mood';
import { fatigueModule } from './modules/fatigue';
import { workoutExecutionModule } from './modules/workoutExecution';

const instance = localforage.createInstance({
  driver: [
    localforage.INDEXEDDB,
    localforage.WEBSQL,
    localforage.LOCALSTORAGE]
});

const vuexPersist = new VuexPersistence({
  storage: localStorage,//instance,
  //asyncStorage: true,
  modules: ["profileModule",
    "workoutPlanModule",
    "exerciseModule",
    "moodModule",
    "fatigueModule",
    "workoutExecutionModule"]
})

Vue.use(Vuex);

const {
  store,
  rootActionContext,
  moduleActionContext,
  rootGetterContext,
  moduleGetterContext
} = createDirectStore({
  modules: {
    profileModule,
    workoutPlanModule,
    exerciseModule,
    moodModule,
    fatigueModule,
    workoutExecutionModule
  },
  plugins: [vuexPersist.plugin]
});

export default store

export {
  rootActionContext,
  moduleActionContext,
  rootGetterContext,
  moduleGetterContext
};

export type AppStore = typeof store
declare module "vuex" {
  interface Store<S> {
    direct: AppStore
  }
}
