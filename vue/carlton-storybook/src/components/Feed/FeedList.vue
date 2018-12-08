<template functional>
<v-card class="dashboard-card feed-card">
    <v-card-title primary-title>
        <div class="title">Feed</div>
    </v-card-title>

    <div class="card-scroll-content">
        <v-container fluid>
            <v-list two-line>
                <feed-sub-list v-for="(item, i) in props.items" :key="i" :items="props.items" />
            </v-list>
        </v-container>
    </div>

</v-card>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'

import FeedSubList from './FeedSubList.vue';
import {GroupedFeedItems} from '../../models/FeedItemModel';

Vue.component('feed-sub-list', FeedSubList);

@Component
export default class FeedList extends Vue {
    @Prop() items!: GroupedFeedItems[];
}
</script>

<style lang="scss" scoped>
@import "../../styles/master.scss";

.feed-card {
    @extend %dashboard-card-wide;
}
</style>
