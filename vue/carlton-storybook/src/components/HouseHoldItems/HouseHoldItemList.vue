<template>
<div v-if="items.length > 0" class="card-scroll-content">
        <household-item v-for="(item, i) in items" :key="i" :item="item" />
    </div>
    <div v-else>
        <v-subheader>It looks like there are no items in the list.</v-subheader>
    </div>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'
import HouseholdItem from "./HouseholdItem.vue";
import HouseholdItemModel from "../../models/HouseolhdItemModel";


@Component({
    components: {HouseholdItem}
})
export default class HouseholdItemList extends Vue {
    @Prop() items!: HouseholdItemModel[];
}
</script>

<style lang="scss" scoped>
@import "../../styles/master.scss";

.house-hold-items-card {
    @extend %dashboard-card;
}
</style>
