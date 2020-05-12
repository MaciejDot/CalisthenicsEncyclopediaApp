<template>
  <div></div>
</template>
<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";

@Component
export default class LoginModal extends Vue {
  mounted() {
    this.$store
      .dispatch("login", {
        email: "maciejd0@op.pl",
        password: "password"
      })
      .then(() => this.$store.dispatch("accountInfo"));
  }
}
</script>
