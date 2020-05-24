import Vue from "vue";
import Vuex from "vuex";
import { profileModule } from "./modules/profile";
import { workoutPlanModule } from "./modules/workoutPlan";
import { RootState } from './state';
import localforage from "localforage";
import VuexPersistence from 'vuex-persist';
import { createDirectStore } from 'direct-vuex';

const instance = localforage.createInstance({
  driver: [
          localforage.INDEXEDDB,
          localforage.WEBSQL,
          localforage.LOCALSTORAGE]
  });

const vuexPersist = new VuexPersistence({
    storage: localStorage,//instance,
    //asyncStorage: true,
  })

Vue.use(Vuex);

const {
  store,
  rootActionContext,
  moduleActionContext,
  rootGetterContext,
  moduleGetterContext
} = createDirectStore({
  modules: { profileModule, workoutPlanModule },
  plugins : [vuexPersist.plugin]
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
