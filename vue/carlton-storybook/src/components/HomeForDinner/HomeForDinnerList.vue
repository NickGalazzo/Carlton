<template functional>
<v-list>
    <div class="home-for-dinner-display">
        <template>
            <home-for-dinner-item v-for="(item, i) in props.items" :key="i" v-bind:item="item" />
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

import HomeForDinnerItem from "./HomeForDinnerItem.vue";
import HomeForDinnerModel from "../../models/HomeForDinnerModel";

Vue.component("home-for-dinner-item", HomeForDinnerItem);

@Component
export default class HomeForDinnerList extends Vue {
    @Prop() items!: HomeForDinnerModel[];
}
</script>

<style lang="scss" scoped>
@import "../../styles/master.scss";

.home-for-dinner-card {
    @extend %dashboard-card;

    .home-for-dinner-display {
        .v-list-tile-sub-title {
            font-size: 10px;
        }

        .v-list__tile__sub-title {
            font-size: 12px;
        }

        .v-list__tile__sub-title.home {
            color: $active !important;
        }
    }

    .home-for-dinner-input {
        .heading-text {
            text-align: center;
        }

        .layout.home-for-dinner-toggle {
            height: 30px;
            margin-top: 20px;

            .v-input--selection-controls {
                margin-top: 0px;
            }
        }

        .v-text-field {
            margin-top: 15px;
        }
    }
}
</style>
