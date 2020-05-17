<template>
  <div></div>
</template>
<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
@Component
export default class LoginModal extends Vue {
  profileModule = this.$store.direct.dispatch.profileModule;
  mounted() {
    this.profileModule
      .login({
        email: "maciejd0@op.pl",
        password: "password"
      })
      .then(() => {
        this.profileModule.accountInfo();
      });
  }
}
</script>
