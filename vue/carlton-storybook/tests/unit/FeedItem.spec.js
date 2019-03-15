import { shallowMount, createLocalVue } from "@vue/test-utils";
import VueRouter from "vue-router";
import Vuetify from "vuetify";
import FeedItem from "../../src/components/Feed/FeedItem.vue";
import FeedSubList from "../../src/components/Feed/FeedSubList";
import { SilenceWarnHack } from "../SilenceWarnHack";
import { FeedItemModel } from "../../src/models/FeedItemModel";


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
        item: {
          avatar: "avatar.png",
          title: "Feed Title",
          message: "Feed Message"
        }
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
    expect(wrapper.find(".avatar").attributes().src).toBe("avatar.png");
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
    expect(wrapper.find(".msg").text()).toBe("Feed Message");
  });
});


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
        items: {
          timePeriod: "Yesterday",
          feedItems: [
            {
              avatar:
                "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/Microsoft_Cortana_transparent.svg/1200px-Microsoft_Cortana_transparent.svg.png",
              title: "Garbage",
              message: "Nick took out the garbage."
            },
            {
              avatar:
                "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/Microsoft_Cortana_transparent.svg/1200px-Microsoft_Cortana_transparent.svg.png",
              title: "Household Items",
              message: "Nick purchased toilet paper."
            },
            {
              avatar: "https://www.w3schools.com/w3images/avatar2.png",
              title: "Nick",
              message: "Steve, can you please order christmas gifts."
            }
          ]
        }
      }
    });

    silenceWarnHack.disable();
  });

  it("Is a valid Vue component", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });
});
