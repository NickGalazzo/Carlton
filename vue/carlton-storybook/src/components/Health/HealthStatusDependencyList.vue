<template>
<div>
    <v-subheader>Dependencies</v-subheader>
    <health-status-dependency-list-item v-for="(item, i) in healthStatuses" :key="i" :health-status="item" />
</div>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from "vue-property-decorator";
import BaseDashboardCard from "../Base/BaseDashboardCard.vue";
import HealthStatusDependencyListItem from "./HealthStatusDependencyListItem.vue";
import {
    HealthStatusDependencyModel
} from "../../models/HealthStatusModel";

@Component({
    components: {
        HealthStatusDependencyListItem
    }
})
export default class HealthStatusDependencyList extends Vue {
    @Prop() healthStatuses!: HealthStatusDependencyModel[];
}
</script>

<style lang="scss" scoped>
@import "../../styles/master.scss";

.health-card {
    @extend %dashboard-card;

    height: 150px;

    i.status-icon {
        padding: 5px;
    }

    .v-card__title {
        .v-subheader {
            margin-left: 20px;
        }

        i.service-icon {
            margin: 0px;
        }
    }
}
</style>
