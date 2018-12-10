// mixin.js
import { Vue, Component, Prop } from "vue-property-decorator";
import {
  BaseHealthStatusModel,
  HealthStatusDisplayModel
} from "../models/HealthStatusModel";
import colors from "../styles/colors.scss";

@Component
export default class HealthStatusDisplayMixin extends Vue {
  @Prop() healthStatus!: BaseHealthStatusModel;

  //calculated
  get healthStausDisplay() : HealthStatusDisplayModel {
    switch (this.healthStatus.serviceHealthStatus) {
      case 1:
        return new HealthStatusDisplayModel(
          colors.healthy,
          "mdi-check-circle-outline"
        );
      case 2:
        return new HealthStatusDisplayModel(colors.degraded, "mdi-alert");
      case 3:
        return new HealthStatusDisplayModel(colors.error, "error");
      default:
          throw "Invalid status type";
    }
  }
}
