import { shallowMount, createLocalVue } from "@vue/test-utils";
import VueRouter from "vue-router";
import Vuetify from "vuetify";
import FeedItem from "../../../src/components/Feed/FeedItem.vue";
import { SilenceWarnHack } from "../../SilenceWarnHack";
import data from "./TestData.json";

describe("FeedItem.vue", () => {
  let wrapper;

  const silenceWarnHack = new SilenceWarnHack();

  beforeEach(() => {
    silenceWarnHack.enable();

    const localVue = createLocalVue();

    localVue.use(Vuetify);
    localVue.use(VueRouter);
    wrapper = shallowMount(FeedItem, {
      localVue: localVue,
      propsData: {
        item: data.items[0].feedItems[0]
      }
    });

    silenceWarnHack.disable();
  });

  it("Is a valid Vue component", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });

  it("Renders avatar tag", () => {
    expect(wrapper.find(".avatar").exists()).toBeTruthy();
  });

  it("Renders avatar inside of tag", () => {
    expect(wrapper.find(".avatar").attributes().src).toBe("https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/Microsoft_Cortana_transparent.svg/1200px-Microsoft_Cortana_transparent.svg.png");
  });

  it("Renders title div", () => {
    expect(wrapper.find(".subtitle").exists()).toBeTruthy();
  });

  it("Renders title text in div", () => {
    expect(wrapper.find(".subtitle").text()).toBeTruthy();
  });

  it("Renders Message div", () => {
    expect(wrapper.find(".msg").exists()).toBeTruthy();
  });

  it("Renders Message in div", () => {
    expect(wrapper.find(".msg").text()).toBe("Nick took out the garbage.");
  });
});