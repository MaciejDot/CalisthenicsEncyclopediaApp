<template>
  <b-card class="white-card round-card">
    <slot></slot>
  </b-card>
</template>
<script lang="ts">
import Vue from "vue";
import { BCard } from "bootstrap-vue";
export default Vue.extend({
  components: { BCard }
});
</script>
<style scoped>
.white-card {
  background-color: white;
}
.round-card {
  border-radius: 2px;
  margin-top: 20px;
  border: 1px solid #eee;
}
</style>
