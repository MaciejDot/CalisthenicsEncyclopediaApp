<template>
  <div>
    <h4>{{ selectedDate }}</h4>
  </div>
</template>
<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  props: {
    selectedDate: Date
  },
  data() {
    return {
      workoutExecutions: [],
      workoutPlans: []
    };
  },
  created() {
    Promise.all([
      this.$store.direct.dispatch.moodModule.getMoods(),
      this.$store.direct.dispatch.fatigueModule.getFatigues(),
      this.$store.direct.dispatch.workoutExecutionModule.getWorkoutExecutions(),
      this.$store.direct.dispatch.workoutPlanModule.getWorkoutSchedules(),
      this.$store.direct.dispatch.workoutPlanModule.getWorkoutPlanThumbnails()
    ]);
  }
});
</script>
