<template>
<base-dashboard-card>
    <template slot="title">
        <span>Feed</span>
    </template>
    <template slot="content">
        <feed-list :items="items" />
    </template>
</base-dashboard-card>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'

import BaseDashboardCard from '../Base/BaseDashboardCard.vue';
import FeedList from './FeedList.vue';
import {GroupedFeedItems} from '../../models/FeedItemModel';

@Component({
    components: {
        BaseDashboardCard,
        FeedList
    }
})
export default class Feed extends Vue {
    @Prop() items!: GroupedFeedItems[];
}
</script>
