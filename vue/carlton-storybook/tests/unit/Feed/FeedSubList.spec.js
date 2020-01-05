import { shallowMount, createLocalVue } from "@vue/test-utils";
import VueRouter from "vue-router";
import Vuetify from "vuetify";
import FeedItem from "../../../src/components/Feed/FeedItem.vue";
import FeedSubList from "../../../src/components/Feed/FeedSubList";
import { SilenceWarnHack } from "../../SilenceWarnHack";
import data from "./TestData.json"; 

describe("FeedSubList", () => {
  let wrapper;

  const silenceWarnHack = new SilenceWarnHack();

  beforeEach(() => {
    silenceWarnHack.enable();

    const localVue = createLocalVue();

    localVue.use(Vuetify);
    localVue.use(VueRouter);
    wrapper = shallowMount(FeedSubList, {
      localVue: localVue,
      propsData: {
        items: data.items[0]
      }
    });

    silenceWarnHack.disable();
  });

  it("Is a valid Vue component", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });


  it("Given Three Feed Items, Three FeedItem child components are rendered", () => {
    expect(wrapper.findAll(FeedItem).length).toBe(3);
  });

  it("Renders Subheader with a time frame", () => {
    expect(wrapper.find(".time-frame-header").exists()).toBeTruthy();
  });

  it("Given parameter timePeriod of Today should result in Today rendered as subheading", () => {
    expect(wrapper.find(".time-frame-header").text()).toBe("Today");
  });
});
