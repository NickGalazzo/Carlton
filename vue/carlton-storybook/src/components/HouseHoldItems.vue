<template>
<v-card class="dashboard-card dinner-card">
    <v-card-title primary-title>
        <div class="title">Household Items</div>
    </v-card-title>
    <div class="card-scroll-content">
        <v-container>
            <v-list>
                <v-list-tile>
                    <v-list-tile-content>
                        <v-subheader>Toilet&nbsp;Paper</v-subheader>
                        <v-progress-linear color="red" height="10" value="15"></v-progress-linear>
                    </v-list-tile-content>

                    <v-list-tile-action>
                         <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>
                    <v-list-tile-content>
                        <v-subheader>Paper&nbsp;Towels</v-subheader>
                        <v-progress-linear color="yellow" height="10" value="50"></v-progress-linear>
                    </v-list-tile-content>

                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>
                    <v-list-tile-content>
                        <v-subheader>Dish&nbsp;Soap</v-subheader>
                        <v-progress-linear color="green" height="10" value="80"></v-progress-linear>
                    </v-list-tile-content>

                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>

                    <v-list-tile-content>
                        <v-subheader>Swiffers</v-subheader>
                        <v-progress-linear color="green" height="10" value="90"></v-progress-linear>
                    </v-list-tile-content>

                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>

                    <v-list-tile-content>
                        <v-subheader>Swiffers</v-subheader>
                        <v-progress-linear color="green" height="10" value="90"></v-progress-linear>
                    </v-list-tile-content>

                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>

                    <v-list-tile-content>
                        <v-subheader>Swiffers</v-subheader>
                        <v-progress-linear color="green" height="10" value="90"></v-progress-linear>
                    </v-list-tile-content>

                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>

                    <v-list-tile-content>
                        <v-subheader>Swiffers</v-subheader>
                        <v-progress-linear color="green" height="10" value="90"></v-progress-linear>
                    </v-list-tile-content>

                    <v-list-tile-action>
                        <v-btn flat small color="blue">View</v-btn>
                    </v-list-tile-action>
                </v-list-tile>

                <v-list-tile>

                    <v-list-tile-content>
                        <v-subheader>Swiffers</v-subheader>
                        <v-progress-linear color="green" height="10" value="90"></v-progress-linear>
                    </v-list-tile-content>

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

type TodoItem = {
    name: String;
    status: String;
    expiration: DateTime;
};

// The @Component decorator indicates the class is a Vue component
@Component({
    props: {
        logo: String
    }
})
export default class GarbageCard extends Vue {
    //Data
    todos: TodoItem[] = [];
    message: string = "Hello!";
    logo: "./assets/house.jpg";

    mounted() {
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

.dinner-card {
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
