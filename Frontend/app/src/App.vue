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
            <router-link class="nav-link" to="/Workout"> Workout </router-link>
          </b-nav-item>
        </b-navbar-nav>
        <b-navbar-nav class="ml-auto">
          <b-nav-item-dropdown v-if="loggedIn" right>
            <template slot="button-content">
              <b-icon-people-circle />&nbsp; &nbsp;
              {{ username }}
            </template>
            <b-dropdown-item href="#" @click="signOut"
              >Sign Out</b-dropdown-item
            >
          </b-nav-item-dropdown>
          <b-nav-item v-else>
            <a class="nav-link" @click="showLoginModal()">Log In</a>
          </b-nav-item>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
    <login-modal v-model="loginModalIsActive" @log-in="logged" />
    <router-view />
  </div>
</template>
<script lang="ts">
import { BNavbar, BIconPeopleCircle } from "bootstrap-vue";
import Vue from "vue";
import LoginModal from "./components/LoginModal.vue";
import { MetaModel } from "./router/models/MetaModel";

export default Vue.extend({
  data() {
    return {
      profileGetters: this.$store.direct.getters.profileModule,
      loginModalIsActive: false
    };
  },
  components: { BNavbar, LoginModal, BIconPeopleCircle },
  computed: {
    loggedIn(): boolean {
      return this.profileGetters.loggedIn;
    },
    username(): string | unknown {
      return this.profileGetters.username;
    }
  },
  methods: {
    signOut(): unknown {
      return 0;
    },
    showLoginModal() {
      this.loginModalIsActive = true;
    },
    logged() {
      //const meta = this.$route.meta as MetaModel;
    }
  }
});
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
