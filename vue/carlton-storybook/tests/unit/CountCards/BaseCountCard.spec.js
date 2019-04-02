import { shallowMount, createLocalVue } from "@vue/test-utils";
import VueRouter from "vue-router";
import Vuetify from "vuetify";
import BaseCountCard from "../../../src/components/Base/BaseCountCard.vue";
import { SilenceWarnHack } from "../../SilenceWarnHack";
import data from "./TestData.json";

describe("Count Cards", () => {
  let wrapper;

  const silenceWarnHack = new SilenceWarnHack();

  beforeEach(() => {
    silenceWarnHack.enable();

    const localVue = createLocalVue();

    localVue.use(Vuetify);
    localVue.use(VueRouter);
    wrapper = shallowMount(BaseCountCard, {
      localVue: localVue,
      propsData: {
        icon: data.icon,
        message: data.message,
        accentColor: data.accentColor
      }
    });

    silenceWarnHack.disable();
  });

  it("Is a valid Vue component", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });

  it("Renders an icon element", () => {
    expect(wrapper.find(".count-icon").exists()).toBeTruthy();
  });

  it("Given test input, renders correct icon image", () => {
    expect(wrapper.find(".count-icon").text()).toBe("mdi-home");
  });

  it("Renders a message element", () => {
    expect(wrapper.find(".msg").exists()).toBeTruthy();
  });

  it("Given test input, renders correct test message", () => {
    expect(wrapper.find(".msg").text()).toBe("This is a test.");
  });

  it("Given test input, renders correct icon background color", () => {
    expect(wrapper.find(".card-img").attributes().style).toBe("background-color: rgb(179, 61, 231);");
  });
  
});
