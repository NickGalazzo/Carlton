/* eslint-disable react/react-in-jsx-scope, react/no-this-in-sfc */

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

//Aggregations
import OpenTasksCount from "../components/Aggregations/OpenTasksCount.vue";
import ApartmentStatusesCount from "../components/Aggregations/ApartmentStatusesCount.vue";
import LowItemsCount from "../components/Aggregations/LowItemsCount.vue";
import HomeForDinnerCount from "../components/Aggregations/HomeForDinnerCount.vue";

//Home For Dinner
import HomeForDinnerItem from "../components/HomeForDinner/HomeForDinnerItem.vue";
import HomeForDinnerList from "../components/HomeForDinner/HomeForDinnerList.vue";
import HomeForDinnerInput from "../components/HomeForDinner/HomeForDinnerInput.vue";
import HomeForDinner from "../components/HomeForDinner/HomeForDinner.vue";

//Apartment Status
import ApartmentStatusItem from "../components/ApartmentStatus/ApartmentStatusItem.vue";
import ApartmentStatusList from "../components/ApartmentStatus/ApartmentStatusList.vue";

//Household Items
import HouseHoldItem from "../components/HouseHoldItems/HouseHoldItem.vue";
import HouseHoldItemList from "../components/HouseHoldItems/HouseHoldItemList.vue";

//Todos
import TodoItem from "../components/Todos/TodoItem.vue";
import TodoList from "../components/Todos/TodoList.vue";

//Feed
import FeedItem from "../components/Feed/FeedItem.vue";
import FeedList from "../components/Feed/FeedList.vue";
import FeedSubList from "../components/Feed/FeedSubList.vue";
import Feed from "../components/Feed/Feed.vue";

//Dashboard Page
import GarbageCard from "../components/GarbageCard.vue";

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

storiesOf("Home for Dinner", module)
  .addDecorator(withKnobs)
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
  }));

storiesOf("Home for Dinner/Item")
  .addDecorator(withKnobs)
  .add("Item", () => {
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
  });

storiesOf("Home for Dinner/List")
  .addDecorator(withKnobs)
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
  });

storiesOf("Home for Dinner/Input")
  .addDecorator(withKnobs)
  .add("Input", () => {
    return {
      components: { HomeForDinnerInput },
      template: "<home-for-dinner-input/>"
    };
  });

storiesOf("Apartment Status/Item", module)
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
      components: { ApartmentStatusItem },
      template: "<apartment-status-item v-bind:status='status'/>",
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
  .add("Default", () => ({
    components: { HouseHoldItemList },
    template: "<house-hold-item-list v-bind:items='items'/>",
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
  }))
  .add("No Items", () => ({
    components: { HouseHoldItemList },
    template: `<house-hold-item-list v-bind:items="items"/>`,
    data: () => ({
      items: []
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
          isCompleted: true
        },
        {
          name: "test 2",
          isCompleted: true
        },
        {
          name: "test 3",
          isCompleted: false
        }
      ]
    })
  }));

storiesOf("Feed/Item", module)
  .addDecorator(withKnobs)
  .add("Default", () => ({
    components: { Feed },
    template: "<feed/>"
  }))
  .add("Default", () => {
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
  });

  storiesOf("Feed/Sublist")
  .addDecorator(withKnobs)
  .add("Default", () => {
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
  });

  storiesOf("Feed/List")
  .addDecorator(withKnobs)
  .add("Feed List", () => {
    return {
      components: { FeedList },
      template: "<feed-list v-bind:items='items'/>",
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
  });

storiesOf("Garbage Card", module).add("Defeault", () => ({
  components: { GarbageCard },
  template: "<garbage-card />"
}));

storiesOf("Health Card", module).add("Default", () => ({
  components: { HealthCard },
  template: "<health-card/>"
}));
