<template>
  <b-button
    @click="click"
    :disabled="disabled"
    variant="white"
    class="white-button"
  >
    <slot></slot>
  </b-button>
</template>
<script lang="ts">
import { BButton } from "bootstrap-vue";
import Vue from "vue";
export default Vue.extend({
  components: { BButton },
  props: {
    disabled: {
      type: Boolean,
      default: false
    }
  },
  methods: {
    click() {
      this.$emit("click");
    }
  }
});
</script>
<style scoped>
.white-button {
  border-radius: 4px;
  border: 1px solid #e7e7e7;
  padding-top: 4px;
  padding-bottom: 5px;
  width: 100%;
}
.white-button:hover {
  border: 1px solid #e7e7e7;
  background-color: #efefef;
}
</style>
