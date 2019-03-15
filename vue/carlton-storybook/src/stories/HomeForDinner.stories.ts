import { storiesOf } from "@storybook/vue";
import {
  withKnobs,
  text,
  boolean,
  number,
  select
} from "@storybook/addon-knobs";

import { action } from "@storybook/addon-actions";

import HomeForDinnerItem from "../components/HomeForDinner/HomeForDinnerItem.vue";
import HomeForDinnerList from "../components/HomeForDinner/HomeForDinnerList.vue";
import HomeForDinnerInput from "../components/HomeForDinner/HomeForDinnerInput.vue";
import HomeForDinner from "../components/HomeForDinner/HomeForDinner.vue";
import HomeForDinnerModel from "models/HomeForDinnerModel";

const data = {
  items: [
    {
      name: "Nick",
      isHomeForDinner: false,
      reason: "Working late"
    },
    {
      name: "Stephen",
      isHomeForDinner: false,
      reason: "Japneese Class"
    }
  ]
};

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

storiesOf("Home for Dinner/Item", module)
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
      components: { HomeForDinnerItem },
      template: "<home-for-dinner-item v-bind:item='model'/>",
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
      components: { HomeForDinnerItem },
      template: "<home-for-dinner-item v-bind:item='model'/>",
      data: () => ({ model })
    };
  });

storiesOf("Home for Dinner/List", module)
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

storiesOf("Home for Dinner/Input", module)
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
