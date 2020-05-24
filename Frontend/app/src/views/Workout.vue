<template>
  <workout-plan-list />
</template>
<script lang="ts">
import WorkoutPlanList from "../components/workoutCards/WorkoutPlanList.vue";
import Vue from "vue";
export default Vue.extend({
  components: { WorkoutPlanList }
});
</script>
