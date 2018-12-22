import { storiesOf } from "@storybook/vue";
import { withKnobs, text, boolean } from "@storybook/addon-knobs";

import { action } from "@storybook/addon-actions";
import Todos from "../components/Todos/Todos.vue";
import TodoItem from "../components/Todos/TodoItem.vue";
import TodoList from "../components/Todos/TodoList.vue";

let data = {
  items: [
    {
      name: "Take out garbage.",
      isCompleted: true
    },
    {
      name: "Empty the dishwasher.",
      isCompleted: true
    },
    {
      name: "Pay the rent.",
      isCompleted: false
    }
  ]
};

export const methods = {
  navigateToTodo: action('navigateToTodo')
};

storiesOf("Todos", module).add("Default", () => {
  return {
    components: { Todos },
    template: "<todos :items='items'/>",
    data: () => data
  };
});

storiesOf("Todos/Item", module)
  .addDecorator(withKnobs)
  .add("Incomplete", () => {
    const name = text("Task Name", "Take out the garbage.");
    const isCompleted = boolean("completed", false);

    return {
      components: { TodoItem },
      template: "<todo-item :item='item' @navigateToTodo='navigateToTodo'/>",
      data: () => ({
        item: {
          todoId: 1,
          name: name,
          isCompleted: isCompleted
        }
      }),
      methods
    };
  })
  .add("Completed", () => {
    const name = text("Task Name", "Take out the garbage.");
    const isCompleted = boolean("completed", true);

    return {
      components: { TodoItem },
      template: "<todo-item :item='item' @navigateToTodo='navigateToTodo'/>",
      data: () => ({
        item: {
          todoId: 1,
          name: name,
          isCompleted: isCompleted
        }
      }),
      methods
    };
  });

storiesOf("Todos/List", module).add("Todo List", () => ({
  components: { TodoList },
  template: "<todo-list v-bind:items='items'/>",
  data: () => data
}));
