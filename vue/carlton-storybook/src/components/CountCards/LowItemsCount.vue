<template>
<base-count-card icon="mdi-cart" :accent-color="accentColor" :message="computedMsg" />
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'

import BaseCountCard from "../Base/BaseCountCard.vue";
import CountCardMixin from '../../mixins/CountCardMixin';
import colors from "../../styles/colors.scss";

@Component({
    components: {
        BaseCountCard
    }
})
export default class LowItemsCount extends Mixins(CountCardMixin) {
    //data
    messageTemplate: string = "Low Items";
    accentColor: string = colors.dashboardCountAccentThree;
}
</script>

