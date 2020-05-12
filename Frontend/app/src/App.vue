<template>
  <div id="app">
    <b-navbar
      id="navbar"
      toggleable="lg"
      type="light"
      variant="white"
      :sticky="true"
    >
      <b-navbar-brand to="/">Calisthenics Encyclopedia</b-navbar-brand>
      <b-navbar-toggle
        id="navbar-toggle"
        target="nav-collapse"
      ></b-navbar-toggle>
      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item>
            <router-link class="nav-link" to="/about">
              Workout Program
            </router-link>
          </b-nav-item>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
    <router-view />
  </div>
</template>
<script lang="ts">

import Vue from "vue";
import { BNavbar } from "bootstrap-vue";
import Component from "vue-class-component";
import { State, Action, Getter } from "vuex-class";

@Component
export default class App extends Vue {
  @State("profile") profile: unknown;
  @Action("fetchData") fetchData : number;
  @Getter("fullName", {}) fullName: unknown;
  mounted(){ 
    this.fetchData({});
  }
  components(){
    return { BNavbar }
  }
};
</script>
<style lang="scss">
#app {
  font-family: Georgia, serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
#navbar {
  border: 1px solid #e7e7e7;
}
#navbar-toggle {
  border-radius: 1px;
}
h1 {
  margin: 20px !important;
}
</style>
