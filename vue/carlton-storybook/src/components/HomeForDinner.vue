<template>
<v-card class="home-for-dinner-card">
    <v-card-title primary-title>
        <div class="title">Home For Dinner</div>
    </v-card-title>

    <v-container fluid>
        <v-list>
            <div class="home-for-dinner-display">
                <template v-for="(item, index) in todos">
                    <v-divider v-if="item.divider" :inset="item.inset" :key="index"></v-divider>
                    <v-list-tile v-else :key="item.title" avatar @click="">
                        <v-list-tile-avatar>
                            <img :src="'https://www.w3schools.com/w3images/avatar2.png'">
                                </v-list-tile-avatar>

                            <v-list-tile-content>
                                <v-list-tile-title>{{item.name}}</v-list-tile-title>
                                <v-list-tile-sub-title class="home" v-if="item.homeForDinner">Home</v-list-tile-sub-title>
                                <v-list-tile-sub-title v-if="!item.homeForDinner">{{item.reason}}</v-list-tile-sub-title>
                            </v-list-tile-content>

                            <v-list-tile-action>
                                <v-icon :color="item.homeForDinner ? activeColor : 'grey'">mdi-food</v-icon>
                            </v-list-tile-action>
                    </v-list-tile>
                </template>
            </div>
        </v-list>

        <div class="home-for-dinner-input">
            <v-layout>
                <v-spacer></v-spacer>
                <v-flex class="heading-text" xs12>
                    <span >Are you home for dinner?</span>
                </v-flex>
                <v-spacer></v-spacer>
            </v-layout>
            <v-layout class="home-for-dinner-toggle">
                <v-spacer></v-spacer>
                <v-flex xs8>
                    <v-switch :color="activeColor"></v-switch>
                </v-flex>
                <v-spacer></v-spacer>
            </v-layout>
            <v-layout>
                <v-spacer></v-spacer>
                <v-text-field label="Where will you be?"></v-text-field>
                <v-spacer></v-spacer>
            </v-layout>
        </div>
    </v-container>
</v-card>
</template>

<script lang="ts">
import Vue from "vue";
import Vue, {
    PropOptions
} from "vue";
import Component from "vue-class-component";
import colors from '../styles/master.scss';

type homeForDinner = {
    name: string;
    status: boolean;
    reason: string;
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
                name: "Stephen",
                homeForDinner: false,
                reason: "Japanese Class"
            },
            {
                name: "Nicholas",
                homeForDinner: true,
                reason: ""
            }
        ];
    }
}
</script>

<style lang="scss" scoped>
@import "../styles/master.scss";

.home-for-dinner-card {
    @extend %dashboard-card;

    .home-for-dinner-display {
        .v-list-tile-sub-title {
            font-size: 10px;
        }

        .v-list__tile__sub-title {
            font-size: 12px;
        }

        .v-list__tile__sub-title.home {
            color: $active !important;
        }
    }

    .home-for-dinner-input {
        .heading-text {
            text-align: center;
        }

        .layout.home-for-dinner-toggle{
            height:30px;
            margin-top: 20px;
            .v-input--selection-controls{
                margin-top: 0px;
            }
        }

        .v-text-field{
            margin-top:15px;
        }
    }

}
</style>
