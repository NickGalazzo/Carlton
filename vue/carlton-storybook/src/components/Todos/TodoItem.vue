<template>
<div class="todo">
    <v-list-tile>
        <v-icon v-if="item.isCompleted" class="completed right" :color="true ? $style.checkedColor : 'grey'">mdi-checkbox-marked-circle</v-icon>
        <v-checkbox v-bind:class="{ 'completed': item.isCompleted }" :label="item.name" v-model="item.isCompleted"></v-checkbox>
        <v-list-tile-action>
            <v-btn flat small :color="$style.buttonColor">View</v-btn>
        </v-list-tile-action>
    </v-list-tile>
</div>
</template>

<script lang="ts">
import {
    Vue,
    Component,
    Prop,
    Mixins
} from 'vue-property-decorator'

import TodoItemModel from '../../models/TodoItemModel';

@Component
export default class TodoItem extends Vue {
    @Prop() item!: TodoItemModel;
}
</script>

<style lang="scss" module>
@import "../../styles/master.scss";

.todo {
    max-width: 300px;
}

i.completed {
    padding-right: 20px;
}

.v-list__tile__action button {
    margin-left: 10px;
}

.v-input /deep/ .v-input--selection-controls__input {
    margin-right: 20px;
}

.v-input /deep/ .v-input__control {
    width: 100%;
}

.v-input.completed /deep/ .v-input--selection-controls__input {
    display: none;
}

.v-input.completed /deep/ label {
    text-decoration: line-through;
}

:export {
    checkedColor: $checkedColor;
    buttonColor: $buttonColor;
}
</style>
