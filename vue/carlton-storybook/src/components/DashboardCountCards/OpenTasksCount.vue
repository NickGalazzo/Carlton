<template>
<base-count-card icon="mdi-clipboard-check" v-bind:accent-color="accentColor" v-bind:message="computedMsg" />
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
export default class OpenTasksCountCard extends Vue {
    @Prop() count!: Number;

    //Data
    accentColor: string = "";

    // lifecycle hook
    mounted() {
        this.accentColor = colors.dashboardCountAccentOne;
    }

    // computed
    get computedMsg(): string {
        return this.count + " Open Tasks";
    }
}
</script>

<style lang="scss" scoped>

</style>
