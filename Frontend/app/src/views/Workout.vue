<template>
  <div>
    <b-container>
      <b-row>
        <b-col lg="6" sm="12">
          <workout-card>
            <workout-plan-list />
          </workout-card>
        </b-col>
        <b-col lg="6" sm="12">
          <workout-card>
            <calendar />
          </workout-card>
        </b-col>
      </b-row>
    </b-container>
    <b-sidebar
      v-model="open"
      id="sidebar-right"
      title="Sidebar"
      right
      shadow
      lazy
      class="white"
      width="90%"
    >
     <calendar-day/>
    </b-sidebar>
  </div>
</template>
<script lang="ts">
import WorkoutPlanList from "../components/workoutCards/WorkoutPlanList.vue";
import Calendar from "../components/workoutCards/Calendar.vue";
import WorkoutCard from "../components/workoutCards/WorkoutCard.vue";
import { BContainer, BRow, BCol, BSidebar } from "bootstrap-vue";
import CalendarDay from "../components/workoutSiderbar/CalendarDay.vue";
import Vue from "vue";
export default Vue.extend({
  components: {
    WorkoutPlanList,
    Calendar,
    WorkoutCard,
    BContainer,
    BRow,
    BCol,
    BSidebar,
    CalendarDay
  },
  data() {
    return { open: true };
  }
});
</script>
