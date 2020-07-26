<template>
  <v-sheet height="600">
      <v-calendar
        ref="calendar"
        :event-overlap-threshold="30"
      ></v-calendar>
    </v-sheet>
</template>

<script lang="ts">
// @ is an alias to /sr
export default {
  name: "Home"
};
</script>