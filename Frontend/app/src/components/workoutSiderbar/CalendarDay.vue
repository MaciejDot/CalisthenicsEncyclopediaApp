<template>
  <div>
    <h4>{{ selectedDate }}</h4>
    <workout-execution-view
      v-for="(workoutExecution, index) in workoutExecutions"
      :key="index"
      :workoutExecution="workoutExecution"
    />
  </div>
</template>
<script lang="ts">
import Vue from "vue";
import WorkoutExecutionView from "../workoutExecutionView/WorkoutExecutionView.vue";
export default Vue.extend({
  props: {
    selectedDate: Date
  },
  components: {
    WorkoutExecutionView
  },
  data() {
    return {
      workoutExecutions: this.$store.direct.getters.workoutExecutionModule
        .workoutExecutionsThumbnails,
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
