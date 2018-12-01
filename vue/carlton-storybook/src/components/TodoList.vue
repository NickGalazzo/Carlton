<template>
<v-card class="dashboard-card todo-card">
    <v-card-title primary-title>
        <div class="title">Todos</div>
    </v-card-title>
    <div class="card-scroll-content">
        <v-container fluid>
            <v-list>
                <todo-item v-for="(item, i) in items" v-bind:key="i" v-bind:item="item"></todo-item>
            </v-list>
        </v-container>
    </div>
</v-card>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'
import colors from '../styles/master.scss';
import TodoItem from '../components/TodoItem.vue';
import TodoItemModel from '../models/TodoItemModel';

@Component({
    components: {
        TodoItem
    }
})
export default class Todos extends Vue {
    @Prop() items!: TodoItemModel;
    activeColor: string = colors.selected;
}
</script>

<style lang="scss" scoped>
@import "../styles/master.scss";

.todo-card {
    @extend %dashboard-card-wide;
}
</style>
