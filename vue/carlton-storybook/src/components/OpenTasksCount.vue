<template>
<base-count-card icon="mdi-clipboard-check" v-bind:accent-color="accentColor" v-bind:message="computedMsg" />
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
export default class OpenTasksCountCard extends Mixins(CountCardMixin) {
     //data
    messageTemplate: string = "Open Tasks";
    accentColor = colors.dashboardCountAccentOne;
}
</script>

