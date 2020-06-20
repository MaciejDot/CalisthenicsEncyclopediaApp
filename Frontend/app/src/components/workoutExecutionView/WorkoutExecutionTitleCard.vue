<template>
  <round-card>
    <h4>{{ workoutExecutionTitle.name }}</h4>
    <b-row>
      <label-and-value
        label="Description"
        :value="workoutExecutionTitle.description"
        :compensate="noneCompensation"
      />
    </b-row>
    <b-row>
      <label-and-value
        label="Mood After"
        :value="workoutExecutionTitle.mood"
        :compensate="partialCompensation"
      />
      <label-and-value
        label="Fatigue After"
        :value="workoutExecutionTitle.fatigue"
        :compensate="partialCompensation"
      />
    </b-row>
  </round-card>
</template>
<script lang="ts">
import Vue from "vue";
import RoundCard from "../common/RoundCard.vue";
import LabelAndValue from "../common/LabelAndValue.vue";
import { BRow } from "bootstrap-vue";
import { WorkoutExecutionTitleProp } from "../../propsModels/workoutExecutionView/WorkoutExecutionTitleProp";
import { CompensationEnum } from "../../propsModels/common/CompensationEnum";
export default Vue.extend({
  props: {
    workoutExecutionTitle: Object as () => WorkoutExecutionTitleProp
  },
  computed: {
    noneCompensation: () => CompensationEnum.None,
    partialCompensation: () => CompensationEnum.Partial
  },
  components: { RoundCard, LabelAndValue, BRow }
});
</script>
