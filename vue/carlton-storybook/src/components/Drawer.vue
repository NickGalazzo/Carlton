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
            color="transparent"
          >
            <v-img
              :src="'https://media.istockphoto.com/vectors/urban-family-home-classic-brownstone-building-vector-illustration-vector-id947577838'"
              height="70"
              contain
            />
          </v-list-tile-avatar>
          <v-list-tile-title class="title">
            <span>Carlton</span>
          </v-list-tile-title>
        </v-list-tile>
        
        <v-list-tile
          v-for="(link, i) in links"
          :key="i"
          :to="link.to"
          :active-class="color"
          class="v-list-item active">
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
export default class Drawer extends Vue {
  //Data
  links: Link[];

  message: string = "Hello!";
  logo: "./assets/house.jpg";

  mounted() {
    this.logo = "../../assets/house.jpg";
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
        icon: "mdi-clipboard-check",
        text: "Todos"
      },
      {
        to: "/",
        icon: "mdi-spray-bottle",
        text: "Apartment Cleaning"
      },
      {
        to: "/table-list",
        icon: "mdi-cart",
        text: "Household Items"
      },
      {
        to: "/table-list",
        icon: "mdi-food-fork-drink",
        text: "Home for Dinner"
      },
      {
        to: "/table-list",
        icon: "mdi-washing-machine",
        text: "Laundry"
      },
      {
        to: "/table-list",
        icon: "mdi-delete",
        text: "Garbage"
      },
      {
        to: "/typography",
        icon: "mdi-heart",
        text: "Application Health"
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
