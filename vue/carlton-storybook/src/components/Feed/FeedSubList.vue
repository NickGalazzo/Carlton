<template>
<div>
    <v-subheader>
        {{items.timePeriod}}
    </v-subheader>
    <feed-item v-for="(item, i) in items.feedItems" :key="i" :item="item" />
</div>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'

import FeedItem from './FeedItem.vue';
import {
    GroupedFeedItems
} from '../../models/FeedItemModel';

@Component({
    components: {
        FeedItem
    }
})
export default class FeedSubList extends Vue {
    @Prop() items!: GroupedFeedItems;
}
</script>
