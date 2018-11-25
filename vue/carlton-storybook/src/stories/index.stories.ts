/* eslint-disable react/react-in-jsx-scope, react/no-this-in-sfc */

import { storiesOf } from "@storybook/vue";
import { withKnobs, text, boolean, number } from "@storybook/addon-knobs";
import { action } from "@storybook/addon-actions";

import NavDrawer from "../components/NavDrawer.vue";
import HealthCard from "../components/HealthCard.vue";

import OpenTasksCount from "../components/OpenTasksCount.vue";
import ApartmentStatusesCount from "../components/ApartmentStatusesCount.vue";
import LowItemsCount from "../components/LowItemsCount.vue";
import HomeForDinnerCount from "../components/HomeForDinnerCount.vue";

import GarbageCard from "../components/GarbageCard.vue";
import HomeForDinner from "../components/HomeForDinner.vue";
import ApartmentStatus from "../components/ApartmentStatus.vue";
import HouseHoldItems from "../components/HouseHoldItems.vue";
import Todos from "../components/Todos.vue";
import Feed from "../components/Feed.vue";

import xxx from "../components/HealthCardX.vue";

storiesOf("Count Cards", module)
  .addDecorator(withKnobs)
  .add("Open Tasks", () => {
    const openTaskCount = number("Open Tasks", 0);

    return {
      components: { OpenTasksCount },
      template: `<open-tasks-count count='${openTaskCount}' />`
    };
  })
  .add("Pending Statuses", () => {
    const pendingStatusCount = number("Pending Statuses", 0);

    return {
      components: { ApartmentStatusesCount },
      template: `<apartment-statuses-count count='${pendingStatusCount}' />`
    };
  })
  .add("Low Items", () => {
    const lowItemsCount = number("Low Items", 0);

    return {
      components: { LowItemsCount },
      template: `<low-items-count count='${lowItemsCount}' />`
    };
  })
  .add("Home for Dinner", () => {
    const homeForDinnerCount = number("People Home for Dinner", 0);

    return {
      components: { HomeForDinnerCount },
      template: `<home-for-dinner-count count='${homeForDinnerCount}' />`
    };
  });

storiesOf("Nav Drawer", module).add("Default", () => ({
  components: { NavDrawer },
  template: "<nav-drawer/>"
}));

storiesOf("Health Card", module).add("Default", () => ({
  components: { HealthCard },
  template: "<health-card/>"
}));

storiesOf("Garbage Card", module).add("Defeault", () => ({
  components: { GarbageCard },
  template: "<garbage-card />"
}));

storiesOf("Home for Dinner", module).add("Default", () => ({
  components: { HomeForDinner },
  template: "<home-for-dinner/>"
}));

storiesOf("Apartment Status", module).add("Default", () => ({
  components: { ApartmentStatus },
  template: "<apartment-status/>"
}));

storiesOf("House Hold Items", module).add("Default", () => ({
  components: { HouseHoldItems },
  template: "<house-hold-items/>"
}));

storiesOf("Todos", module).add("Default", () => ({
  components: { Todos },
  template: "<todos/>"
}));

storiesOf("Feed", module).add("Default", () => ({
  components: { Feed },
  template: "<feed/>"
}));

storiesOf("Health 2", module).add("Default", () => ({
  components: { xxx },
  template: "<xxx/>"
}));
