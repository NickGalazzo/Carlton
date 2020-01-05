export { HomeForDinnerData, ApartmentStatusData, FeedData };

const ApartmentStatusData = {
  statuses: [
    {
      icon: "mdi-delete",
      statusId: 1
    },
    {
      icon: "mdi-recycle",
      statusId: 1
    },
    {
      icon: "mdi-cart",
      statusId: 1
    },
    {
      icon: "mdi-spray-bottle",
      statusId: 1
    },
    {
      icon: "mdi-washing-machine",
      statusId: 1
    },
    {
      icon: "mdi-tie",
      statusId: 1
    }
  ]
};

const FeedData = {
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

const HomeForDinnerData = {
  items: [
    {
      name: "Nick",
      isHomeForDinner: false,
      reason: "Working late"
    },
    {
      name: "Stephen",
      isHomeForDinner: false,
      reason: "Japneese Class"
    }
  ]
};
