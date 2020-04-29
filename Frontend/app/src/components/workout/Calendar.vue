<template>
  <b-overlay :show="calendarIsLoading">
    <b-container>
      <h1>Calendar</h1>
      <v-calendar @dayclick="updateHooverDay" is-expanded :attributes="attrs"></v-calendar>
      <b-sidebar v-model="open" id="sidebar-right" title="Sidebar" right shadow lazy class="white">
        <template v-slot:title>
          <h3>{{hooverDay}}</h3>
        </template>
        <b-container>
          <h3>Planned :</h3>
          <div v-for="(workoutSchedule,index) in workoutSchedules" :key="index">
            <b-button
              variant="white"
              block
              class="white-button"
              v-b-toggle="`plan-${index}`"
            >{{workoutSchedule.name}}</b-button>
            <b-collapse :id="`plan-${index}`">
              <WorkoutViewer :username="$store.state.username" :workoutName="workoutSchedule.name" />
            </b-collapse>
            <div class="separator" />
          </div>
          <b-button variant="white" block class="white-button">Add Workout Schedule (harder)</b-button>
          <h3>Executed :</h3>
          <div v-for="(workoutExecution,index) in workoutExecutions" :key="index">
            <b-button
              variant="white"
              block
              class="white-button"
              v-b-toggle="`execution-${index}`"
            >{{workoutExecution.name}}</b-button>
            <b-collapse :id="`execution-${index}`">
              <WorkoutExecutionViewer
                :username="$store.state.username"
                :workoutName="workoutExecution.name"
              />
            </b-collapse>
            <div class="separator" />
          </div>
          <b-button variant="white" block class="white-button">Add Workout Execution (easy)</b-button>
        </b-container>
      </b-sidebar>
    </b-container>
  </b-overlay>
</template>
<script>
import {
  BContainer,
  BSidebar,
  BOverlay,
  BButton,
  BCollapse
} from "bootstrap-vue";
import WorkoutViewer from "./WorkoutViewer";
import WorkoutExecutionViewer from "./WorkoutExecutionViewer";
const workoutKindsEnum = Object.freeze({
  workoutExecution: 0,
  workoutSchedule: 1
});
export default {
  name: "Calendar",
  components: {
    BContainer,
    BSidebar,
    WorkoutViewer,
    WorkoutExecutionViewer,
    BOverlay,
    BCollapse,
    BButton
  },
  mounted: function() {
    Promise.all([
      this.$store.dispatch("getBackLog").then(x => {
        x.forEach(y =>
          this.attrs.push({
            dot: "yellow",
            kind: workoutKindsEnum.workoutExecution,
            workoutName: y.name,
            dates: [new Date(y.executed)],
            popover: {
              label: `Executed: ${y.name}`
            }
          })
        );
        this.workoutSchedules = this.getWorkoutSchedules(new Date());
      }),
      this.$store.dispatch("getScheduledWorkouts").then(x => {
        x.forEach(y =>
          this.attrs.push({
            dot: "red",
            kind: workoutKindsEnum.workoutSchedule,
            dates: [new Date(y.scheduleDate)],
            workoutName: y.workoutPlanName,
            popover: {
              label: `Planned: ${y.workoutPlanName}`
            }
          })
        );
        this.workoutExecutions = this.getWorkoutExecutions(new Date());
      })
    ]).then(() => (this.calendarIsLoading = false));
  },
  methods: {
    getWorkoutExecutions: function(date) {
      return this.getWorkouts(workoutKindsEnum.workoutExecution, date);
    },
    getWorkoutSchedules: function(date) {
      return this.getWorkouts(workoutKindsEnum.workoutSchedule, date);
    },
    getWorkouts: function(workoutKind, date) {
      return this.attrs
        .filter(
          x =>
            x.kind === workoutKind &&
            x.dates.some(y => y.toDateString() === date.toDateString())
        )
        .map(x => ({ name: x.workoutName }));
    },
    updateHooverDay: function(day) {
      this.workoutSchedules = this.getWorkoutSchedules(day.date);
      this.workoutExecutions = this.getWorkoutExecutions(day.date);
      this.open = true;
      //v-b-toggle.sidebar-right;
      this.hooverDay = day.ariaLabel;
    }
  },
  data() {
    return {
      open:false,
      calendarIsLoading: true,
      workoutSchedules: [],
      workoutExecutions: [],
      hooverDay: new Date().toLocaleDateString(undefined, {
        weekday: "long",
        year: "numeric",
        month: "long",
        day: "numeric"
      }),
      attrs: [
        {
          key: "today",
          highlight: "blue",
          dates: new Date(),
          popover: {
            label: "today"
          }
        }
      ]
    };
  }
};
</script>
<style scoped>
.separator {
  height: 15px;
}
.white-button {
  border-radius: 4px;
  border: 1px solid #e7e7e7;
  padding-top: 4px;
  padding-bottom: 5px;
  background-color: white;
  width: -webkit-fill-available;
}
.white-button:hover {
  border: 1px solid #e7e7e7;
  background-color: #efefef;
}
.white{
  background-color: white;
}
</style>