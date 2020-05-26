<template>
  <round-card class="workout-card">
    <slot></slot>
  </round-card>
</template>
<script lang="ts">
import Vue from "vue";
import RoundCard from "../common/RoundCard.vue";
export default Vue.extend({
  components: { RoundCard }
});
</script>
<style scoped>
.workout-card {
  height: 20em;
}
</style>
