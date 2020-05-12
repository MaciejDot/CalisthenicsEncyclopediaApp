import Vue from "vue";
import Vuex from "vuex";
import { profileModule } from "./modules/profile";
import { workoutPlanModule } from "./modules/workoutPlan";
import { RootState } from './state';
import localforage from "localforage";
import VuexPersistence from 'vuex-persist'

const instance = localforage.createInstance({
  driver: [
          localforage.INDEXEDDB,
          localforage.WEBSQL,
          localforage.LOCALSTORAGE]
  });

const vuexPersist = new VuexPersistence({
    storage: instance,
    asyncStorage: true
  })

Vue.use(Vuex);

export default new Vuex.Store<RootState>({
  modules: {
    profileModule,
    workoutPlanModule
  },
  plugins : [vuexPersist.plugin]
});
