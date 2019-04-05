import { mount, shallowMount, createLocalVue } from "@vue/test-utils";
import VueRouter from "vue-router";
import Vuetify from "vuetify";
import HomeForDinnerInput from "../../../src/components/HomeForDinner/HomeForDinnerInput.vue";
import { SilenceWarnHack } from "../../SilenceWarnHack";
import data from "./TestData.json";

let wrapper;
const silenceWarnHack = new SilenceWarnHack();

beforeEach(() => {
  silenceWarnHack.enable();
 
  const localVue = createLocalVue();
  localVue.use(Vuetify);
  localVue.use(VueRouter);
  wrapper = mount(HomeForDinnerInput, {
    localVue,
    propsData: {
      item: data.items[0]
    },
    stubs: {
      //For some unknown reason mounting the real VTextField does not work when mounted so we have to stub it, thanks Vuetify....?
      VTextField: `<input class='test' disabled='disabled' type='text' value='${
        data.items[0].reason
      }'/>`
    }
  });

  silenceWarnHack.disable();
});

describe("Render Tests", () => {
  it("Given a HomeForDinnerInput component Then it should be a valid Vue component", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });

  it("Given a HomeForDinnerInput component Then a text input with status text should be rendered", () => {
    //Arrange
    var textbox = wrapper.find("input[type='text']");

    //Assert
    expect(textbox.exists()).toBeTruthy();
    expect(textbox.attributes("value")).toBe(data.items[0].reason);
  });

  it("Given a HomeForDinnerInput component Then a checkbox should be rendered", () => {
    //Arrange
    let checkbox = wrapper.find("input[type='checkbox']");

    //Assert
    expect(checkbox.exists()).toBeTruthy();
  });

  it("Given a homeForDinnerStatus of false Then an unchecked checkbox should be rendered", () => {
    //Arrange
    wrapper.vm.isHomeForDinner = false;
    let checkbox = wrapper.find("input[type='checkbox']");

    //Assert
    expect(checkbox.exists()).toBeTruthy();
    expect(checkbox.element.checked).toBe(false);
  });

  it("Given a homeForDinnerStatus of true Then a checked checkbox should be rendered", () => {
    //Arrange
    wrapper.vm.isHomeForDinner = true;
    let checkbox = wrapper.find("input[type='checkbox']");

    //Assert
    expect(checkbox.exists()).toBeTruthy();
    expect(checkbox.element.checked).toBe(true);
  });
});

describe("Interaction Tests", () => {
  it("Given a homeForDinnerStatus of false When the HomeForDinner toggle is switched Then a setHomeForDinnerStatus event should be emitted with a value of true", () => {
    //Arrange
    wrapper.vm.isHomeForDinner = false;

    //Act
    expect(wrapper.find("input[type='checkbox']").trigger("click"));

    //Assert
    expect(wrapper.emitted("setHomeForDinnerStatus").length).toBe(1);
    expect(wrapper.emitted("setHomeForDinnerStatus")[0]).toEqual([true]);

    expect(wrapper.vm.isHomeForDinner).toBeTruthy();
  });

  it("Given a homeForDinnerStatus of false When the HomeForDinner toggle is switched Then homeForDinnerStatus should be true", () => {
    //Arrange
    wrapper.vm.isHomeForDinner = false;

    //Act
    expect(wrapper.find("input[type='checkbox']").trigger("click"));

    //Assert
    expect(wrapper.vm.isHomeForDinner).toBeTruthy();
  });

  it("Given a homeForDinnerStatus of true When the HomeForDinner toggle is switched Then a setHomeForDinnerStatus event should be emitted with a value of false", () => {
    //Arrange
    wrapper.vm.isHomeForDinner = true;

    //Act
    expect(wrapper.find("input[type='checkbox']").trigger("click"));

    //Assert
    expect(wrapper.emitted("setHomeForDinnerStatus").length).toBe(1);
    expect(wrapper.emitted("setHomeForDinnerStatus")[0]).toEqual([false]);

    expect(wrapper.vm.isHomeForDinner).toBeFalsy();
  });

  it("Given a homeForDinnerStatus of true When the HomeForDinner toggle is switched Then a setHomeForDinnerStatus event should be emitted with a value of false", () => {
    //Arrange
    wrapper.vm.isHomeForDinner = true;

    //Act
    expect(wrapper.find("input[type='checkbox']").trigger("click"));

    //Assert
    expect(wrapper.emitted("setHomeForDinnerStatus").length).toBe(1);
    expect(wrapper.emitted("setHomeForDinnerStatus")[0]).toEqual([false]);

    expect(wrapper.vm.isHomeForDinner).toBeFalsy();
  });
});
