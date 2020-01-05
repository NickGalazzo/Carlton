<template>
<v-list>
    <div class="home-for-dinner-display">
        <template>
            <home-for-dinner-list-item v-for="(item, i) in items" :key="i" v-bind:item="item" />
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

import HomeForDinnerListItem from "./HomeForDinnerListItem.vue";
import HomeForDinnerModel from "../../models/HomeForDinnerModel";

@Component({
    components: {
        HomeForDinnerListItem
    }
})
export default class HomeForDinnerList extends Vue {
    @Prop() items!: HomeForDinnerModel[];
}
</script>
