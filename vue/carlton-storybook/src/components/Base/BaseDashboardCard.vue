<template>
<v-card class="dashboard-card feed-card">
    <v-card-title primary-title>
        <div class="title">
            <span><slot name="title"></slot></span>
        </div>
    </v-card-title>

    <div class="card-scroll-content">
        <v-container fluid>
            <v-list two-line>
                <feed-sub-list v-for="(item, i) in items" v-bind:key="i" v-bind:items="items" />
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

import colors from '../../styles/master.scss';
import FeedSubList from './FeedSubList.vue';
import FeedItemModel from '../../models/FeedItemModel';

@Component({
    components: {
        FeedSubList
    }
})
export default class FeedList extends Vue {
    @Prop() items!: FeedItemModel[];
    activeColor = colors.selected;
}
</script>

<style lang="scss" scoped>
@import "../../styles/master.scss";

.feed-card {
    @extend %dashboard-card-wide;
}
</style>
