<template functional>
<v-list-tile class="v-list-item">
    <v-list-tile-content>
        <v-subheader>{{props.item.name}}</v-subheader>
        <v-progress-linear v-if="props.item.percentRemaining>=75" :color="$style.highColor" height="5" v-bind:value="props.item.percentRemaining"></v-progress-linear>
        <v-progress-linear v-else-if="props.item.percentRemaining<50" :color="$style.lowColor" height="5" v-bind:value="props.item.percentRemaining"></v-progress-linear>
        <v-progress-linear v-else :color="$style.mediumColor" height="5" v-bind:value="props.item.percentRemaining"></v-progress-linear>
    </v-list-tile-content>

    <v-list-tile-action>
        <v-btn flat small :color="$style.buttonColor">View</v-btn>
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
import HouseHoldItemModel from "../../models/HouseHoldItemModel";

@Component
export default class HouseHoldItem extends Vue {
    @Prop() item!: HouseHoldItem;
}
</script>

<style lang="scss" module>
@import "../../styles/master.scss";

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

:export {
    highColor: $highColor;
    mediumColor: $mediumColor;
    lowColor: $lowColor;
    buttonColor: $buttonColor;
}
</style>
