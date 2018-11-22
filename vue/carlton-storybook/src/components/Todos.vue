<template>
<v-card class=" task-card">

    <v-card-title primary-title>
        <div class="title">Tasks</div>
    </v-card-title>
    <div class="card-scroll-content">
        <v-container fluid>
            <v-list>
                <v-list-tile>
                   <v-checkbox :name="Test" :label="`Take out garbage.`"></v-checkbox>
                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>
                    <v-checkbox :name="Test" :label="`Go Shopping.`"></v-checkbox>
                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>
                    <v-checkbox :name="Test" :label="`Take out garbage.`"></v-checkbox>
                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>
                    <v-checkbox :name="Test" :label="`Go Shopping.`"></v-checkbox>
                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>
                    <v-checkbox :name="Test" :label="`Take out garbage.`"></v-checkbox>
                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>
                    <v-checkbox :name="Test" :label="`Go Shopping.`"></v-checkbox>

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

<style lang="scss">
.task-card {
    min-width: 400px;

    .v-list__tile__title {
        height: 30px;

    }

    .v-list__tile__action button {
        margin-left: 10px;
    }

    .v-input {

        .v-input__control {

            margin: inherit;
        }
    }

    .container {
        padding-top: 5px;

        .v-subheader {
            padding: 0px;
        }

        .v-btn--flat {
            min-width: 50px;
        }

        .v-list__tile {
            padding: 0px;
        }

    }
}
</style>
