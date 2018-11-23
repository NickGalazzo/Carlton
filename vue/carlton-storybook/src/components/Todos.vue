<template>
<v-card class="dashboard-card todo-card">
    <v-card-title primary-title>
        <div class="title">Todos</div>
    </v-card-title>
    <div class="card-scroll-content">
        <v-container fluid>
            <v-list>
                <v-list-tile>
                    <v-icon class="todo-complete right" :color="true ? activeColor : 'grey'">mdi-checkbox-marked-circle</v-icon>
                    <v-checkbox class="selected" :label="`Take out garbage.`"></v-checkbox>
                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>
                    <v-checkbox :label="`Take out garbage.`"></v-checkbox>
                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>
                    <v-checkbox :label="`Go Shopping.`"></v-checkbox>
                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>
                    <v-checkbox :label="`Take out garbage.`"></v-checkbox>
                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>
                    <v-checkbox :label="`Go Shopping.`"></v-checkbox>
                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>
                    <v-checkbox :label="`Take out garbage.`"></v-checkbox>
                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>
                    <v-checkbox :label="`Go Shopping.`"></v-checkbox>

                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

            </v-list>
        </v-container>
    </div>
</v-card>
</template>

<script lang="ts">
import Vue from "vue";
import Vue, {
    PropOptions
} from "vue";
import Component from "vue-class-component";
import colors from '../styles/master.scss';

type TodoItem = {
    name: String;
    status: String;
    expiration: DateTime;
};

// The @Component decorator indicates the class is a Vue component
@Component({})
export default class Todos extends Vue {
    //Data
    todos: TodoItem[] = [];
    message: string = "Hello!";
    activeColor;
    stuff: boolean[] = [];
    activeColor: string = "";

    mounted() {

        this.activeColor = colors.selected;
        this.logo = "../../assets/house.jpg";
        this.todos = [{
            name: "Take out Garbage",
            status: "Open",
            expiration: "12/2/2018"
        }];
    }
}
</script>

<style lang="scss" scoped>
@import "../styles/master.scss";

.todo-card {
    @extend %dashboard-card-wide;

    i.todo-complete {
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

    .v-input.selected /deep/ .v-input--selection-controls__input {
        display: none;
    }

    .v-input.selected /deep/ label {
        text-decoration: line-through;
    }
}
</style>
