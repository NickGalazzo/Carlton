import { storiesOf } from "@storybook/vue";
import { withKnobs, text, number } from "@storybook/addon-knobs";
import { action } from "@storybook/addon-actions";
import { withTests } from "@storybook/addon-jest";

import HouseholdItems from "../components/HouseholdItems/HouseholdItems.vue";
import HouseholdItem from "../components/HouseholdItems/HouseholdItem.vue";
import HouseholdItemList from "../components/HouseholdItems/HouseholdItemList.vue";
import results from "../../tests/jest-test-results.json";
import data from "../../tests/unit/HouseholdItem/TestData.json"; 

const options = {
  range: true,
  min: 0,
  max: 100,
  step: 1
};

export const methods = {
  navigateToHouseholdItem: action('navigateToHouseholdItem')
};


storiesOf("Household Items", module).add("Default", () => {
  return {
    components: { HouseholdItems },
    template: `<household-items :items="items"/>`,
    data: () => (data)
  };
});

storiesOf("Household Items/Single Item", module)
  .addDecorator(withKnobs)
  .add("Status Green", () => {
    const itemName = text("Item Name", "Swiffer");
    const percentRemaining = number("Percent Remaining", 75, options);

    return {
      components: { HouseholdItem },
      template: "<household-item :item='item' @navigateToHouseholdItem='navigateToHouseholdItem'/>",
      data: () => ({
        item: {
          id: 1,
          name: itemName,
          percentRemaining: percentRemaining
        }
      }),
      methods
    };
  })
  .add("Status Yellow", () => {
    const itemName = text("Item Name", "Swiffer");
    const percentRemaining = number("Percent Remaining", 50, options);

    return {
      components: { HouseholdItem },
      template: "<household-item :item='item' @navigateToHouseholdItem='navigateToHouseholdItem'/>",
      data: () => ({
        item: {
          id: 1,
          name: itemName,
          percentRemaining: percentRemaining
        }
      }),
      methods
    };
  })
  .add("Status Red", () => {
    const itemName = text("Item Name", "Swiffer");
    const percentRemaining = number("Percent Remaining", 15, options);

    return {
      components: { HouseholdItem },
      template: "<household-item :item='item' @navigateToHouseholdItem='navigateToHouseholdItem'/>",
      data: () => ({
        item: {
          id: 1,
          name: itemName,
          percentRemaining: percentRemaining
        }
      }),
      methods
    };
  });

storiesOf("Household Items/List", module)
  .add("Default", () => ({
    components: { HouseholdItemList },
    template: `<household-item-list :items="items"/>`,
    data: () => (data)
  }))
  .add("No Items", () => ({
    components: { HouseholdItemList },
    template: `<household-item-list :items="items"/>`,
    data: () => ({
      items: []
    })
  }));

  storiesOf("Household Items/Test Results", module)
    .addDecorator(withTests({results}))
    .add("Test Results ", () => "<div>Jest results in storybook</div>", {
      jest: ["HouseholdItem.spec.js", "HouseholdItemList.spec.js"]
    });