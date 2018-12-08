<template>
<v-card class="dashboard-card feed-card">
    <v-card-title primary-title>
        <div class="title">
            <span><slot name="title"/></span>
        </div>
    </v-card-title>

    <div class="card-scroll-content">
        <v-container fluid>
            <slot name="content" />
            <slot name="inputs" />
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

@Component
export default class FeedList extends Vue {

}
</script>

<style lang="scss" scoped>
@import "../../styles/master.scss";

.feed-card {
    @extend %dashboard-card-wide;
}
</style>
