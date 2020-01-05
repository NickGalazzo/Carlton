import { shallowMount, mount, createLocalVue } from "@vue/test-utils";
import VueRouter from "vue-router";
import Vuetify from "vuetify";
import TodoItem from "../../../src/components/Todos/TodoItem.vue";
import { SilenceWarnHack } from "../../SilenceWarnHack";
import data from "./TestData.json";

const silenceWarnHack = new SilenceWarnHack();
let wrapper;

describe("Render Tests", () => {
  beforeEach(() => {
    silenceWarnHack.enable();
    wrapper = createWrapper(true);
    silenceWarnHack.disable();
  });

  it("Is a valid Vue component", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });

  it("Renders a view button", () => {
    expect(wrapper.find(".view-btn").exists()).toBeTruthy();
  });

  it("Renders a Vuetify checkbox", () => {
    expect(wrapper.find("input[type='checkbox']").exists()).toBeTruthy();
  });

  it("Renders a label", () => {
    expect(wrapper.find("label").exists()).toBeTruthy();
  });

  it("Given a todo should render label with correct todo text", () => {
    expect(wrapper.find("label").text()).toBe("Take out garbage.");
  });
});

describe("Not Completed Tasks", () => {
  beforeEach(() => {
    silenceWarnHack.enable();
    wrapper = createWrapper(false);
    silenceWarnHack.disable();
  });

  it("Given an incomplete Todo then completed icon should not be rendered", () => {
    expect(wrapper.find("i.mdi-checkbox-marked-circle").exists()).toBeFalsy();
  });

  it("Given a completed Todo then checkbox should be rendered", () => {
    expect(wrapper.find("i.mdi-checkbox-blank-outline").exists()).toBeTruthy();
  });
});

describe("Completed Todos", () => {
  beforeEach(() => {
    silenceWarnHack.enable();
    wrapper = createWrapper(true);
    silenceWarnHack.disable();
  });

  it("Given a completed Todo then completed icon should be rendered", () => {
    expect(wrapper.find("i.mdi-checkbox-marked-circle").exists()).toBeTruthy();
  });

  it("Given a completed Todo then checkbox should not be rendered", () => {
    expect(wrapper.find("i.mdi-checkbox-blank-outline").exists()).toBeFalsy();
  });
});

describe("Interaction Tests", () => {
  beforeEach(() => {
    silenceWarnHack.enable();
    wrapper = createWrapper(false);
    silenceWarnHack.disable();
  });

  it("Given an incomplete todo When clicking the checkbox Then the checkbox should be removed.", () => {
    //Arrange
    const checkbox = wrapper.find("input[type='checkbox']");
    var icon = wrapper.find("i.mdi-checkbox-blank-outline");

    //Act
    checkbox.trigger('click');

    //Assert
    expect(wrapper.find("i.mdi-checkbox-blank-outline").exists()).toBeFalsy();
  });

  it("Given a completed todo When clicking the checkbox Then the checkbox should be removed.", () => {
    //Arrange
    const checkbox = wrapper.find("input[type='checkbox']");
    var icon = wrapper.find("i.mdi-checkbox-blank-outline");

    //Act
    checkbox.trigger('click');

    //Assert
    expect(wrapper.find("i.mdi-checkbox-blank-outline").exists()).toBeFalsy();
  });
});

function createWrapper(isCompleted) {
  const localVue = createLocalVue();

  localVue.use(Vuetify);
  localVue.use(VueRouter);

  var todo = data.items[0];
  todo.isCompleted = isCompleted;

  let wrapper = mount(TodoItem, {
    localVue: localVue,
    propsData: {
      item: todo
    }
  });

  return wrapper;
}
