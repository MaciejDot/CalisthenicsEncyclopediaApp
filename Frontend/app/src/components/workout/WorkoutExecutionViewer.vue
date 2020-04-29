<template>
<b-overlay :show="workoutExecutionIsLoading">
  <b-container ref="workout-container">
    <b-card class="white-card">
      <svg viewBox="0 0 90 90" v-if="isOwner" @click.prevent.stop="openContextMenu($event)">
        <path
          d="m 13 45 a 1 1 0 0 0 15 0 a 1 1 0 0 0 -15 0 z m 25 0 a 1 1 0 0 0 15 0 a 1 1 0 0 0 -15 0 z m 25 0 a 1 1 0 0 0 15 0 a 1 1 0 0 0 -15 0 z "
        />
      </svg>
      <b-row>
        <b-col cols="12" class="center-text">
          <h1>{{nameOfWorkout}}</h1>
        </b-col>
        <b-col cols="12" class="center-text">{{descriptionOfWorkout}}</b-col>
        <b-col>
          <b-form-group label="Date of Workout">{{dateOfWorkout}}</b-form-group>
        </b-col>
      </b-row>
    </b-card>
    <b-card class="white-card" v-for="(row, index) in rowsOfWorkout" :key="index">
      <div>
        <b-row>
          <b-col cols="12" sm="6" md="4" lg="3">
            <b-form-group label="Exercise">{{row.selectedExercise.label}}</b-form-group>
          </b-col>
          <b-col cols="12" sm="6" md="4" lg="3">
            <b-form-group label="Description">{{row.description}}</b-form-group>
          </b-col>
          <b-col cols="12" sm="6" md="4" lg="3">
            <b-form-group label="Reps/Seconds">{{row.reps}}</b-form-group>
          </b-col>
          <b-col cols="12" sm="6" md="4" lg="3">
            <b-form-group label="Additional Kgs">{{row.additionalKgs}}</b-form-group>
          </b-col>
          <b-col cols="12" sm="6" md="4" lg="3">
            <b-form-group label="series">{{row.series}}</b-form-group>
          </b-col>
          <b-col cols="12" sm="6" md="4" lg="3">
            <b-form-group label="breaks (in s.)">{{row.break}}</b-form-group>
          </b-col>
        </b-row>
      </div>
    </b-card>
    <b-card class="white-card">
      <b-row>
        <b-col cols="12" sm="6" md="4" lg="3">
          <b-form-group label="Mood after">{{mood.label}}</b-form-group>
        </b-col>
        <b-col cols="12" sm="6" md="4" lg="3">
          <b-form-group label="Fatigue Level after">{{fatigue.label}}</b-form-group>
        </b-col>
      </b-row>
    </b-card>
    <vue-simple-context-menu
      ref="menu"
      :elementId="`context-menu-${random}`"
      :options="contextMenuOptions"
      @option-clicked="optionClicked"
    ></vue-simple-context-menu>
    <b-modal ref="modal" hide-footer hide-header>
      <div class="d-block text-center">
        <h3>Are you sure you want to delete workout?</h3>
      </div>
      <b-row>
        <b-col cols="5">
          <b-button variant="white" class="white-button" @click="hideModal">No</b-button>
        </b-col>
        <b-col cols="2" />
        <b-col cols="5">
          <b-button variant="white" class="white-button" @click="deleteWorkout">Yes</b-button>
        </b-col>
      </b-row>
    </b-modal>
  </b-container>
  </b-overlay>
