<template>
<base-dashboard-card>
    <template slot="title">
        <span>Apartment Status</span>
    </template>
    <template slot="content">
        <apartment-status-list :statuses="statuses" />
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
import ApartmentStatusList from './ApartmentStatusList.vue';
import ApartmentStatusModel from '../../models/ApartmentStatusModel';

@Component({
    components: {
        BaseDashboardCard,
        ApartmentStatusList
    }
})
export default class ApartmentStatus extends Vue {
    @Prop() statuses!: ApartmentStatusModel[];
}
</script>

