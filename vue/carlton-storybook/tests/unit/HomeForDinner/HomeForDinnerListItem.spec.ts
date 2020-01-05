import Vuetify from "vuetify";
import { mount, shallowMount, createLocalVue } from "@vue/test-utils";
import HomeForDinnerListItem from "../../../src/components/HomeForDinner/HomeForDinnerListItem.vue";
import { HomeForDinnerData as data } from "../../../src/data/componentMockData";

describe("HomeForDinnerListInput Component", () => {
  let wrapper;

  beforeEach(() => {
    const localVue = createLocalVue();
    localVue.use(Vuetify);

    wrapper = mount(HomeForDinnerListItem, {
      localVue: localVue,
      propsData: {
        item: data.items[0]
      }
    });
  });

  test("is a Vue instance", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });

  test("Name is Nick", () => {
      var name = wrapper.find('div.v-list__tile__title').text();

      expect(name).toEqual("Nick");
  });

  test("Reason is Working Late", () => {
    var name = wrapper.find('div.v-list__tile__sub-title').text();

    expect(name).toEqual("Working late");
})
});
