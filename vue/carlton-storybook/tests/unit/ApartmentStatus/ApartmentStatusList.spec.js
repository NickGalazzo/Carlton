import { shallowMount, createLocalVue } from "@vue/test-utils";
import VueRouter from "vue-router";
import Vuetify from "vuetify";
import ApartmentStatusList from "../../../src/components/ApartmentStatus/ApartmentStatusList.vue";
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
    wrapper = shallowMount(ApartmentStatusList, {
      localVue: localVue,
      propsData: {
        statuses: data.statuses
      }
    });

    silenceWarnHack.disable();
  });

  it("Is a valid Vue component", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });

  it("Given Six Statuses should result in Six ApartmentStatus", () => {
    expect(wrapper.findAll(ApartmentStatusItem).length).toBe(6);
  });  
});
