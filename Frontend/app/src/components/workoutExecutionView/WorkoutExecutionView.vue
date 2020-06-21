<template>
  <div>
    <workout-execution-title-view
      :workoutExecutionTitle="workoutExectionProp"
    />
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
import WorkoutExecutionTitleView from "./WorkoutExecutionTitleCard.vue";
export default Vue.extend({
  props: {
    workoutExecutionProps: Object as () => WorkoutExecutionProp
  },
  components: { ExerciseExecutionCard, WorkoutExecutionTitleView }
});
</script>
