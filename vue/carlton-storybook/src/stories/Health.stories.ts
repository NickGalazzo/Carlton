import { storiesOf } from "@storybook/vue";
import { withKnobs, text, select } from "@storybook/addon-knobs";
import { action } from "@storybook/addon-actions";

import HealthStatusCard from "../components/Health/HealthStatusCard.vue";
import HealthStatusDependencyList from "../components/Health/HealthStatusDependencyList.vue";
import HealthStatusDependencyItem from "../components/Health/HealthStatusDependencyListItem.vue";

const serviceOptions = {
  Identity: "mdi-account-circle"
};

const dependencyOptions = {
  Postgres:
    "https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/Postgresql_elephant.svg/1200px-Postgresql_elephant.svg.png",
  RabbitMQ:
    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTatfY9pavyXntfu-i_p8ZN9FHdn37i8SIGU58NQPcDrTLVUKaq"
};

const serviceHealthOptions = {
  Healthy: 1,
  Degraded: 2,
  Error: 3
};

const data = {
  service: {
    serviceName: "Identity Service",
    serviceIcon: "mdi-account-circle",
    serviceHealthStatus: 1,
    dependencies: [
      {
        serviceName: "Postgres",
        serviceIcon:
          "https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/Postgresql_elephant.svg/1200px-Postgresql_elephant.svg.png",
        serviceHealthStatus: 1
      },
      {
        serviceName: "RabbitMQ",
        serviceIcon:
          "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTatfY9pavyXntfu-i_p8ZN9FHdn37i8SIGU58NQPcDrTLVUKaq",
        serviceHealthStatus: 1
      }
    ]
  }
};

storiesOf("Health/Health Card", module)
  .addDecorator(withKnobs)
  .add("Healthy", () => {
    const serviceIcon = select("Icon", serviceOptions, "mdi-account-circle");
    const healthStatus = select("Status", serviceHealthOptions, 1);

    let model = Object.assign({}, data);
    model.service.serviceIcon = serviceIcon;
    model.service.serviceHealthStatus = healthStatus;

    return {
      components: { HealthStatusCard },
      template: "<health-status-card :health-status='service'/>",
      data: () => model
    };
  })
  .add("Degraded", () => {
    const serviceIcon = select("Icon", serviceOptions, "mdi-account-circle");
    const healthStatus = select("Status", serviceHealthOptions, 2);

    let model = Object.assign({}, data);
    model.service.serviceIcon = serviceIcon;
    model.service.serviceHealthStatus = healthStatus;

    return {
      components: { HealthStatusCard },
      template: "<health-status-card :health-status='service'/>",
      data: () => model
    };
  })
  .add("Error", () => {
    const serviceIcon = select("Icon", serviceOptions, "mdi-account-circle");
    const healthStatus = select("Status", serviceHealthOptions, 3);

    let model = Object.assign({}, data);
    model.service.serviceIcon = serviceIcon;
    model.service.serviceHealthStatus = healthStatus;

    return {
      components: { HealthStatusCard },
      template: "<health-status-card :health-status='service'/>",
      data: () => model
    };
  });

storiesOf("Health/Health Dependency Item")
  .addDecorator(withKnobs)
  .add("Healthy", () => {
    const serviceIcon = select(
      "Icon",
      dependencyOptions,
      "https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/Postgresql_elephant.svg/1200px-Postgresql_elephant.svg.png"
    );
    const healthStatus = select("Status", serviceHealthOptions, 1);

    let model = Object.assign({}, data.service.dependencies[0]);
    model.serviceIcon = serviceIcon;
    model.serviceHealthStatus = healthStatus;

    return {
      components: { HealthStatusDependencyItem },
      template: "<health-status-dependency-item :health-status='service'/>",
      data: () => ({ service: model })
    };
  })
  .add("Degraded", () => {
    const serviceIcon = select(
      "Icon",
      dependencyOptions,
      "https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/Postgresql_elephant.svg/1200px-Postgresql_elephant.svg.png"
    );
    const healthStatus = select("Status", serviceHealthOptions, 2);

    let model = Object.assign({}, data.service.dependencies[0]);
    model.serviceIcon = serviceIcon;
    model.serviceHealthStatus = healthStatus;

    return {
      components: { HealthStatusDependencyItem },
      template: "<health-status-dependency-item :health-status='service'/>",
      data: () => ({ service: model })
    };
  })
  .add("Error", () => {
    const serviceIcon = select(
      "Icon",
      dependencyOptions,
      "https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/Postgresql_elephant.svg/1200px-Postgresql_elephant.svg.png"
    );
    const healthStatus = select("Status", serviceHealthOptions, 3);

    let model = Object.assign({}, data.service.dependencies[0]);
    model.serviceIcon = serviceIcon;
    model.serviceHealthStatus = healthStatus;

    return {
      components: { HealthStatusDependencyItem },
      template: "<health-status-dependency-item :health-status='service'/>",
      data: () => ({ service: model })
    };
  });

storiesOf("Health/Dependency List", module)
  .add("Default", () => {
    return {
      components: { HealthStatusDependencyList },
      template:
        "<health-status-dependency-list :health-statuses='dependencies'/>",
      data: () => ({ dependencies: data.service.dependencies })
    };
  })
  .add("With Degraded Status", () => {
    return {
      components: { HealthStatusDependencyList },
      template:
        "<health-status-dependency-list :health-statuses='dependencies'/>",
      data: () => ({
        dependencies: [
          {
            serviceName: "Postgres",
            serviceIcon:
              "https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/Postgresql_elephant.svg/1200px-Postgresql_elephant.svg.png",
            serviceHealthStatus: 1
          },
          {
            serviceName: "RabbitMQ",
            serviceIcon:
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTatfY9pavyXntfu-i_p8ZN9FHdn37i8SIGU58NQPcDrTLVUKaq",
            serviceHealthStatus: 2
          }
        ]
      })
    };
  })
  .add("With Error Status", () => {
    return {
      components: { HealthStatusDependencyList },
      template:
        "<health-status-dependency-list :health-statuses='dependencies'/>",
      data: () => ({
        dependencies: [
          {
            serviceName: "Postgres",
            serviceIcon:
              "https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/Postgresql_elephant.svg/1200px-Postgresql_elephant.svg.png",
            serviceHealthStatus: 1
          },
          {
            serviceName: "RabbitMQ",
            serviceIcon:
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTatfY9pavyXntfu-i_p8ZN9FHdn37i8SIGU58NQPcDrTLVUKaq",
            serviceHealthStatus: 3
          }
        ]
      })
    };
  });;
