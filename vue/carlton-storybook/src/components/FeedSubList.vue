<template>
<div>
    <v-subheader>
        Today
    </v-subheader>

    <feed-item v-for="(item, i) in items" v-bind:key="i" v-bind:item="item" />
</div>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'

import colors from '../styles/master.scss';
import FeedItem from '../components/FeedItem.vue';
import FeedItemModel from '../models/FeedItemModel';

@Component({
    components: {
        FeedItem
    }
})
export default class FeedSubList extends Vue {
    @Prop() items!: string;
    activeColor = colors.selected;
}
</script>

<style lang="scss" scoped>
@import "../styles/master.scss";

.subtitle {
    color: gray;
}
</style>
