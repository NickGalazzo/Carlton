class FeedItemModel {
  constructor(
    public avatar: string,
    public title: string,
    public message: number
  ) {}
}

class GroupedFeedItems {
  constructor(public timePeriod: string, public feedItems: FeedItemModel[]) {}
}

export {
  GroupedFeedItems,
  FeedItemModel
}
