<template>
<v-list-tile :key="item.title" avatar @click="">
    <v-list-tile-avatar>
        <img :src="item.avatar">
    </v-list-tile-avatar>

        <v-list-tile-content>
            <v-list-tile-sub-title class="subtitle">{{item.title}}</v-list-tile-sub-title>
            <v-list-tile-title>{{item.message}}</v-list-tile-title>
        </v-list-tile-content>
</v-list-tile>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'

import FeedItemModel from '../../models/FeedItemModel';

@Component
export default class FeedItem extends Vue {
    @Prop() item!: FeedItemModel;
}
</script>

<style lang="scss" scoped>
@import "../../styles/master.scss";

.subtitle{
    color:gray;
}
</style>
