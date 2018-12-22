import { storiesOf } from "@storybook/vue";
import { withKnobs, text, number } from "@storybook/addon-knobs";
import { action } from "@storybook/addon-actions";

import HouseholdItems from "../components/HouseholdItems/HouseholdItems.vue";
import HouseholdItem from "../components/HouseholdItems/HouseholdItem.vue";
import HouseholdItemList from "../components/HouseholdItems/HouseholdItemList.vue";

const options = {
  range: true,
  min: 0,
  max: 100,
  step: 1
};

let data = {
  items: [
    {
      id: 1,
      name: "Toilet Paper",
      percentRemaining: 15
    },
    {
      id: 2,
      name: "Paper Towels",
      percentRemaining: 50
    },
    {
      id: 3,
      name: "Dish Soap",
      percentRemaining: 80
    },
    {
      id: 4,
      name: "Swiffers",
      percentRemaining: 90
    },
    {
      id: 5,
      name: "Hand Soap",
      percentRemaining: 90
    },
    {
      id: 6,
      name: "Tooth Paste",
      percentRemaining: 93
    },
    {
      id: 1,
      name: "Razor Blades",
      percentRemaining: 100
    },
    {
      id: 1,
      name: "Paper Plates",
      percentRemaining: 100
    }
  ]
};

export const methods = {
  navigateToHouseholdItem: action('navigateToHouseholdItem')
};


storiesOf("House Hold Items", module).add("Default", () => {
  return {
    components: { HouseholdItems },
    template: `<household-items :items="items"/>`,
    data: () => (data)
  };
});

storiesOf("House Hold Items/Single Item", module)
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

storiesOf("House Hold Items/List", module)
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
