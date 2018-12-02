<template functional>
<v-card class="apartment-status-card">
    <v-card-title primary-title>
        <div class="title">Apartment Status</div>
    </v-card-title>
    <v-container fluid>
        <apartment-status-item v-for="(status, i) in props.statuses" :key="i" :status="status" />
    </v-container>
</v-card>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'
import ApartmentStatusItem from './ApartmentStatusItem.vue';
import ApartmentStatusModel from '../../models/ApartmentStatusModel';

Vue.component("apartment-status-item", ApartmentStatusItem);

@Component({
    components: {
        ApartmentStatusItem
    }
})
export default class ApartmentStatusList extends Vue {
    @Prop() statuses!: ApartmentStatusModel[];
}
</script>

<style lang="scss" scoped>
@import "../../styles/master.scss";

.apartment-status-card {
    @extend %dashboard-card;

    .layout {
        margin: 12px;
    }
}
</style>
