<template>
<v-list two-line>
                <feed-sub-list v-for="(item, i) in items" :key="i" :items="item" />
            </v-list>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'

import FeedSubList from './FeedSubList.vue';
import {
    GroupedFeedItems
} from '../../models/FeedItemModel';

@Component({
    components: {
        FeedSubList
    }
})
export default class FeedList extends Vue {
    @Prop() items!: GroupedFeedItems[];
}
</script>
