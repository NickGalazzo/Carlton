import { storiesOf } from "@storybook/vue";
import { withKnobs, select } from "@storybook/addon-knobs";
import { withTests } from '@storybook/addon-jest';

import ApartmentStatus from "../components/ApartmentStatus/ApartmentStatus.vue";
import ApartmentStatusItem from "../components/ApartmentStatus/ApartmentStatusItem.vue";
import ApartmentStatusList from "../components/ApartmentStatus/ApartmentStatusList.vue";

const statusContextOptions = {
  Garbage: "mdi-delete",
  Recycle: "mdi-recycle",
  Shopping: "mdi-cart",
  Cleaning: "mdi-spray-bottle",
  Laundry: "mdi-washing-machine",
  DryCleaning: "mdi-tie"
};

const statusTypeOptions = {
  completed: 1,
  Pending: 2
};

const data = {
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

storiesOf("Apartment Status", module).add("Default", () => {
  return {
    components: {ApartmentStatus},
    template: "<apartment-status :statuses=statuses />",
    data: () => data
  };
});

storiesOf("Apartment Status/Item", module)
  .addDecorator(withKnobs)
  .add("Completed", () => {
    const statusIcon = select("Icon", statusContextOptions, "mdi-delete");
    const status = select("Status", statusTypeOptions, 1);

    return {
      components: { ApartmentStatusItem },
      template: "<apartment-status-item :status='status'/>",
      data: () => ({
        status: {
          icon: statusIcon,
          statusId: status
        }
      })
    };
  })
  .add("Pending", () => {
    const statusIcon = select("Icon", statusContextOptions, "mdi-delete");
    const status = select("Status", statusTypeOptions, 2);

    return {
      components: { ApartmentStatusItem },
      template: "<apartment-status-item :status='status'/>",
      data: () => ({
        status: {
          icon: statusIcon,
          statusId: status
        }
      })
    };
  });

storiesOf("Apartment Status/List", module)
  .addDecorator(withKnobs)
  .add("Default", () => {
    const garbageStatus = select("Garbage Status", statusTypeOptions, 1);
    const recycleStatus = select("Recycle Status", statusTypeOptions, 1);
    const shoppingStatus = select("Shopping Status", statusTypeOptions, 1);
    const cleaningStatus = select("Cleaning Status", statusTypeOptions, 1);
    const laundryStatus = select("Laundry Status", statusTypeOptions, 1);
    const dryCleaningStatus = select(
      "Dry-Cleaning Status",
      statusTypeOptions,
      1
    );

    var statuses = [
      garbageStatus,
      recycleStatus,
      shoppingStatus,
      cleaningStatus,
      laundryStatus,
      dryCleaningStatus
    ];

    for (let i = 0; i < statuses.length; i++) {
      data.statuses[i].statusId = statuses[i];
    }

    return {
      components: { ApartmentStatusList },
      template: "<apartment-status-list :statuses='statuses'/>",
      data: () => data
    };
  })
  .add("With Pending", () => {
    const garbageStatus = select("Garbage Status", statusTypeOptions, 1);
    const recycleStatus = select("Recycle Status", statusTypeOptions, 2);
    const shoppingStatus = select("Shopping Status", statusTypeOptions, 1);
    const cleaningStatus = select("Cleaning Status", statusTypeOptions, 2);
    const laundryStatus = select("Laundry Status", statusTypeOptions, 2);
    const dryCleaningStatus = select(
      "Dry-Cleaning Status",
      statusTypeOptions,
      1
    );

    var statuses = [
      garbageStatus,
      recycleStatus,
      shoppingStatus,
      cleaningStatus,
      laundryStatus,
      dryCleaningStatus
    ];

    for (let i = 0; i < statuses.length; i++) {
      data.statuses[i].statusId = statuses[i];
    }

    return {
      components: { ApartmentStatusList },
      template: "<apartment-status-list :statuses='statuses' />",
      data: () => data
    };
  });

