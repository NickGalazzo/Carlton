<template>
<v-container fluid grid-list-lg style="background-color:#eeeeee">
    <v-layout row wrap>

        <v-flex xs2>
            <v-card>
                <v-card-title primary-title style="background-color:#b8d8d8;color:white">
                    <div class="title">Home For Dinner</div>
                </v-card-title>

                <v-list>
                    <v-list-tile v-for="item in todos" :key="item.title" avatar @click="">
                        <v-list-tile-avatar>
                            <img :src="'https://www.w3schools.com/w3images/avatar2.png'">
                        </v-list-tile-avatar>

                            <v-list-tile-content>
                                <v-list-tile-title v-html="Testing"></v-list-tile-title>
                            </v-list-tile-content>

                            <v-list-tile-action>
                                <v-icon :color="!item.active ? 'teal' : 'grey'">mdi-food</v-icon>
                            </v-list-tile-action>
                    </v-list-tile>
                </v-list>

            </v-card>
        </v-flex>

    </v-layout>
    <v-layout>
        <v-flex xs8>
            <v-card>
                <v-card-title primary-title style="background-color:#b8d8d8;color:white">
                    <div class="title">Todos</div>
                </v-card-title>
                <v-data-table :items="todos" hide-actions>
                    <template slot="headers" slot-scope="props">
                        <tr style="color:blue">
                            <th style="color:#1dbfd4;font-size:12pt;font-weight:bold">
                                Task
                            </th>
                            <th style="color:#1dbfd4;font-size:12pt;font-weight:bold">
                                Status
                            </th>
                            <th style="color:#1dbfd4;font-size:12pt;font-weight:bold">
                                Expiration Date
                            </th>
                            <th style="color:#1dbfd4;font-size:12pt;font-weight:bold">
                                Close
                            </th>
                        </tr>
                    </template>
                    <template slot="items" slot-scope="props">
                        <tr>
                            <td class="text-xs-center">
                                {{props.item.name}}
                            </td class="text-xs-center">
                            <td class="text-xs-center">
                                <v-chip color="gray" text-color="white">Open</v-chip>
                            </td>
                            <td class="text-xs-center">12/2/2018</td>
                            <td class="text-xs-center">
                                <v-btn small color="#1dbfd4">Close</v-btn>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-xs-center">
                                {{props.item.name}}
                            </td class="text-xs-center">
                            <td class="text-xs-center">
                                <v-chip color="gray" text-color="white">Open</v-chip>
                            </td>
                            <td class="text-xs-center">12/2/2018</td>
                            <td class="text-xs-center">
                                <v-btn small color="#1dbfd4">Close</v-btn>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-xs-center">
                                {{props.item.name}}
                            </td class="text-xs-center">
                            <td class="text-xs-center">
                                <v-chip color="gray" text-color="white">Open</v-chip>
                            </td>
                            <td class="text-xs-center">12/2/2018</td>
                            <td class="text-xs-center">
                                <v-btn small color="#1dbfd4">Close</v-btn>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-xs-center">
                                {{props.item.name}}
                            </td class="text-xs-center">
                            <td class="text-xs-center">
                                <v-chip color="gray" text-color="white">Open</v-chip>
                            </td>
                            <td class="text-xs-center">12/2/2018</td>
                            <td class="text-xs-center">
                                <v-btn small color="#1dbfd4">Close</v-btn>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-xs-center">
                                {{props.item.name}}
                            </td class="text-xs-center">
                            <td class="text-xs-center">
                                <v-chip color="gray" text-color="white">Open</v-chip>
                            </td>
                            <td class="text-xs-center">12/2/2018</td>
                            <td class="text-xs-center">
                                <v-btn small color="#1dbfd4">Close</v-btn>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-xs-center">
                                {{props.item.name}}
                            </td class="text-xs-center">
                            <td class="text-xs-center">
                                <v-chip color="gray" text-color="white">Open</v-chip>
                            </td>
                            <td class="text-xs-center">12/2/2018</td>
                            <td class="text-xs-center">
                                <v-btn class="white--text" small color="#1dbfd4">Close</v-btn>
                            </td>
                        </tr>
                    </template>
                </v-data-table>
            </v-card>
        </v-flex>

        <v-flex xs4>
            <v-card>

                <v-card-title primary-title style="background-color:#b8d8d8;color:white">
                    <div class="title">Apartment Status</div>
                </v-card-title>

                <v-layout>
                    <v-flex xs4>
                        <v-icon color="blue" class="right">mdi-delete</v-icon>
                    </v-flex>
                    <v-spacer></v-spacer>
                    <v-flex xs4>
                        <v-icon color="green" class="right">mdi-checkbox-marked-circle</v-icon>
                    </v-flex>
                    <v-spacer></v-spacer>
                </v-layout>

                <v-layout>
                    <v-flex xs4>
                        <v-icon color="blue" class="right">mdi-recycle</v-icon>
                    </v-flex>
                    <v-spacer></v-spacer>
                    <v-flex xs4>
                        <v-icon color="green" class="right">mdi-checkbox-marked-circle</v-icon>
                    </v-flex>
                    <v-spacer></v-spacer>
                </v-layout>

                <v-layout>
                    <v-flex xs4>
                        <v-icon color="blue" class="right">mdi-cart</v-icon>
                    </v-flex>
                    <v-spacer></v-spacer>
                    <v-flex xs4>
                        <v-icon color="green" class="right">mdi-checkbox-marked-circle</v-icon>
                    </v-flex>
                    <v-spacer></v-spacer>
                </v-layout>

                <v-layout>
                    <v-flex xs4>
                        <v-icon color="blue" class="right">mdi-home</v-icon>
                    </v-flex>
                    <v-spacer></v-spacer>
                    <v-flex xs4>
                        <v-icon color="green" class="right">mdi-checkbox-marked-circle</v-icon>
                    </v-flex>
                    <v-spacer></v-spacer>
                </v-layout>

                <v-layout>
                    <v-flex xs4>
                        <v-icon color="blue" class="right">mdi-spray-bottle</v-icon>
                    </v-flex>
                    <v-spacer></v-spacer>
                    <v-flex xs4>
                        <v-icon color="green" class="right">mdi-checkbox-marked-circle</v-icon>
                    </v-flex>
                    <v-spacer></v-spacer>
                </v-layout>

                <v-layout>
                    <v-flex xs4>
                        <v-icon color="blue" class="right">mdi-washing-machine</v-icon>
                    </v-flex>
                    <v-spacer></v-spacer>
                    <v-flex xs4>
                        <v-icon color="green" class="right">mdi-checkbox-marked-circle</v-icon>
                    </v-flex>
                    <v-spacer></v-spacer>
                </v-layout>

                <v-layout>
                    <v-flex xs4>
                        <v-icon color="blue" class="right">mdi-tie</v-icon>
                    </v-flex>
                    <v-spacer></v-spacer>
                    <v-flex xs4>
                        <v-icon color="green" class="right">mdi-checkbox-marked-circle</v-icon>
                    </v-flex>
                    <v-spacer></v-spacer>

                </v-layout>

            </v-card>
        </v-flex>

    </v-layout>
</v-container>
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
        }, ];
    }
}
</script>

<style lang="scss">
table .v-btn__content {
    color: white;
}

th {
    color: #1dbfd4
}
</style>
