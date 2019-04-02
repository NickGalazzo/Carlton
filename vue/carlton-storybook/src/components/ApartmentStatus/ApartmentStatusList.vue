<template>
<v-list class="apartment-status-list">
    <div>
        <template>
            <apartment-status-item v-for="(status, i) in statuses" :key="i" :status="status" />
        </template>
    </div>
</v-list>
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

.apartment-status-list {
    .layout {
        margin: 12px;
    }
}
</style>
