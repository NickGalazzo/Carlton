export default class ApartmentStatus {
  constructor(
    public name: string,
    public icon: string,
    public statusId: number
  ) {}
}

export enum StatusType {
  done = 1,
  pending = 2
}
