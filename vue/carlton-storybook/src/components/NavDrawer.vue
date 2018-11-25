<template>
<v-navigation-drawer id="app-drawer" permanent dark :mini-variant.sync="mini">
    <v-layout class="fill-height" tag="v-list" column>
        <v-list-tile avatar>
            <v-list-tile-avatar color="transparent">
                <v-img :src="'https://media.istockphoto.com/vectors/urban-family-home-classic-brownstone-building-vector-illustration-vector-id947577838'" height="70" contain />
            </v-list-tile-avatar>
            <v-list-tile-title class="title">
                <span>Carlton UI</span>
            </v-list-tile-title>
            <v-list-tile-action>
                <v-btn icon @click.stop="mini = !mini">
                    <v-icon v-show="!mini">menu</v-icon>
                </v-btn>
            </v-list-tile-action>
        </v-list-tile>

        <v-list-tile v-for="(link, i) in links" @click="active = i" :key="i" :to="link.to" v-bind:class="{active: active == i}" class="v-list-item">
            <v-list-tile-action>
                <v-icon>{{ link.icon }}</v-icon>
            </v-list-tile-action>
            <v-list-tile-title v-text="link.text" />
        </v-list-tile>

    </v-layout>
</v-navigation-drawer>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import NavLink from "../models/NavLink";
import json from '../data/nav.json';

@Component
export default class NavDrawer extends Vue {
    //Data
    links: NavLink[] = json;
    logo!: "";
    mini: boolean = false;
    active: number = 0;

    mounted() {
        this.logo = "";
    }
}
</script>

<style lang="scss" scoped>
@import "../styles/master.scss";

#app-drawer {
    .v-list-item.active {
        background-color: $selected;
    }

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
