<template>
<v-card class="house-hold-items-card">
    <v-card-title primary-title>
        <div class="title">Household Items</div>
    </v-card-title>
    <div v-if="items.length > 0" class="card-scroll-content">
        <house-hold-item v-for="(item, i) in items" :key="i" v-bind:item="item" />
    </div>
    <div v-else>
        <v-subheader>It looks like there are no items in the list.</v-subheader>
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
import HouseHoldItem from "../components/HouseHoldItem.vue";

@Component({
    components: {
        HouseHoldItem
    }
})
export default class HouseHoldItemList extends Vue {
    @Prop() items!: HouseHoldItem[];
}
</script>

<style lang="scss" scoped>
@import "../styles/master.scss";

.house-hold-items-card {
    @extend %dashboard-card;
}
</style>
