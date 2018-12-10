class BaseHealthStatusModel {
  constructor(
    public serviceName: string,
    public serviceIcon: string,
    public serviceHealthStatus: number
  ) {}
}

class HealthStatusModel extends BaseHealthStatusModel {
  constructor(
    serviceName: string,
    serviceIcon: string,
    serviceHealthStatus: number,
    public dependencies: HealthStatusDependencyModel[]
  ) {
    super(serviceName, serviceIcon, serviceHealthStatus);
  }
}

class HealthStatusDependencyModel extends BaseHealthStatusModel {
  constructor(
    dependencyName: string,
    dependencyIcon: string,
    dependencyHealthStatus: number
  ) {
    super(dependencyName, dependencyIcon, dependencyHealthStatus);
  }
}

class HealthStatusDisplayModel {
  constructor(public healthColor: string, public healthIcon: string) {}
}

export {
  BaseHealthStatusModel,
  HealthStatusModel,
  HealthStatusDependencyModel,
  HealthStatusDisplayModel
};
