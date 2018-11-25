<template>
<base-count-card icon="mdi-cart" v-bind:accent-color="accentColor" v-bind:message="computedMsg" />
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'

import BaseCountCard from "./BaseCountCard.vue";
import CountCardMixin from '../mixins/CountCardMixin';
import colors from "../styles/master.scss";

@Component({
    components: {
        BaseCountCard
    }
})
export default class LowItemsCount extends Mixins(CountCardMixin) {
     //data
    messageTemplate: string = "Low Items";
    accentColor = colors.dashboardCountAccentTwo;
}
</script>