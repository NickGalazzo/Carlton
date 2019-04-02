<template>
<v-layout row class="status-row">
    <v-flex xs4>
        <v-icon :color="$style.statusIconColor" class="right domain-icon">{{status.icon}}</v-icon>
    </v-flex>
    <v-spacer></v-spacer>
    <v-flex xs4 v-if="status.statusId === 1">
        <v-icon :color="$style.completedColor" class="right status-icon">mdi-checkbox-marked-circle</v-icon>
    </v-flex>
      <v-flex xs4 v-else>
        <v-icon :color="$style.pendingColor" class="right status-icon">mdi-alert</v-icon>
    </v-flex>
    <v-spacer></v-spacer>
</v-layout>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'
import ApartmentStatusModel from "../../models/ApartmentStatusModel";

@Component
export default class ApartmentStatusItem extends Vue {
    @Prop() status!: ApartmentStatusModel;
}
</script>

<style lang="scss" module>
@import "../../styles/master.scss";

.status-row {
    max-width: 300px;
}

:export {
    completedColor: $CompletedColor;
    pendingColor: $pendingColor;
    statusIconColor: $statusIconColor;
}
</style>
