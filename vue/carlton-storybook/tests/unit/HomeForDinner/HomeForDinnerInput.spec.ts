import Vuetify from "vuetify";
import { mount, shallowMount, createLocalVue } from "@vue/test-utils";
import HomeForDinnerInput from "../../../src/components/HomeForDinner/HomeForDinnerInput.vue";
import {HomeForDinnerData as data} from "../../../src/data/componentMockData";


describe("HomeForDinnerInput Component", () => {
  let wrapper;

  beforeEach(() => {
    const localVue = createLocalVue();
    localVue.use(Vuetify);

    wrapper = mount(HomeForDinnerInput, {
      localVue: localVue,
      propsData: {
        item: data.items[0]
      }
    });
  });

  test("is a Vue instance", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });

  test("Unchecked home for dinner toggle results in enabled reason label", () => {
    var isDisabled = wrapper
      .find(".reason-label input")
      .attributes("disabled");

    expect(isDisabled).toBeFalsy();
  });

  test("checked home for dinner toggle results in disabled reason label", () => {
    wrapper.find("input[type='checkbox']").trigger('click');
    
    var isDisabled = wrapper
      .find(".reason-label input")
      .attributes("disabled");

    expect(isDisabled).toBeTruthy();
  });
});