</template>
<script>
import { BContainer, BCard, BCol, BRow, BModal, BButton } from "bootstrap-vue";
import { mapState } from "vuex";
const contextMenuOptionsEnum = Object.freeze({
  edit: "Edit",
  delete: "Delete",
  exportCSV: "Export CSV"
});
export default {
  name: "WorkoutExecutionViewer",
  components: { BContainer, BCard, BCol, BRow, BModal, BButton },
  computed: mapState({
    isOwner: function(state) {
      return state.username === this.username;
    }
  }),
  props: { workoutName: {}, username: {} },
  methods: {
    openContextMenu(event) {
      this.$refs.menu.showMenu(event);
    },
    optionClicked(event) {
      let optionsActions = {
        Edit: () => this.edit(),
        Delete: () => this.showModal(),
        "Export CSV": () => this.exportToCSV()
      };
      optionsActions[event.option.name]();
    },
    exportToCSV() {
      let dataSeparator = ";";
      let dataTitles = `Exercise Name${dataSeparator}Reps${dataSeparator}Additional kgs${dataSeparator}Series${dataSeparator}Breaks${dataSeparator}Description`;
      let dataString = this.rowsOfWorkout
        .map(
          x =>
            `${x.selectedExercise.label}${dataSeparator}${
              x.reps
            }${dataSeparator}${x.additionalKgs}${dataSeparator}${
              x.series
            }${dataSeparator}${x.break}${dataSeparator}${
              x.description == null ? "" : x.description
            }`
        )
        .join("\n");
      let additionalDataRows = `Date Of Workout${dataSeparator}${this.dateOfWorkout}\nMood After${dataSeparator}${this.mood.label}\nFatigue After${dataSeparator}${this.fatigue.label}`;
      let csv = `${dataTitles}\n${dataString}\n${additionalDataRows}`;
      let hiddenElement = document.createElement("a");
      hiddenElement.href = "data:text/csv;charset=utf-8," + encodeURI(csv);
      hiddenElement.target = "_blank";
      hiddenElement.download = `${this.workoutName}.csv`;
      hiddenElement.click();
    },
    edit() {
      this.$router.push({
        path: `/WorkoutExecution/${this.username}/${this.workoutName}`
      });
    },
    showModal() {
      this.$refs["modal"].show();
    },
    hideModal() {
      this.$refs["modal"].hide();
    },
    deleteWorkout() {
      this.$store
        .dispatch("deleteWorkoutExecutionView", {
          workoutName: this.workoutName
        })
        .then(() => {
          this.$router.push({ path: "/workout" });
        });
    },
    makepublic() {}
  },
  mounted: function() {
    Promise.all([
      this.$store.dispatch("getFatigues"),
      this.$store.dispatch("getMoods")
    ])
      .then(response => {
        this.fatigues = response[0];
        this.moods = response[1];
      })
      .then(() => {
        this.$store
          .dispatch("getWorkoutExecutionView", {
            username: this.username,
            workoutName: this.workoutName
          })
          .then(data => {
            this.workoutExecutionIsLoading = false;
            this.nameOfWorkout = data.name;
            this.descriptionOfWorkout = data.description;
            this.dateOfWorkout = new Date(
              data.dateOfWorkout
            ).toLocaleDateString(undefined, {
              weekday: "long",
              year: "numeric",
              month: "long",
              day: "numeric"
            });
            this.mood = {
              value: data.mood,
              label: this.moods.find(x => x.value == data.mood).label
            };
            this.fatigue = {
              value: data.fatigue,
              label: this.fatigues.find(x => x.value == data.fatigue).label
            };
            this.rowsOfWorkout = data.exercises.map(x => {
              return {
                selectedExercise: {
                  label: x.name,
                  value: x.exerciseId
                },
                reps: x.reps,
                additionalKgs: x.additionalKgs,
                description: x.description,
                break: x.break,
                series: x.series
              };
            });
          })
          .catch(() => {
            this.workoutExecutionIsLoading = false;
            this.$router.push({ path: "/404" });
          });
      });
    this.contextMenuOptions = Object.keys(contextMenuOptionsEnum).map(key => ({
      name: contextMenuOptionsEnum[key]
    }));
    document
      .getElementById("app")
      .appendChild(document.getElementById(`context-menu-${this.random}`));
  },
  data: function() {
    return {
      workoutExecutionIsLoading: true,
      moods: [],
      fatigues: [],
      random: Math.random(),
      contextMenuOptions: [],
      rowsOfWorkout: [],
      descriptionOfWorkout: null,
      nameOfWorkout: null,
      dateOfWorkout: null,
      mood: { label: "" },
      fatigue: { label: "" }
    };
  }
};
</script>
<style lang="scss" scoped>
.white-button {
  border-radius: 4px;
  border: 1px solid #e7e7e7;
  padding-top: 4px;
  padding-bottom: 5px;
  width: -webkit-fill-available;
}
.white-button:hover {
  border: 1px solid #e7e7e7;
  background-color: #efefef;
}
.vue-simple-context-menu {
  top: 0;
  left: 0;
  margin: 0;
  padding: 0;
  display: none;
  list-style: none;
  z-index: 1000000;
  background-color: white;
  border: 1px solid #e7e7e7;
  border-radius: 2px;

  &--active {
    display: block;
  }

  &__item {
    display: flex;
    cursor: pointer;
    padding: 5px 15px;
    align-items: center;

    &:hover {
      background-color: #efefef;
    }
  }
  li {
    &:first-of-type {
      margin-top: 4px;
    }

    &:last-of-type {
      margin-bottom: 4px;
    }
  }
}
svg {
  max-width: 30px;
  float: right;
  opacity: 0.5;
  cursor: pointer;
}
svg:hover {
  opacity: 0.7;
}
.center-text {
  text-align: center;
}
.white-card {
  padding: 10px;
  border-radius: 3px;
  border: 1px solid #e7e7e7;
  margin: 10px;
  color: black;
}
</style>