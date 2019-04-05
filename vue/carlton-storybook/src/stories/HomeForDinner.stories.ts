import { storiesOf } from "@storybook/vue";
import {
  withKnobs,
  text,
  boolean,
  number,
  select
} from "@storybook/addon-knobs";

import { action } from "@storybook/addon-actions";
import { withTests } from "@storybook/addon-jest";

import HomeForDinnerItem from "../components/HomeForDinner/HomeForDinnerItem.vue";
import HomeForDinnerList from "../components/HomeForDinner/HomeForDinnerList.vue";
import HomeForDinnerInput from "../components/HomeForDinner/HomeForDinnerInput.vue";
import HomeForDinner from "../components/HomeForDinner/HomeForDinner.vue";
import HomeForDinnerModel from "models/HomeForDinnerModel";

import results from "../../tests/jest-test-results.json";
import data from "../../tests/unit/HomeForDinner/TestData.json";



export const methods = {
  setHomeForDinnerStatus: action('setHomeForDinnerStatus')
};

let model = Object.assign({}, data.items[0]);

storiesOf("Home for Dinner", module)
  .addDecorator(withKnobs)
  .add("Default", () => ({
    components: { HomeForDinner },
    template: "<home-for-dinner :items='items'/>",
    data: () => (data)
  }));

storiesOf("Home for Dinner/Item", module)
  .addDecorator(withKnobs)
  .add("Home", () => {
    const isHome = boolean("Is Home?", true);
    const reason = text("reason", "");
   
    model.isHomeForDinner = isHome;
    model.reason = reason;

    return {
      components: { HomeForDinnerItem },
      template: "<home-for-dinner-item :item='model'/>",
      data: () => ({model})
    };
  })
  .add("Not Home", () => {
    const isHome = boolean("Is Home?", false);
    const reason = text("reason", "Japaneese Class");

    model.isHomeForDinner = isHome;
    model.reason = reason;

    return {
      components: { HomeForDinnerItem },
      template: "<home-for-dinner-item v-bind:item='model'/>",
      data: () => ({ model })
    };
  });

storiesOf("Home for Dinner/List", module)
  .addDecorator(withKnobs)
  .add("Default", () => {

    return {
      components: { HomeForDinnerList },
      template: "<home-for-dinner-list :items='items' />",
      data: () => (data)
    };
  })
  .add("With Somone Home", () => {

    const model = data.items.map(o => ({...o}))

    model[0].isHomeForDinner = true;
    model[0].reason = "";

    return {
      components: {HomeForDinnerList},
      template: "<home-for-dinner-list :items='model' />",
      data: () => ({model})
    }
  });

storiesOf("Home for Dinner/Input", module)
  .addDecorator(withKnobs)
  .add("Home", () => {
    const isHome = boolean("Is Home?", true);
    const reason = text("reason", "");

    const model = Object.assign({}, data.items[1]);
    model.isHomeForDinner = isHome;
    model.reason = reason;

    return {
      components: { HomeForDinnerInput },
      template: "<home-for-dinner-input :model='model' @setHomeForDinnerStatus='setHomeForDinnerStatus'/>",
      data: () => ({model}),
      methods
    };
  })
  .add("Not Home", () => {
    const isHome = boolean("Is Home?", false);
    const reason = text("reason", "Working Late");

    const model = Object.assign({}, data.items[1]);
    model.isHomeForDinner = isHome;
    model.reason = reason;

    return {
      components: { HomeForDinnerInput },
      template: "<home-for-dinner-input :model='model'  @setHomeForDinnerStatus='setHomeForDinnerStatus' />",
      data: () => ({model}),
      methods
    };
  });

  storiesOf("Home for Dinner/Test Results", module)
    .addDecorator(withTests({results}))
    .add("Test Results ", () => "<div>Jest results in storybook</div>", {
      jest: ["HomeForDinnerInput.spec.js", "HomeForDinnerItem.spec.js", "HomeForDinnerItemList.spec.js"]
    });