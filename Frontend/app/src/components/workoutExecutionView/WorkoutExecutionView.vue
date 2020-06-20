<template>
  <div>
    <exercise-execution-card
      :key="index"
      v-for="(exercise, index) in exercises"
      :exerciseExecution="exercise"
    />
  </div>
</template>
<script lang="ts">
import Vue from "vue";
import ExerciseExecutionCard from "./ExerciseExecutionCard.vue";
import { WorkoutExecutionProp } from "../../propsModels/workoutExecutionView/WorkoutExecutionProp";
import { ExerciseExecutionProp } from "../../propsModels/workoutExecutionView/ExerciseExecutionProp";
export default Vue.extend({
  props: {
    workoutExecutionProps: Object as () => WorkoutExecutionProp
  },
  created() {
    Promise.all([
      this.$store.direct.dispatch.fatigueModule.getFatigues(),
      this.$store.direct.dispatch.moodModule.getMoods()
    ]).then();
  },
  components: { ExerciseExecutionCard }
});
</script>
