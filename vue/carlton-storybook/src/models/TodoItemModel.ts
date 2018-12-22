
export default class TodoItemModel {
    constructor(public todoId: number, public name: string, public isCompleted: boolean, public expiration: Date) {}
  }