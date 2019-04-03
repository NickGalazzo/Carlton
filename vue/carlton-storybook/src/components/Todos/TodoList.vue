<template>
<v-list>
    <todo-item v-for="(item, i) in items" :key="i" :item="item"></todo-item>
</v-list>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'
import TodoItem from './TodoItem.vue';
import TodoItemModel from '../../models/TodoItemModel';

Vue.component('todo-item', TodoItem);

@Component
export default class Todos extends Vue {
    @Prop() items!: TodoItemModel;
}
</script>

<style lang="scss" scoped>
@import "../../styles/master.scss";

.todo-card {
    @extend %dashboard-card-wide;
}
</style>
