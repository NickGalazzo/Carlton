<template>
<v-card class="home-for-dinner-card">
    <v-card-title primary-title>
        <div class="title">Home For Dinner</div>
    </v-card-title>

    <v-container fluid>
        <home-for-dinner-list v-bind:items="items" />
        <home-for-dinner-input />
    </v-container>
</v-card>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'

import colors from '../styles/master.scss';
import HomeForDinnerList from '../components/HomeForDinnerList.vue';
import HomeForDinnerInput from '../components/HomeForDinnerInput.vue';
import HomeForDinner from '../models/HomeForDinner.ts';

@Component({
    components: {
        HomeForDinnerList,
        HomeForDinnerInput
    }
})
export default class HomeForDinner extends Vue {
    @Prop() items!: HomeForDinner[];
}
</script>

<style lang="scss" scoped>
@import "../styles/master.scss";

.home-for-dinner-card {
    @extend %dashboard-card;
}
</style>
