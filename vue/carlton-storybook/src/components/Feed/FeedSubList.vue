<template functional>
<div>
    <v-subheader>
        Today
    </v-subheader>
    <feed-item v-for="(item, i) in props.items" v-bind:key="i" v-bind:item="item" />
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
import FeedItemModel from '../../models/FeedItemModel';

Vue.component('feed-item', FeedItem);

@Component
export default class FeedSubList extends Vue {
    @Prop() items!: string;
}
</script>

<style lang="scss" scoped>
@import "../../styles/master.scss";

.subtitle {
    color: gray;
}
</style>
