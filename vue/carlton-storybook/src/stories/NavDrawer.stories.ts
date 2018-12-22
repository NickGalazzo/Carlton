import { storiesOf } from "@storybook/vue";
import { withKnobs, text, boolean } from "@storybook/addon-knobs";
import { action } from "@storybook/addon-actions";
import NavDrawer from "../components/Nav/NavDrawer.vue";


storiesOf("Nav Drawer", module).add("Default", () => ({
  components: { NavDrawer },
  template: "<nav-drawer />"
}));
