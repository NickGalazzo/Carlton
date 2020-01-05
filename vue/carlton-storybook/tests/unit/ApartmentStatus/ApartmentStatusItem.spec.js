import { shallowMount, createLocalVue } from "@vue/test-utils";
import VueRouter from "vue-router";
import Vuetify from "vuetify";
import ApartmentStatusItem from "../../../src/components/ApartmentStatus/ApartmentStatusItem.vue";
import { SilenceWarnHack } from "../../SilenceWarnHack";
import data from "./TestData.json";

describe("ApartmentStatusItem", () => {
  let wrapper;

  const silenceWarnHack = new SilenceWarnHack();

  beforeEach(() => {
    silenceWarnHack.enable();

    const localVue = createLocalVue();

    localVue.use(Vuetify);
    localVue.use(VueRouter);
    wrapper = shallowMount(ApartmentStatusItem, {
      localVue: localVue,
      propsData: {
        status: data.statuses[0]
      }
    });

    silenceWarnHack.disable();
  });

  it("Is a valid Vue component", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });

  it("Renders Domain Icon", () => {
    expect(wrapper.find(".domain-icon").exists()).toBeTruthy();
  });

  it("Given icon mdi-delete, then should domain icon should render mdi-delte ", () => {
    expect(wrapper.find(".domain-icon").text()).toBe("mdi-delete");
  });

  it("Renders Domain Status Icon", () => {
    expect(wrapper.find(".status-icon").exists()).toBe(true);
  });
});
