<template>
<base-count-card icon="mdi-home" :accent-color="accentColor" :message="computedMsg" />
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
export default class ApartmentStatusesCount extends Mixins(CountCardMixin) {
    //data
    messageTemplate: string = "Pending Statuses";
    accentColor: string = colors.dashboardCountAccentTwo;
}
</script>
