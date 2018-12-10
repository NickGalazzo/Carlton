<template>
  <v-card class="health-card dashboard-card-small">
    <v-icon
      :color="healthStausDisplay.healthColor"
      class="right status-icon"
    >{{healthStausDisplay.healthIcon}}</v-icon>
    <v-card-title primary-title>
      <v-layout row>
        <v-flex xs2>
          <div class="card-img">
            <v-icon
              :color="healthStausDisplay.healthColor"
              class="service-icon"
              size="50"
            >{{healthStatus.serviceIcon}}</v-icon>
          </div>
        </v-flex>
        <v-flex xs10>
          <v-subheader>{{healthStatus.serviceName}}</v-subheader>
        </v-flex>
      </v-layout>
    </v-card-title>
    <v-card-content>
      <v-card-actions>
        <v-btn flat>Details</v-btn>
        <v-spacer></v-spacer>
        <v-btn icon @click="show = !show">
          <v-icon>{{ show ? 'mdi-chevron-up' : 'mdi-chevron-down' }}</v-icon>
        </v-btn>
      </v-card-actions>
      <v-slide-y-transition v-show="show">
        <v-list subheader two-line v-show="show">
          <health-status-dependency-list :health-statuses="healthStatus.dependencies"/>
        </v-list>
      </v-slide-y-transition>
    </v-card-content>
  </v-card>
</template>

<script lang="ts">
import { Vue, Component, Prop, Mixins } from "vue-property-decorator";
import BaseDashboardCard from "../Base/BaseDashboardCard.vue";
import HealthStatusDependencyList from "./HealthStatusDependencyList.vue";
import {
  HealthStatusModel,
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
export default class HealthStatusCard extends Mixins(HealthStatusDisplayMixin) {
  @Prop() healthStatus!: HealthStatusModel;
  show: boolean = false;
}
</script>

<style lang="scss" scoped>
@import "../../styles/master.scss";

.health-card {
  @extend %dashboard-card;

  height: 150px;

  i.status-icon {
    padding: 5px;
  }

  .v-card__title {
    .v-subheader {
      margin-left: 20px;
    }

    i.service-icon {
      margin: 0px;
    }
  }
}
</style>
