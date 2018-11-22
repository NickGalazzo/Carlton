<template>
  <v-navigation-drawer
    id="app-drawer"
    app
    dark
    floating
    persistent
    mobile-break-point="991"
    width="260"
  >

      <v-layout
        class="fill-height"
        tag="v-list"
        column
      >    
      <v-list-tile avatar>
          <v-list-tile-avatar
            color="white"
          >
            <v-img
              :src="logo"
              height="34"
              contain
            />
          </v-list-tile-avatar>
          <v-list-tile-title class="title">
            Vuetify MD
          </v-list-tile-title>
        </v-list-tile>
        
        <v-list-tile
          v-for="(link, i) in links"
          :key="i"
          :to="link.to"
          :active-class="color"
          class="v-list-item">
          <v-list-tile-action>
            <v-icon>{{ link.icon }}</v-icon>
          </v-list-tile-action>
          <v-list-tile-title
            v-text="link.text"
          />
        </v-list-tile>
      
      </v-layout>

  </v-navigation-drawer>
</template>

<script script lang="ts">
import Vue from "vue";
import Vue, { PropOptions } from "vue";
import Component from "vue-class-component";

type Link = {
  to: String;
  icon: String;
  text: String;
};

// The @Component decorator indicates the class is a Vue component
@Component({
  props: {
    logo: String
  }
})
export default class CoreDrawer extends Vue {
  //Data
  links: Link[];

  message: string = "Hello!";
  logo: "./img/vuetifylogo.png";

  mounted() {
    this.links = [
      {
        to: "/dashboard",
        icon: "mdi-view-dashboard",
        text: "Dashboard"
      },
      {
        to: "/user-profile",
        icon: "mdi-account",
        text: "User Profile"
      },
      {
        to: "/table-list",
        icon: "mdi-clipboard-outline",
        text: "Table List"
      },
      {
        to: "/typography",
        icon: "mdi-format-font",
        text: "Typography"
      },
      {
        to: "/icons",
        icon: "mdi-chart-bubble",
        text: "Icons"
      },
      {
        to: "/maps",
        icon: "mdi-map-marker",
        text: "Maps"
      },
      {
        to: "/notifications",
        icon: "mdi-bell",
        text: "Notifications"
      }
    ];
  }
}
</script>


<style lang="scss">
#app-drawer {
  .v-list__tile {
    border-radius: 4px;

    &--buy {
      margin-top: auto;
      margin-bottom: 17px;
    }
  }

  .v-image__image--contain {
    top: 9px;
    height: 60%;
  }

  .search-input {
    margin-bottom: 30px !important;
    padding-left: 15px;
    padding-right: 15px;
  }
}
</style>
