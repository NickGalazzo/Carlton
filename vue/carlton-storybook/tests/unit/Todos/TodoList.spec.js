import { shallowMount, createLocalVue } from "@vue/test-utils";
import VueRouter from "vue-router";
import Vuetify from "vuetify";
import Todo from "../../../src/components/Todos/TodoItem.vue";
import TodoList from "../../../src/components/Todos/TodoList.vue";
import { SilenceWarnHack } from "../../SilenceWarnHack";
import data from "./TestData.json";

const silenceWarnHack = new SilenceWarnHack();
let wrapper;

describe("TodoList Tests", () => {
  beforeEach(() => {
    silenceWarnHack.enable();
    const localVue = createLocalVue();
    localVue.use(Vuetify);
    localVue.use(VueRouter);

      wrapper = shallowMount(TodoList, {
      localVue: localVue,
      propsData: {
        items: data.items
      }
    });
    silenceWarnHack.disable();
  });

  it("Is a valid Vue component", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });

  it("Given Three todos Should result in Three TodoItem child controls rendered", () => {
    expect(wrapper.findAll(Todo).length).toBe(3);
  });
});
