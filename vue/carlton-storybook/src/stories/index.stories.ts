import { storiesOf } from "@storybook/vue";
import {
  withKnobs,
  text,
  boolean,
  number,
  select
} from "@storybook/addon-knobs";

//Dashboard Page
import GarbageCard from "../components/GarbageCard.vue";

storiesOf("Garbage Card", module).add("Defeault", () => ({
  components: { GarbageCard },
  template: "<garbage-card />"
}));

