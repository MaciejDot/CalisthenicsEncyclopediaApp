import Vue from "vue";
import Vuex from "vuex";
import { RootState } from "./state/index";
import { profileModule } from "./modules/profile";

Vue.use(Vuex);

export default new Vuex.Store<RootState>({
  modules: {
    profileModule
  }
});
