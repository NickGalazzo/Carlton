import { shallowMount, createLocalVue } from "@vue/test-utils";
import VueRouter from "vue-router";
import Vuetify from "vuetify";
import ApartmentStatusesCount from "../../../src/components/CountCards/ApartmentStatusesCount.vue";
import BaseCountCard from "../../../src/components/Base/BaseCountCard.vue";
import { SilenceWarnHack } from "../../SilenceWarnHack";


describe("ApartmentStatusesCount", () => {
  let wrapper;

  const silenceWarnHack = new SilenceWarnHack();

  beforeEach(() => {
    silenceWarnHack.enable();

    const localVue = createLocalVue();

    localVue.use(Vuetify);
    localVue.use(VueRouter);
    wrapper = shallowMount(ApartmentStatusesCount, {
      localVue: localVue,
      propsData: {
        count: 7
      }
    });

    silenceWarnHack.disable();
  });

  it("Is a valid Vue component", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });

  it("Should render a child BaseCountCard", () => {
    expect(wrapper.find(BaseCountCard).exists()).toBeTruthy();
  });
});
