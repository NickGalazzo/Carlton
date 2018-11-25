<template>
<v-list-tile class="v-list-item">
    <v-list-tile-content>
        <v-subheader>{{item.name}}</v-subheader>
        <v-progress-linear v-if="item.percentRemaining>=75" color="green" height="5" v-bind:value="item.percentRemaining"></v-progress-linear>
        <v-progress-linear v-else-if="item.percentRemaining<50" color="red" height="5" v-bind:value="item.percentRemaining"></v-progress-linear>
        <v-progress-linear v-else color="yellow" height="5" v-bind:value="item.percentRemaining"></v-progress-linear>
    </v-list-tile-content>

    <v-list-tile-action>
        <v-btn flat small color="blue">View</v-btn>
    </v-list-tile-action>
</v-list-tile>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator';
import HouseHoldItem from "../models/HouseHoldItem.ts";

@Component
export default class HouseHoldItem extends Vue {
    @Prop() item!: HouseHoldItem;
}
</script>

<style lang="scss" scoped>
@import "../styles/master.scss";

.v-list-item {
    max-width: 300px;

    .v-subheader {
        padding: 0px;
    }

    .v-progress-linear {
        max-width: 200px;
        margin-top: 0px;
    }
}
</style>
