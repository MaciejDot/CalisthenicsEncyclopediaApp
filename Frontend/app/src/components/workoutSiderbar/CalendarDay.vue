<template>
  <div>
    <h4>{{ selectedDate }}</h4>
  </div>
</template>
<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  data() {
    return {
      selectedDate: 0,
      workoutExecutions: [],
      workoutPlans: []
    };
  }
});
</script>
