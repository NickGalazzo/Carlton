import { storiesOf } from "@storybook/vue";
import { withKnobs, text, select } from "@storybook/addon-knobs";

import { action } from "@storybook/addon-actions";

import FeedItem from "../components/Feed/FeedItem.vue";
import FeedList from "../components/Feed/FeedList.vue";
import FeedSubList from "../components/Feed/FeedSubList.vue";
import Feed from "../components/Feed/Feed.vue";

let data = {
  items: [
    {
      timePeriod: "Today",
      feedItems: [
        {
          avatar:
            "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/Microsoft_Cortana_transparent.svg/1200px-Microsoft_Cortana_transparent.svg.png",
          title: "Garbage",
          message: "Nick took out the garbage."
        },
        {
          avatar:
            "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/Microsoft_Cortana_transparent.svg/1200px-Microsoft_Cortana_transparent.svg.png",
          title: "Household Items",
          message: "Nick purchased toilet paper."
        },
        {
          avatar: "https://www.w3schools.com/w3images/avatar2.png",
          title: "Nick",
          message: "Steve, can you please order christmas gifts."
        }
      ]
    },
    {
      timePeriod: "Yesterday",
      feedItems: [
        {
          avatar:
            "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/Microsoft_Cortana_transparent.svg/1200px-Microsoft_Cortana_transparent.svg.png",
          title: "Garbage",
          message: "Nick took out the garbage."
        },
        {
          avatar:
            "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/Microsoft_Cortana_transparent.svg/1200px-Microsoft_Cortana_transparent.svg.png",
          title: "Household Items",
          message: "Nick purchased toilet paper."
        },
        {
          avatar: "https://www.w3schools.com/w3images/avatar2.png",
          title: "Nick",
          message: "Steve, can you please order christmas gifts."
        }
      ]
    }
  ]
};

storiesOf("Feed", module)
.add("Default", () => ({
  components: {Feed},
  template: "<feed :items='items'/>",
  data: () => (data)
}))

storiesOf("Feed/Item", module)
  .addDecorator(withKnobs)
  .add("Default", () => ({
    components: { Feed },
    template: "<feed/>"
  }))
  .add("Default", () => {
    const avatarOptions = {
      system:
        "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/Microsoft_Cortana_transparent.svg/1200px-Microsoft_Cortana_transparent.svg.png",
      user: "https://www.w3schools.com/w3images/avatar2.png"
    };

    const avatars = select("Status", avatarOptions, avatarOptions.system);
    const title = text("Title", "Home for dinner");
    const message = text("Message", "Stephen will be home for dinner");

    return {
      components: { FeedItem },
      template: "<feed-item v-bind:item='item'/>",
      data: () => ({
        item: {
          avatar: avatars,
          title: title,
          message: message
        }
      })
    };
  });

storiesOf("Feed/Sublist")
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

storiesOf("Feed/List")
  .addDecorator(withKnobs)
  .add("Feed List", () => {
    return {
      components: { FeedList },
      template: "<feed-list :items='items'/>",
      data: () => (data)
    };
  });
