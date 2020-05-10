<template>
  <div class="home">
    <hello-world msg="Welcome to Your Vue.js App" />
    <b-icon-arrow-up></b-icon-arrow-up>
    <b-card />
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from "@/components/HelloWorld.vue";
import { BCard, BIconArrowUp } from "bootstrap-vue";
export default {
  name: "Home",
  components: {
    BCard,
    HelloWorld,
    BIconArrowUp
  }
};
</script>
