import { shallowMount, createLocalVue } from "@vue/test-utils";
import VueRouter from "vue-router";
import Vuetify from "vuetify";
import FeedList from "../../../src/components/Feed/FeedList";
import FeedSubList from "../../../src/components/Feed/FeedSubList";
import { SilenceWarnHack } from "../../SilenceWarnHack";
import data from "./TestData.json";

describe("FeedList.vue", () => {
  let wrapper;

  const silenceWarnHack = new SilenceWarnHack();

  beforeEach(() => {
    silenceWarnHack.enable();

    const localVue = createLocalVue();

    localVue.use(Vuetify);
    localVue.use(VueRouter);
    wrapper = shallowMount(FeedList, {
      localVue: localVue,
      propsData: { items: data.items }
    });

    silenceWarnHack.disable();
  });

  it("Is a valid Vue component", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });

  it("Given two time periods should result in two FeedSubList child components", () => {
    expect(wrapper.findAll(FeedSubList).length).toBe(2);
  });

});
