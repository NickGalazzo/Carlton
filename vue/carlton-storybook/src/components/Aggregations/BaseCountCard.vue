<template functional>
<v-card class="base-count-card">
    <v-card-title primary-title>
        <v-layout>
            <v-flex xs4>
                <div class="card-img" v-bind:style="{ 'background-color': props.accentColor}">
                    <v-icon size="25">{{props.icon}}</v-icon>
                </div>
            </v-flex>
            <v-flex xs8>
                <v-subheader>
                    <span>{{props.message}}</span>
                </v-subheader>
            </v-flex>
            <v-spacer></v-spacer>
        </v-layout>
    </v-card-title>
</v-card>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop
} from 'vue-property-decorator'

@Component
export default class BaseCountCard extends Vue {
    @Prop() icon!: String;
    @Prop() message!: string
    @Prop() accentColor!: string
}
</script>

<style lang="scss" scoped>
@import "../../styles/master.scss";

.v-card.base-count-card {
    @extend %dashboard-card-small;

    .v-card__title {
        .card-img {
            border-radius: 50px;
            height: 50px;
            width: 50px;
        }

        i {
            margin: 12.5px;
            color: white;
        }
    }
}
</style>
