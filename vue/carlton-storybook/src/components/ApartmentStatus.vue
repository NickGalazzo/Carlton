<template>
<v-layout row class="status-row">
    <v-flex xs4>
        <v-icon :color="neutralIconColor" class="right">{{status.icon}}</v-icon>
    </v-flex>
    <v-spacer></v-spacer>
    <v-flex xs4 v-if="status.statusId === 1">
        <v-icon :color="true ? activeColor : 'grey'" class="right">mdi-checkbox-marked-circle</v-icon>
    </v-flex>
      <v-flex xs4 v-else>
        <v-icon color="#fec00a" class="right">mdi-alert</v-icon>
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

import colors from '../styles/master.scss';

@Component
export default class ApartmentStatus extends Vue {
    @Prop() status!: ApartmentStatus;

    //Data
    activeColor = "";
    neutralIconColor = "";

    mounted() {
        this.activeColor = colors.selected;
        this.neutralIconColor = colors.neutralIcon;
        console.log(status);
    }
}
</script>

<style lang="scss" scoped>
@import "../styles/master.scss";

.status-row {
    max-width: 300px;
}
</style>
