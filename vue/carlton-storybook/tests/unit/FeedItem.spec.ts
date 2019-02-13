import { shallowMount } from '@vue/test-utils';
import FeedItem from '../../src/components/Feed/FeedItem.vue';
import {FeedItemModel} from '../../src/models/FeedItemModel';

describe('FeedItem.vue', () => {
  it('renders props.msg when passed', () => {
    const wrapper = shallowMount(FeedItem, {
        propsData:{
            item: {avatar: "test", title: "test"}
        }
    })
    expect(wrapper.isVueInstance()).toBeTruthy()
  })
})
