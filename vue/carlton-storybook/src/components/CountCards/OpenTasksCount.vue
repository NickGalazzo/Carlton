<template>
<base-count-card icon="mdi-clipboard-check" :accent-color="accentColor" :message="computedMsg" />
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
export default class OpenTasksCountCard extends Mixins(CountCardMixin) {
     //data
    messageTemplate: string = "Open Tasks";
    accentColor: string = colors.dashboardCountAccentOne;
}
</script>
