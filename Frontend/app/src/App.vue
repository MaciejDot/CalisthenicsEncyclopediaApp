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
<script>
import { BNavbar } from "bootstrap-vue";
export default {
  name: "App",
  components: {
    BNavbar
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
