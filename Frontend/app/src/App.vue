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
          <b-nav-item v-if="loggedIn">
            <router-link class="nav-link" to="/workout"
              >Workout Program</router-link
            >
          </b-nav-item>
        </b-navbar-nav>
        <b-navbar-nav class="ml-auto">
          <b-nav-item-dropdown v-if="loggedIn" right>
            <template slot="button-content">
              <em>{{ username }}</em>
            </template>
            <b-dropdown-item href="#" @click="signOut"
              >Sign Out</b-dropdown-item
            >
          </b-nav-item-dropdown>
          <b-nav-item v-else>
            <router-link class="nav-link" to="/LogIn">Log In</router-link>
          </b-nav-item>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
    <login-modal />
    <router-view />
  </div>
</template>
<script lang="ts">
import { BNavbar } from "bootstrap-vue";
import Vue from "vue";
import Component from "vue-class-component";
import LoginModal from "./components/LoginModal.vue";

@Component({ components: { BNavbar, LoginModal } })
export default class App extends Vue {
  get loggedIn() {
    return this.$store.direct.getters.profileModule.loggedIn;
  }
  get username() {
    return this.$store.direct.getters.profileModule.username;
  }
  mounted() {
    setInterval(
      () => this.$store.direct.dispatch.profileModule.refreshToken(),
      10000
    );
  }
  signOut(): unknown {
    return 0;
  }
}
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
