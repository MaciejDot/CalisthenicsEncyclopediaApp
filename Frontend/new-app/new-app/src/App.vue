<template>
  <v-app>
    <v-content>
    <v-navigation-drawer
      color="primary"
      :expand-on-hover="true"
      :mini-variant="true"
      :right="false"
      :permanent="false"
      absolute
      dark
    >
      <v-list dense nav class="py-0">
        <v-list-item two-line class="px-0">
          <v-list-item-avatar>
            <v-icon>{{account}}</v-icon>
          </v-list-item-avatar>
          <v-list-item-content>
            <v-list-item-title>Calendar</v-list-item-title>
            <v-list-item-subtitle>Alpha</v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>

        <v-divider></v-divider>

        <v-list-item v-for="item in items" :key="item.title" link :to="item.to">
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
       <template v-slot:append>
        <div class="pa-2">
          <v-btn block>Logout</v-btn>
        </div>
      </template>
    </v-navigation-drawer>
      <router-view style="margin-left: 56px;"></router-view>
    </v-content>
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import { mdiViewDashboard, mdiAccount, mdiCalendar, mdiCog } from "@mdi/js";
export default Vue.extend({
  name: "App",


  data: () => ({
    items: [
      {
        title: "Dashboard",
        icon: mdiViewDashboard,
        to: "/Dashboard"
      },
      {
        title: "Calendar",
        icon: mdiCalendar,
        to: "/Calendar"
      },
      {
        title: "Settings",
        icon: mdiCog,
        to: "/Settings"
      }
    ],
    account: mdiAccount,
  })
});
</script>
