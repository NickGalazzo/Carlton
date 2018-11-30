<template>
<v-list-tile class="home-for-dinner-person" avatar>
    <v-list-tile-avatar>
        <img :src="'https://www.w3schools.com/w3images/avatar2.png'">
    </v-list-tile-avatar>

        <v-list-tile-content>
            <v-list-tile-title>{{item.name}}</v-list-tile-title>
            <v-list-tile-sub-title class="home" v-if="item.isHomeForDinner">Home</v-list-tile-sub-title>
            <v-list-tile-sub-title v-if="!item.isHomeForDinner">{{item.reason}}</v-list-tile-sub-title>
        </v-list-tile-content>

        <v-list-tile-action>
            <v-icon :color="item.isHomeForDinner ? activeColor : 'grey'">mdi-food</v-icon>
        </v-list-tile-action>
</v-list-tile>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'
import colors from '../styles/master.scss';
import HomeForDinner from '../models/HomeForDinner.ts';

@Component
export default class HomeForDinner extends Vue {
    @Prop() item!: HomeForDinner;

    activeColor: string = colors.selected;
}
</script>

<style lang="scss" scoped>
@import "../styles/master.scss";

.home-for-dinner-person {
    max-width: 300px;

    .v-list-tile-sub-title {
        font-size: 10px;
    }

    .v-list__tile__sub-title {
        font-size: 12px;
    }

    .v-list__tile__sub-title.home {
        color: $active !important;
    }
}
</style>
