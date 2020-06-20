import Vue from "vue";
import Vuex from "vuex";
import { profileModule } from "./modules/profile";
import { workoutPlanModule } from "./modules/workoutPlan";
import SecureLS from 'secure-ls';
import VuexPersistence from 'vuex-persist';
import { createDirectStore } from 'direct-vuex';
import { exerciseModule } from './modules/exercises';
import { moodModule } from './modules/mood';
import { fatigueModule } from './modules/fatigue';
import { workoutExecutionModule } from './modules/workoutExecution';

const ls = new SecureLS({ isCompression: false });
const vuexPersist = new VuexPersistence({
  storage: {
    getItem: (key: string) => {
      try { return ls.get(key) }
      catch { return "" }
    },
    clear: () => ls.clear(),
    removeItem: (key: string) => ls.remove(key),
    key: (index: number) => "vuex-persist",
    length: 1,
    setItem: (key: string, value: string) => ls.set(key, value),
    name: "vuex-persist",
  },
  modules: ["profileModule"]
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
