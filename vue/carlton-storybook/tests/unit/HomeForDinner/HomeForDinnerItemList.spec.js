import { shallowMount, createLocalVue } from "@vue/test-utils";
import VueRouter from "vue-router";
import Vuetify from "vuetify";
import HomeForDinnerItem from "../../../src/components/HomeForDinner/HomeForDinnerItem";
import HomeForDinnerList from "../../../src/components/HomeForDinner/HomeForDinnerList";
import { SilenceWarnHack } from "../../SilenceWarnHack";
import data from "./TestData.json";

let wrapper;
const silenceWarnHack = new SilenceWarnHack();

beforeAll(() => {
  silenceWarnHack.enable();
 
  const localVue = createLocalVue();
  localVue.use(Vuetify);
  localVue.use(VueRouter);
  wrapper = shallowMount(HomeForDinnerList, {
    localVue: localVue,
    propsData: {
      items: data.items
    }
  });

  silenceWarnHack.disable();
});

describe("Render Tests", () => {
  it("Given a HomeForDinnerList component Then it should be a valid Vue component", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });

  it("Given a HomeForDinnerList component with 2 item parameters Then two HomeForDinnerItem child controls should be rendered", () => {
    expect(wrapper.findAll(HomeForDinnerItem).length).toBe(2);
  });
});
