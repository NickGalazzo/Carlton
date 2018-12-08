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
            <v-switch v-model="isHomeForDinner" :color="activeColor"></v-switch>
        </v-flex>
        <v-spacer></v-spacer>
    </v-layout>
    <v-layout>
        <v-spacer></v-spacer>
        <v-text-field value="test" :disabled="isHomeForDinner==true" label="Where will you be?" v-model="reason"></v-text-field>
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
import HomeForDinnerModel from '../../models/HomeForDinnerModel';
import colors from '../../styles/colors.scss';

@Component
export default class HomeForDinnerInput extends Vue {
    @Prop({
        default: {
            isHomeForDinner: false,
            reason: ""
        }
    }) model!: HomeForDinnerModel;

    isHomeForDinner: boolean = this.model.isHomeForDinner;
    reason: string = this.model.reason;
    activeColor: string = colors.activeColor;
}
</script>

<style lang="scss" scoped>
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

        /deep/ .v-input--selection-controls__input {
            margin-right: auto;
            margin-left: auto;
            display: block;
        }
    }

    .v-text-field {
        margin-top: 15px;
    }
}
</style>
