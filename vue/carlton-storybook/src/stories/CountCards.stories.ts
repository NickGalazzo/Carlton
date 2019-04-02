import { storiesOf } from "@storybook/vue";
import {
  withKnobs,
  text,
  boolean,
  number,
  select
} from "@storybook/addon-knobs";
import { withTests } from "@storybook/addon-jest";
import { action } from "@storybook/addon-actions";
import results from "../../tests/jest-test-results.json";

import OpenTasksCount from "../components/CountCards/OpenTasksCountCard.vue";
import ApartmentStatusesCount from "../components/CountCards/ApartmentStatusesCount.vue";
import LowItemsCount from "../components/CountCards/LowItemsCount.vue";
import HomeForDinnerCount from "../components/CountCards/HomeForDinnerCount.vue";

storiesOf("Count Cards", module)
  .addDecorator(withKnobs)
  .add("Open Tasks", () => {
    const openTaskCount = number("Open Tasks", 5);

    return {
      components: { OpenTasksCount },
      template: `<open-tasks-count count='${openTaskCount}' />`
    };
  })
  .add("Pending Statuses", () => {
    const pendingStatusCount = number("Pending Statuses", 5);

    return {
      components: { ApartmentStatusesCount },
      template: `<apartment-statuses-count count='${pendingStatusCount}' />`
    };
  })
  .add("Low Items", () => {
    const lowItemsCount = number("Low Items", 5);

    return {
      components: { LowItemsCount },
      template: `<low-items-count count='${lowItemsCount}' />`
    };
  })
  .add("Home for Dinner", () => {
    const homeForDinnerCount = number("People Home for Dinner", 5);

    return {
      components: { HomeForDinnerCount },
      template: `<home-for-dinner-count count='${homeForDinnerCount}' />`
    };
  });

storiesOf("Count Cards", module)
  .addDecorator(withTests({results}))
  .add("Test Results ", () => "<div>Jest results in storybook</div>", {
    jest: ["BaseCountCard.spec.js", "ApartmentStatusesCount.spec.js", "HomeForDinnerCount.spec.js", "OpenTasksCountCard.spec.js"]
  });
