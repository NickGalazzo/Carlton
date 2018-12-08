import { storiesOf } from "@storybook/vue";
import {
  withKnobs,
  text,
  boolean,
  number,
  select
} from "@storybook/addon-knobs";

import { action } from "@storybook/addon-actions";

import NavDrawer from "../components/Nav/NavDrawer.vue";
import HealthCard from "../components/Health/HealthCard.vue";







//Dashboard Page
import GarbageCard from "../components/GarbageCard.vue";



storiesOf("Nav Drawer", module).add("Default", () => ({
  components: { NavDrawer },
  template: "<nav-drawer />"
}));









storiesOf("Garbage Card", module).add("Defeault", () => ({
  components: { GarbageCard },
  template: "<garbage-card />"
}));

storiesOf("Health Card", module).add("Default", () => ({
  components: { HealthCard },
  template: "<health-card/>"
}));
