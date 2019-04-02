import { storiesOf } from "@storybook/vue";
import { withKnobs, text, select } from "@storybook/addon-knobs";
import { action } from "@storybook/addon-actions";
import { withTests } from "@storybook/addon-jest";

import FeedItem from "../components/Feed/FeedItem.vue";
import FeedList from "../components/Feed/FeedList.vue";
import FeedSubList from "../components/Feed/FeedSubList.vue";
import Feed from "../components/Feed/Feed.vue";
import results from "../../tests/jest-test-results.json";

import data from "../../tests/unit/Feed/TestData.json";


storiesOf("Feed", module)
  .addDecorator(withTests({ results }))
  .add("Default", () => ({
    components: { Feed },
    template: "<feed :items='items'/>",
    data: () => data
  }));

let model = Object.assign({}, data).items[0].feedItems[0];

storiesOf("Feed/Item", module)
  .addDecorator(withKnobs)
  .add("Default", () => {
    const avatarOptions = {
      system:
        "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/Microsoft_Cortana_transparent.svg/1200px-Microsoft_Cortana_transparent.svg.png",
      user: "https://www.w3schools.com/w3images/avatar2.png"
    };

    const avatar = select("Avatar", avatarOptions, avatarOptions.system);
    const title = text("Title", "Home for dinner");
    const message = text("Message", "Stephen will be home for dinner");

    model.avatar = avatar;
    model.title = title;
    model.message = message;

    return {
      components: { FeedItem },
      template: "<feed-item :item='item'/>",
      data: () => ({ item: model })
    };
  });

storiesOf("Feed/Sublist", module)
  .addDecorator(withKnobs)
  .add("Default", () => {
    return {
      components: { FeedSubList },
      template: "<feed-sub-list :items='todayItems'/>",
      data: () => ({
        todayItems: data.items[0]
      })
    };
  });

storiesOf("Feed/List", module)
  .addDecorator(withKnobs)
  .add("Feed List", () => {
    return {
      components: { FeedList },
      template: "<feed-list :items='items'/>",
      data: () => data
    };
  });

storiesOf("Feed", module)
  .addDecorator(withTests({ results }))
  .add(
    "Test Results ",
    () => "<div>Jest results in storybook</div>",
    {
      jest: ["FeedItem.spec.js", "FeedSubList.spec.js", "FeedList.spec.js"]
    }
  );
