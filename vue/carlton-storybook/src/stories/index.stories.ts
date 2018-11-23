/* eslint-disable react/react-in-jsx-scope, react/no-this-in-sfc */

import { storiesOf } from "@storybook/vue";
import { action } from "@storybook/addon-actions";

import Welcome from "../components/Welcome.vue";
import Drawer from "../components/Drawer.vue";
import HealthCard from "../components/HealthCard.vue";
import AggregateCard from "../components/AggregateCard.vue";
import GarbageCard from "../components/GarbageCard.vue";
import HomeForDinner from "../components/HomeForDinner.vue";
import ApartmentStatus from "../components/ApartmentStatus.vue";
import HouseHoldItems from "../components/HouseHoldItems.vue";
import Todos from "../components/Todos.vue";
import Feed from "../components/Feed.vue";

import xxx from "../components/HealthCardX.vue";

storiesOf("Nav Drawer", module).add("Default", () => ({
  components: { Drawer },
  template: "<drawer/>"
}));

storiesOf("Health Card", module).add("Default", () => ({
  components: { HealthCard },
  template: "<health-card/>"
}));

storiesOf("Garbage Card", module).add("Defeault", () => ({
  components: { GarbageCard },
  template: "<garbage-card />"
}));

storiesOf("Aggregate Card", module).add("Default", () => ({
  components: { AggregateCard },
  template: "<aggregate-card/>"
}));

storiesOf("Home for Dinner", module).add("Default", () => ({
  components: { HomeForDinner },
  template: "<home-for-dinner/>"
}));

storiesOf("Apartment Status", module).add("Default", () => ({
  components: {ApartmentStatus},
  template: "<apartment-status/>"
}));

storiesOf("House Hold Items", module).add("Default", () => ({
  components: {HouseHoldItems},
  template: "<house-hold-items/>"
}));

storiesOf("Todos", module).add("Default", () => ({
  components: {Todos},
  template: "<todos/>"
}));

storiesOf("Feed", module).add("Default", () => ({
  components: {Feed},
  template: "<feed/>"
}));

storiesOf("Health 2", module).add("Default", () => ({
  components: {xxx},
  template: "<xxx/>"
}));