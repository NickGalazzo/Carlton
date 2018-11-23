<template>
<v-card class="dashboard-card-small aggregate-card">
    <v-card-title primary-title>
        <v-layout>
            <v-flex xs4>
                <div class="card-img">
                    <v-icon size="25">mdi-clipboard-check</v-icon>
                </div>
            </v-flex>
            <v-flex xs8>
                <v-subheader v-if="true">
                    5 Open Tasks
                </v-subheader>
            </v-flex>
            <v-spacer></v-spacer>
        </v-layout>
    </v-card-title>
    <v-card-content>

    </v-card-content>
</v-card>
</template>

<script lang="ts">
import Vue from "vue";
import Vue, {
    PropOptions
} from "vue";
import Component from "vue-class-component";

// The @Component decorator indicates the class is a Vue component
@Component({
    props: {
        logo: String
    }
})
export default class AggregateCard extends Vue {
    //Data
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

<style lang="scss" scoped>
@import "../styles/master.scss";

.v-card.aggregate-card {
    @extend %dashboard-card-small;

    .v-card__title {
        .card-img {
            background-color: #a48adb;
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
