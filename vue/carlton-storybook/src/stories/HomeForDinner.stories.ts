import { storiesOf } from "@storybook/vue";
import {
  withKnobs,
  text,
  boolean
} from "@storybook/addon-knobs";

import { action } from "@storybook/addon-actions";

import HomeForDinnerListItem from "../components/HomeForDinner/HomeForDinnerListItem.vue";
import HomeForDinnerList from "../components/HomeForDinner/HomeForDinnerList.vue";
import HomeForDinnerInput from "../components/HomeForDinner/HomeForDinnerInput.vue";
import HomeForDinner from "../components/HomeForDinner/HomeForDinner.vue";
import HomeForDinnerModel from "models/HomeForDinnerModel";
import {HomeForDinnerData as data} from "../../src/data/componentMockData"; 

export const methods = {
  setHomeForDinnerStatus: action('setHomeForDinnerStatus')
};


storiesOf("Home for Dinner", module)
  .addDecorator(withKnobs)
  .add("Default", () => ({
    components: { HomeForDinner },
    template: "<home-for-dinner v-bind:items='items'/>",
    data: () => (data)
  }));

storiesOf("Home for Dinner/Item")
  .addDecorator(withKnobs)
  .add("Home", () => {
    const isHome = boolean("Is Home?", true);
    const reason = text("reason", "");

    const model: HomeForDinnerModel = Object.assign({}, data.items[1]);
    model.isHomeForDinner = isHome;
    model.reason = reason;

    console.log("testing:");
    console.log(model);

    return {
      components: { HomeForDinnerListItem },
      template: "<home-for-dinner-list-item v-bind:item='model'/>",
      data: () => ({ model })
    };
  })
  .add("Not Home", () => {
    const isHome = boolean("Is Home?", false);
    const reason = text("reason", "Japaneese Class");

    const model: HomeForDinnerModel = Object.assign({}, data.items[1]);
    model.isHomeForDinner = isHome;
    model.reason = reason;

    console.log("testing:");
    console.log(model);

    return {
      components: { HomeForDinnerListItem },
      template: "<home-for-dinner-list-item v-bind:item='model'/>",
      data: () => ({ model })
    };
  });

storiesOf("Home for Dinner/List")
  .addDecorator(withKnobs)
  .add("Default", () => {

    console.log(data)

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

storiesOf("Home for Dinner/Input")
  .addDecorator(withKnobs)
  .add("Home", () => {
    const isHome = boolean("Is Home?", true);
    const reason = text("reason", "");

    const model : HomeForDinnerModel = Object.assign({}, data.items[1]);
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

    const model : HomeForDinnerModel = Object.assign({}, data.items[1]);
    model.isHomeForDinner = isHome;
    model.reason = reason;

    return {
      components: { HomeForDinnerInput },
      template: "<home-for-dinner-input :model='model'  @setHomeForDinnerStatus='setHomeForDinnerStatus' />",
      data: () => ({model}),
      methods
    };
  });
