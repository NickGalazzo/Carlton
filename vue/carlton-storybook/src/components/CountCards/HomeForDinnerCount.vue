<template>
<base-count-card icon="mdi-silverware-fork-knife" :accent-color="accentColor" :message="computedMsg" />
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
import colors from '../../styles/colors.scss';

@Component({
    components: {
        BaseCountCard
    }
})
export default class HomeForDinnerCount extends Mixins(CountCardMixin) {
    //data
    accentColor: string = colors.dashboardCountAccentFour;

    // computed
    get messageTemplate(): string {
        if (this.count > 1) {
            return "People Home for Dinner";
        } else {
            return "Person Home for Dinner";
        }
    }
}
</script>
