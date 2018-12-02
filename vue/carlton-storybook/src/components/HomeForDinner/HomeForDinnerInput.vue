<template>
<div class="home-for-dinner-input">
    <v-layout>
        <v-spacer></v-spacer>
        <v-flex class="heading-text" xs12>
            <span >Are you home for dinner?</span>
        </v-flex>
        <v-spacer></v-spacer>
    </v-layout>
    <v-layout class="home-for-dinner-toggle">
        <v-spacer></v-spacer>
        <v-flex xs8>
            <v-switch v-model="isHomeForDinner" :color="$style.activeColor"></v-switch>
        </v-flex>
        <v-spacer></v-spacer>
    </v-layout>
    <v-layout>
        <v-spacer></v-spacer>
        <v-text-field :disabled="isHomeForDinner==true" label="Where will you be?"></v-text-field>
        <v-spacer></v-spacer>
    </v-layout>
</div>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'
import HomeForDinner from '../../models/HomeForDinnerModel';

@Component
export default class HomeForDinnerInput extends Vue {
    isHomeForDinner: boolean = false;
}
</script>

<style lang="scss" module>
@import "../../styles/master.scss";

.home-for-dinner-input {
    max-width: 300px;

    .heading-text {
        text-align: center;
    }

    .layout.home-for-dinner-toggle {
        height: 30px;
        margin-top: 20px;

        .v-input--selection-controls {
            margin-top: 0px;
        }
    }

    .v-text-field {
        margin-top: 15px;
    }
}

:export {
    activeColor: $activeColor;
}
</style>
