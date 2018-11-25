/* eslint-disable react/react-in-jsx-scope, react/no-this-in-sfc */

import { storiesOf } from "@storybook/vue";
import {
  withKnobs,
  text,
  boolean,
  number,
  select
} from "@storybook/addon-knobs";
import { action, configureActions } from "@storybook/addon-actions";

import NavDrawer from "../components/NavDrawer.vue";
import HealthCard from "../components/HealthCard.vue";

import OpenTasksCount from "../components/OpenTasksCount.vue";
import ApartmentStatusesCount from "../components/ApartmentStatusesCount.vue";
import LowItemsCount from "../components/LowItemsCount.vue";
import HomeForDinnerCount from "../components/HomeForDinnerCount.vue";

import GarbageCard from "../components/GarbageCard.vue";
import HomeForDinner from "../components/HomeForDinner.vue";
import ApartmentStatus from "../components/ApartmentStatus.vue";
import ApartmentStatusList from "../components/ApartmentStatusList.vue";
import HouseHoldItemList from "../components/HouseHoldItemList.vue";
import Todos from "../components/Todos.vue";
import Feed from "../components/Feed.vue";

import xxx from "../components/HealthCardX.vue";

import HouseHoldItem from "../components/HouseHoldItem.vue";
import items from "../data/items.json";

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
  template: "<nav-drawer />"
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

storiesOf("Apartment Status/Single Item", module)
  .addDecorator(withKnobs)
  .add("Default", () => {
    const statusContextOptions = {
      Garbage: "mdi-delete",
      Recycle: "mdi-recycle",
      Shopping: "mdi-cart",
      Cleaning: "mdi-spray-bottle",
      Laundry: "mdi-washing-machine",
      DryCleaning: "mdi-tie"
    };

    const statusTypeOptions = {
      completed: 1,
      Pending: 2
    };

    const statusIcon = select("Icon", statusContextOptions, "mdi-delete");
    const status = select("Status", statusTypeOptions, 1);

    return {
      components: { ApartmentStatus },
      template: "<apartment-status v-bind:status='status'/>",
      data: () => ({
        status: {
          icon: statusIcon,
          statusId: status
        }
      })
    };
  });

storiesOf("Apartment Status/List")
  .addDecorator(withKnobs)
  .add("Default", () => {
    
    const statusTypeOptions = {
      completed: 1,
      Pending: 2
    };

    const garbageStatus = select("Garbage Status", statusTypeOptions, 1);
    const recycleStatus = select("Recycle Status", statusTypeOptions, 1);
    const shoppingStatus = select("Shopping Status", statusTypeOptions, 1);
    const cleaningStatus = select("Cleaning Status", statusTypeOptions, 1);
    const laundryStatus = select("Laundry Status", statusTypeOptions, 1);
    const dryCleaningStatus = select("Dry-Cleaning Status", statusTypeOptions, 1);

    return {
      components: { ApartmentStatusList },
      template: "<apartment-status-list v-bind:statuses='statuses'/>",
      data: () => ({
        statuses: [{
          icon: "mdi-delete",
          statusId: garbageStatus
        },
        {
          icon: "mdi-recycle",
          statusId: recycleStatus
        },
        {
          icon: "mdi-cart",
          statusId: shoppingStatus
        },
        {
          icon: "mdi-spray-bottle",
          statusId: cleaningStatus
        },
        {
          icon: "mdi-washing-machine",
          statusId: laundryStatus
        },
        {
          icon: "mdi-tie",
          statusId: dryCleaningStatus
        }]
      })
    };
  });

storiesOf("House Hold Items/Single Item", module)
  .addDecorator(withKnobs)
  .add("Default", () => {
    const options = {
      range: true,
      min: 0,
      max: 100,
      step: 1
    };
    const itemName = text("Item Name", "Swiffer");
    const percentRemaining = number("Percent Remaining", 75, options);

    return {
      components: { HouseHoldItem },
      template: "<house-hold-item v-bind:item='item'/>",
      data: () => ({
        item: {
          name: itemName,
          percentRemaining: percentRemaining
        }
      })
    };
  });

storiesOf("House Hold Items/List", module)
  .add("No Items", () => ({
    components: { HouseHoldItemList },
    template: `<house-hold-item-list v-bind:items="items"/>`,
    data: () => ({
      items: []
    })
  }))
  .add("Default", () => ({
    components: { HouseHoldItemList },
    template: `<house-hold-item-list v-bind:items="items"/>`,
    data: () => ({
      items: [
        {
          name: "Toilet Paper",
          percentRemaining: 15
        },
        {
          name: "Paper Towels",
          percentRemaining: 50
        },
        {
          name: "Dish Soap",
          percentRemaining: 80
        },
        {
          name: "Swiffers",
          percentRemaining: 90
        }
      ]
    })
  }))
  .add("Scroll", () => ({
    components: { HouseHoldItemList },
    template: `<house-hold-item-list v-bind:items="items"/>`,
    data: () => ({
      items: [
        {
          name: "Toilet Paper",
          percentRemaining: 15
        },
        {
          name: "Paper Towels",
          percentRemaining: 50
        },
        {
          name: "Dish Soap",
          percentRemaining: 80
        },
        {
          name: "Swiffers",
          percentRemaining: 90
        },
        {
          name: "Hand Soap",
          percentRemaining: 90
        },
        {
          name: "Tooth Paste",
          percentRemaining: 93
        },
        {
          name: "Razor Blades",
          percentRemaining: 100
        },
        {
          name: "Paper Plates",
          percentRemaining: 100
        }
      ]
    })
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
