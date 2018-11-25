<template>
<v-card class="apartment-status-card">
    <v-card-title primary-title>
        <div class="title">Apartment Status</div>
    </v-card-title>
    <v-container fluid>
      <apartment-status v-for="(status, i) in statuses" :key="i" v-bind:status="status"/>
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
import ApartmentStatus from '../components/ApartmentStatus.vue'
import colors from '../styles/master.scss';

// The @Component decorator indicates the class is a Vue component
@Component({
    components:{
        ApartmentStatus
    }
})
export default class ApartmentStatusList extends Vue {
   @Prop() statuses!: ApartmentStatus[];

    //Data
    activeColor = "";
    neutralIconColor = "";

    mounted() {
        this.activeColor = colors.selected;
        this.neutralIconColor = colors.neutralIcon;
    }
}
</script>

<style lang="scss" scoped>
@import "../styles/master.scss";

.apartment-status-card {
    @extend %dashboard-card;
    .layout {
        margin: 12px;
    }
}
</style>
