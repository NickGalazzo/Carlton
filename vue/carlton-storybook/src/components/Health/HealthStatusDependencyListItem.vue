<template>
  <v-list-tile>
    <v-layout row class="service-dependency-item">
      <v-flex xs3>
        <v-img :src="healthStatus.serviceIcon" height="50px" contain></v-img>
      </v-flex>
      <v-flex xs6>
        <v-list-tile-content>
          <v-list-tile-title>{{healthStatus.serviceName}}</v-list-tile-title>
        </v-list-tile-content>
      </v-flex>

      <v-flex xs3 class="health-status-indicator">
        <v-icon
          :color="healthStausDisplay.healthColor"
          class="right"
        >{{healthStausDisplay.healthIcon}}</v-icon>
      </v-flex>
    </v-layout>
  </v-list-tile>
</template>

<script lang="ts">
import { Vue, Component, Prop, Mixins } from "vue-property-decorator";
import BaseDashboardCard from "../Base/BaseDashboardCard.vue";
import HealthStatusDependencyList from "./HealthStatusDependencyList.vue";
import {
  BaseHealthStatusModel,
  HealthStatusModel,
  HealthStatusDependencyModel,
  HealthStatusDisplayModel
} from "../../models/HealthStatusModel";
import HealthStatusDisplayMixin from "../../mixins/HealthStatusDisplayMixin";
import colors from "../../styles/colors.scss";

@Component({
  components: {
    BaseDashboardCard,
    HealthStatusDependencyList
  }
})
export default class HealthStatusDependencyListItem extends Mixins(
  HealthStatusDisplayMixin
) {
  @Prop() healthStatus!: HealthStatusDependencyModel;
}
</script>

<style lang="scss" scoped>
@import "../../styles/master.scss";
.service-dependency-item {
  max-width: 300px;

  .health-status-indicator {
    margin: auto;
  }
}
</style>
