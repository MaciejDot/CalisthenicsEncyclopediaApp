<template>
  <b-col cols="12" :md="mdColumn()" :lg="lgColumn()">
    <b>{{ label }}</b>
    <br />
    {{ value }}
  </b-col>
</template>
<script lang="ts">
import Vue from "vue";
import { BCol } from "bootstrap-vue";
import { CompensationEnum } from "../../propsModels/common/CompensationEnum";
const compensationLgColumn = {
  [CompensationEnum.Full]: "3",
  [CompensationEnum.Partial]: "6",
  [CompensationEnum.None]: "12"
};
export default Vue.extend({
  components: { BCol },
  props: {
    label: String,
    value: String,
    compensate: Object as () => CompensationEnum
  },
  methods: {
    mdColumn(): string {
      return this.compensate != CompensationEnum.None ? "6" : "12";
    },
    lgColumn(): string {
      return compensationLgColumn[this.compensate];
    }
  }
});
</script>
