import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import Home from "../views/Home.vue";
import Workout from "../views/Workout.vue";
import { RouteAuthenticationEnum } from "./enums/RouteAuthenticationEnum";
import { MetaModel } from './models/MetaModel';

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: "/",
    name: "Home",
    component: Home,
    meta: {
      authentication: RouteAuthenticationEnum.AuthenticationDoesNotMatter
    } as MetaModel
  },
  {
    path: "/Workout",
    name: "Workout",
    component: Workout,
    meta: {
      authentication: RouteAuthenticationEnum.UserMustBeAuthenticated
    } as MetaModel
  },
  {
    path: "/about",
    name: "About",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/About.vue")
  }
];

const router = new VueRouter({
  routes,
  mode: "history"
});

export default router;
