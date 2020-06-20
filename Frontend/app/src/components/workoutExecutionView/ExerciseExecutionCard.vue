<template>
  <round-card>
    <b-row>
      <label-and-value
        label="Exercise Name"
        :value="exerciseExecution.exerciseName"
        :compensate="fullCompensation"
      />
      <label-and-value
        label="Series"
        :value="exerciseExecution.series"
        :compensate="fullCompensation"
      />
      <label-and-value
        label="Reps"
        :value="exerciseExecution.reps"
        :compensate="fullCompensation"
      />
      <label-and-value
        label="Additional Kgs"
        :value="exerciseExecution.additionalKgs"
        :compensate="fullCompensation"
      />
      <label-and-value
        label="Break"
        :value="exerciseExecution.break"
        :compensate="fullCompensation"
      />
      <label-and-value
        label="Description"
        :value="exerciseExecution.description"
        :compensate="fullCompensation"
      />
    </b-row>
  </round-card>
</template>
<script lang="ts">
import Vue from "vue";
import { BRow } from "bootstrap-vue";
import RoundCard from "../common/RoundCard.vue";
import LabelAndValue from "../common/LabelAndValue.vue";
import { ExerciseExecutionProp } from "../../propsModels/workoutExecutionView/ExerciseExecutionProp";
import { CompensationEnum } from "../../propsModels/common/CompensationEnum";
export default Vue.extend({
  components: {
    RoundCard,
    BRow,
    LabelAndValue
  },
  computed: {
    fullCompensation: () => CompensationEnum.Full
  },
  props: {
    exerciseExecution: Object as () => ExerciseExecutionProp
  }
});
</script>
