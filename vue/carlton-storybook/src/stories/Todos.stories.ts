import { storiesOf } from "@storybook/vue";
import { withKnobs, text, boolean } from "@storybook/addon-knobs";
import { withTests } from "@storybook/addon-jest";

import { action } from "@storybook/addon-actions";
import Todos from "../components/Todos/Todos.vue";
import TodoItem from "../components/Todos/TodoItem.vue";
import TodoList from "../components/Todos/TodoList.vue";

import results from "../../tests/jest-test-results.json";
import data from "../../tests/unit/Todos/TestData.json";

export const methods = {
  navigateToTodo: action("navigateToTodo")
};

storiesOf("Todos", module).add("Default", () => {
  return {
    components: { Todos },
    template: "<todos :items='items'/>",
    data: () => data
  };
});

let model = Object.assign({}, data.items[0]);

storiesOf("Todos/Item", module)
  .addDecorator(withKnobs)
  .add("Incomplete", () => {
    const name = text("Task Name", "Take out the garbage.");
    const isCompleted = boolean("completed", false);

    model.name = name;
    model.isCompleted = isCompleted;

    return {
      components: { TodoItem },
      template: "<todo-item :item='item' @navigateToTodo='navigateToTodo'/>",
      data: () => ({
        item: model
      }),
      methods
    };
  })
  .add("Completed", () => {
    const name = text("Task Name", "Take out the garbage.");
    const isCompleted = boolean("completed", true);

    model.name = name;
    model.isCompleted = isCompleted;

    return {
      components: { TodoItem },
      template: "<todo-item :item='item' @navigateToTodo='navigateToTodo'/>",
      data: () => ({
        item: model
      }),
      methods
    };
  });


storiesOf("Todo/Tests", module)
  .addDecorator(withTests({results}))
  .add("Test Results ", () => "<div>Jest results in storybook</div>", {
    jest: ["Todo.spec.js", "TodoList.spec.js"]
  });
