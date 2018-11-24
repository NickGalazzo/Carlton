<template>
<base-count-card icon="mdi-silverware-fork-knife" v-bind:accent-color="accentColor" v-bind:message="computedMsg" />
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop
} from 'vue-property-decorator'
import BaseCountCard from "./BaseCountCard.vue";
import colors from '../../styles/master.scss';

// The @Component decorator indicates the class is a Vue component
@Component({
    components: {
        BaseCountCard
    }
})
export default class HomeForDinnerCount extends Vue {
    @Prop() count!: Number;

    //Data
    accentColor: string = "";

    // lifecycle hook
    mounted() {
        this.accentColor = colors.dashboardCountAccentFour;
    }

    // computed
    get computedMsg(): string {
        return this.count + " People Home for Dinner";
    }
}
</script>

<style lang="scss" scoped>

</style>
