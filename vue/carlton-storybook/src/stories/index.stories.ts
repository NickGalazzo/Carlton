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
import HomeForDinnerList from "../components/HomeForDinnerList.vue";
import HomeForDinnerInput from "../components/HomeForDinnerInput.vue";

import GarbageCard from "../components/GarbageCard.vue";
import HomeForDinnerItem from "../components/HomeForDinnerItem.vue";
import HomeForDinner from "../components/HomeForDinner.vue";
import ApartmentStatus from "../components/ApartmentStatus.vue";
import ApartmentStatusList from "../components/ApartmentStatusList.vue";
import HouseHoldItemList from "../components/HouseHoldItemList.vue";

import TodoItem from "../components/TodoItem.vue";
import TodoList from "../components/TodoList.vue";
import Feed from "../components/Feed.vue";
import FeedSubList from "../components/FeedSubList.vue";
import FeedItem from "../components/FeedItem.vue";
import FeedList from "../components/FeedList.vue";

import xxx from "../components/HealthCardX.vue";

import HouseHoldItem from "../components/HouseHoldItem.vue";

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

storiesOf("Home for Dinner", module)
  .add("Default", () => ({
    components: { HomeForDinner },
    template: "<home-for-dinner v-bind:items='items'/>",
    data: () => ({
      items: [
        {
          name: "Nick",
          isHomeForDinner: true,
          reason: ""
        },
        {
          name: "Stephen",
          isHomeForDinner: false,
          reason: "Japneese class"
        }
      ]
    })
  }))
  .addDecorator(withKnobs)
  .add("Home", () => {
    const isHome = boolean("Is Home?", true);
    const reason = text("reason", "");

    return {
      components: { HomeForDinnerItem },
      template: "<home-for-dinner-item v-bind:item='item'/>",
      data: () => ({
        item: {
          name: "Nick",
          isHomeForDinner: isHome,
          reason: reason
        }
      })
    };
  })
  .add("List", () => {
    return {
      components: { HomeForDinnerList },
      template: "<home-for-dinner-list v-bind:items='items'/>",
      data: () => ({
        items: [
          {
            name: "Nick",
            isHomeForDinner: true,
            reason: ""
          },
          {
            name: "Stephen",
            isHomeForDinner: false,
            reason: "Japneese class"
          }
        ]
      })
    };
  })
  .add("Input", () => {
    return {
      components: { HomeForDinnerInput },
      template: "<home-for-dinner-input/>"
    };
  });

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
    const dryCleaningStatus = select(
      "Dry-Cleaning Status",
      statusTypeOptions,
      1
    );

    return {
      components: { ApartmentStatusList },
      template: "<apartment-status-list v-bind:statuses='statuses'/>",
      data: () => ({
        statuses: [
          {
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
          }
        ]
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

storiesOf("Todos", module)
  .addDecorator(withKnobs)
  .add("Item", () => {
    const name = text("Task Name", "Take out garbage");
    const isCompleted = boolean("completed", false);

    return {
      components: { TodoItem },
      template: "<todo-item v-bind:item='item'/>",
      data: () => ({
        item: {
          name: name,
          completed: isCompleted
        }
      })
    };
  })
  .add("Todo List", () => ({
    components: { TodoList },
    template: "<todo-list v-bind:items='items'/>",
    data: () => ({
      items: [
        {
          name: "Test",
          completed: true
        },
        {
          name: "test 2",
          completed: true
        },
        {
          name: "test 3",
          completed: false
        }
      ]
    })
  }));

storiesOf("Feed", module)
  .addDecorator(withKnobs)
  .add("Default", () => ({
    components: { Feed },
    template: "<feed/>"
  }))
  .add("Feed Item", () => {
    const avatarOptions = {
      system:
        "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/Microsoft_Cortana_transparent.svg/1200px-Microsoft_Cortana_transparent.svg.png",
      user: "https://www.w3schools.com/w3images/avatar2.png"
    };

    const avatars = select("Status", avatarOptions, avatarOptions.system);
    const title = text("Title", "Home for dinner");
    const message = text("Message", "Stephen will be home for dinner");

    return {
      components: { FeedItem },
      template: "<feed-item v-bind:item='item'/>",
      data: () => ({
        item: {
          avatar: avatars,
          title: title,
          message: message
        }
      })
    };
  })
  .add("Feed Sublist", () => {
    return {
      components: { FeedSubList },
      template: "<feed-sub-list v-bind:items='items'/>",
      data: () => ({
        items: [
          {
            avatar: "https://www.w3schools.com/w3images/avatar2.png",
            title: "Test",
            message: "Test Test Test"
          },
          {
            avatar: "https://www.w3schools.com/w3images/avatar2.png",
            title: "Test 2",
            message: "Test Test Test"
          },
          {
            avatar: "https://www.w3schools.com/w3images/avatar2.png",
            title: "Test 3",
            message: "Test Test Test"
          }
        ]
      })
    };
  })
  .add("Feed List", () => {
    return {
      components: {FeedList},
      template: "<feed-list v-bind:items='items'/>",
      data:() => ({
        items: [
          {
            avatar: "https://www.w3schools.com/w3images/avatar2.png",
            title: "Test",
            message: "Test Test Test"
          },
          {
            avatar: "https://www.w3schools.com/w3images/avatar2.png",
            title: "Test 2",
            message: "Test Test Test"
          },
          {
            avatar: "https://www.w3schools.com/w3images/avatar2.png",
            title: "Test 3",
            message: "Test Test Test"
          }
        ]
      })
    }
  });

storiesOf("Health 2", module).add("Default", () => ({
  components: { xxx },
  template: "<xxx/>"
}));
