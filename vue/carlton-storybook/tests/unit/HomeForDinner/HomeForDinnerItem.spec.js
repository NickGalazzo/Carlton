import { mount, shallowMount, createLocalVue } from "@vue/test-utils";
import VueRouter from "vue-router";
import Vuetify from "vuetify";
import HomeForDinnerItem from "../../../src/components/HomeForDinner/HomeForDinnerItem.vue";
import { SilenceWarnHack } from "../../SilenceWarnHack";
import data from "./TestData.json";

let wrapper;
const silenceWarnHack = new SilenceWarnHack();

beforeAll(() => {
  silenceWarnHack.enable();
 
  const localVue = createLocalVue();
  localVue.use(Vuetify);
  localVue.use(VueRouter);
  wrapper = mount(HomeForDinnerItem, {
    localVue: localVue,
    propsData: {
      item: data.items[0]
    }
  });

  silenceWarnHack.disable();
});

describe("Render Tests", () => {
  it("Given a HomeForDinnerItem component Then it should be a valid Vue component", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });

  it("Given a HomeForDinnerItem component Then a div tag for the user name should be rendered", () => {
    expect(wrapper.find('.name').exists()).toBeTruthy();
  });

  it("Given a name parameter of Stephen Then a div tag for the user name should be rendered with the users name", () => {
    //Arrange
    wrapper.setProps({item: {
      name: "Stephen"
    }});

    //Assert
    expect(wrapper.find('.name').text()).toBe("Stephen");
  });

  it("Given parameters of isHomeForDinner of false and a reason of 'Japaneese class' Then a div tag for the reason should be rendered with the reason", () => {
    //Arrange
    wrapper.setProps({item: {
      name: "Stephen",
      reason: "Japaneese Class",
      isHomeForDinner: false
    }});

    //Assert
    expect(wrapper.find('.reason').text()).toBe("Japaneese Class");
  });

  it("Given parameters of isHomeForDinner of true and any reason Then a div tag for the reason should be rendered with 'Home'", () => {
    //Arrange
    wrapper.setProps({item: {
      name: "Stephen",
      reason: "XXXXX",
      isHomeForDinner: true
    }});

    //Assert
    expect(wrapper.find('.home').text()).toBe("Home");
  });

  it("Given a HomeForDinnerItem component Then an icon should be rendered", () => {
    expect(wrapper.find('i').exists()).toBeTruthy();
  });

  it("Given a HomeForDinnerItem component when isHome is false Then icon style should be undefined", () => {
    //Arrange
    wrapper.setProps({item: {
      isHomeForDinner: false
    }});

    //Assert
    expect(wrapper.find('i.v-icon').classes('grey--text')).toBeTruthy();
  });

  it("Given a HomeForDinnerItem component when isHome is true Then icon should be green", () => {
    //Arrange
    wrapper.setProps({item: {
      name: "Stephen",
      reason: "XXXXX",
      isHomeForDinner: true
    }});

    //Assert
    expect(wrapper.find('i.v-icon').classes('grey--text')).toBeFalsy();
  });
});
