<template>
  <b-overlay :show="workoutPlansAreNotLoaded">
    <p>
      <b>Your workout plans</b>
    </p>
    <div vertical class="links-list">
      <p v-for="(workoutPlan, index) in workoutPlans" :key="index">
        <a class="link"> {{ workoutPlan.name }} </a>
      </p>
    </div>
    <a class="link"><b-icon-plus-circle />&nbsp;Create new Workout Plan</a>
  </b-overlay>
</template>
<script lang="ts">
import Vue from "vue";
import { BOverlay, BIconPlusCircle } from "bootstrap-vue";
import { WorkoutPlanCacheThumbnailModel } from "@/store/modules/workoutPlan/models/WorkoutPlanCacheThumbnailModel";

export default Vue.extend({
  components: { BOverlay, BIconPlusCircle },
  created() {
    this.$store.direct.dispatch.workoutPlanModule.getWorkoutPlanThumbnails();
  },
  computed: {
    workoutPlans(): Array<WorkoutPlanCacheThumbnailModel> | undefined {
      return this.$store.direct.getters.workoutPlanModule
        .workoutPlansThumbnails;
    },
    workoutPlansAreNotLoaded(): boolean {
      return !this.$store.direct.getters.workoutPlanModule
        .workoutPlansThumbnailsAreActual;
    }
  }
});
</script>
<style scoped>
.links-list {
  position: relative;
  overflow-y: scroll;
  max-height: 150px;
}
.link:focus,
.link:hover {
  color: rgba(0, 0, 0, 0.7);
  text-decoration: none;
}
.link {
  color: rgba(0, 0, 0, 0.5);
}
</style>
