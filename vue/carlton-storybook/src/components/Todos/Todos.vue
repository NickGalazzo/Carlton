<template>
<base-dashboard-card>
    <template slot="title">
        <span>Todos</span>
    </template>
    <template slot="content">
        <todo-list :items="items" />
    </template>
</base-dashboard-card>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'

import BaseDashboardCard from '../Base/BaseDashboardCard.vue';
import TodoList from './TodoList.vue';
import TodoItemModel from '../../models/TodoItemModel';

@Component({
    components: {
        BaseDashboardCard,
        TodoList
    }
})
export default class Todos extends Vue {
    @Prop() items!: TodoItemModel[];
}
</script>
