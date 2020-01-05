import { shallowMount, createLocalVue } from "@vue/test-utils";
import VueRouter from "vue-router";
import Vuetify from "vuetify";
import OpenTasksCountCard from "../../../src/components/CountCards/OpenTasksCountCard.vue";
import BaseCountCard from "../../../src/components/Base/BaseCountCard.vue";
import { SilenceWarnHack } from "../../SilenceWarnHack";


describe("OpenTasksCountCard", () => {
  let wrapper;

  const silenceWarnHack = new SilenceWarnHack();

  beforeEach(() => {
    silenceWarnHack.enable();

    const localVue = createLocalVue();

    localVue.use(Vuetify);
    localVue.use(VueRouter);
    wrapper = shallowMount(OpenTasksCountCard, {
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
