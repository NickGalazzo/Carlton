<template>
<base-count-card icon="mdi-silverware-fork-knife" v-bind:accent-color="$style.accentColor" v-bind:message="computedMsg" />
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'

import BaseCountCard from "./BaseCountCard.vue";
import CountCardMixin from '../../mixins/CountCardMixin';


@Component({
    components: {
        BaseCountCard
    }
})
export default class HomeForDinnerCount extends Mixins(CountCardMixin) {
}
</script>

<style lang="scss" module>
@import "../../styles/master.scss";

:export {
  accentColor: $dashboardCountAccentFour;
}
</style>
