<template>
<base-count-card icon="mdi-home" v-bind:accent-color="accentColor" v-bind:message="computedMsg" />
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
export default class ApartmentStatusesCount extends Mixins(CountCardMixin) {
     //data
    messageTemplate: string = "statuses pending";
    accentColor = colors.dashboardCountAccentThree;
}
</script>