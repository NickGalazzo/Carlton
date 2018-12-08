<template>
<base-dashboard-card>
    <template slot="title">
        <span>Household Items</span>
    </template>
    <template slot="content">
        <household-item-list :items="items" />
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
import HouseholdItemList from './HouseholdItemList.vue';
import HouseholdItemModel from '../../models/HouseholdItemModel';

@Component({
    components: {
        BaseDashboardCard,
        HouseholdItemList
    }
})
export default class HouseHoldItems extends Vue {
    @Prop() items!: HouseholdItemModel[];
}
</script>
