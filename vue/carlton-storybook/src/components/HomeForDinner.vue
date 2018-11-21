<template>
<v-card class="dashboard-card">
    <v-card-title primary-title>
        <div class="title">Home For Dinner</div>
    </v-card-title>

    <div>
        <v-list>
            <template v-for="(item, index) in todos">

                <v-divider v-if="item.divider" :inset="item.inset" :key="index"></v-divider>

                <v-list-tile v-else :key="item.title" avatar @click="">
                    <v-list-tile-avatar>
                        <img :src="'https://www.w3schools.com/w3images/avatar2.png'">
                                </v-list-tile-avatar>

                        <v-list-tile-content>
                            <v-list-tile-title>Stephen</v-list-tile-title>
                            <v-list-tile-sub-title>Japaneese Class</v-list-tile-sub-title>
                        </v-list-tile-content>

                        <v-list-tile-action>
                            <v-icon :color="true ? activeColor : 'grey'">mdi-food</v-icon>
                        </v-list-tile-action>

                </v-list-tile>
            </template>
        </v-list>

        <v-layout>
            <v-spacer></v-spacer>
            <v-flex xs6>
                <span>Are you home for dinner?</span>
            </v-flex>
            <v-spacer></v-spacer>
        </v-layout>
        <v-layout>
            <v-spacer></v-spacer>
            <v-flex xs8>
                <v-switch :color="activeColor"></v-switch>
                <v-text-field disabled="true" label="Where will you be?"></v-text-field>
            </v-flex>
            <v-spacer></v-spacer>
        </v-layout>
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
export default class HomeForDinner extends Vue {
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
@import "../styles/master.scss";


</style>
