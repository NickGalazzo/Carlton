<template>
<v-container fluid grid-list-lg style="background-color:#eeeeee">
    <v-layout row wrap>
        <v-flex xs3>
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
                                        <v-icon :color="!item.active ? 'teal' : 'grey'">mdi-food</v-icon>
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
                            <v-switch color="blue"></v-switch>
                            <v-text-field disabled="true" label="Where will you be?"></v-text-field>
                        </v-flex>
                        <v-spacer></v-spacer>
                    </v-layout>
                </div>
            </v-card>
        </v-flex>
        <v-flex xs3>
            <v-card class="dashboard-card">

                <v-card-title primary-title>
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
        <v-flex xs6>
            <v-card class="dashboard-card">
                <v-card-title primary-title>
                    <div class="title">Feed</div>
                </v-card-title>
                <div class="card-scroll-content">
                    <v-list two-line>
                        <template v-for="(item, index) in todos">
                            <v-subheader v-if="true">
                                Today
                            </v-subheader>

                            <v-list-tile :key="item.title" avatar @click="">
                                <v-list-tile-avatar>
                                    <img :src="'https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/Microsoft_Cortana_transparent.svg/1200px-Microsoft_Cortana_transparent.svg.png'">
                                </v-list-tile-avatar>

                                    <v-list-tile-content>
                                        <v-list-tile-sub-title>Home for dinner</v-list-tile-sub-title>
                                        <v-list-tile-title>Stephen will not be home for dinner tonight.</v-list-tile-title>
                                    </v-list-tile-content>

                            </v-list-tile>

                            <v-list-tile :key="item.title" avatar @click="">
                                <v-list-tile-avatar>
                                    <img :src="'https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/Microsoft_Cortana_transparent.svg/1200px-Microsoft_Cortana_transparent.svg.png'">
                                </v-list-tile-avatar>

                                    <v-list-tile-content>
                                        <v-list-tile-sub-title>Trash</v-list-tile-sub-title>
                                        <v-list-tile-title>Nick took out the trash.</v-list-tile-title>
                                    </v-list-tile-content>

                            </v-list-tile>

                            <v-list-tile :key="item.title" avatar @click="">
                                <v-list-tile-avatar>
                                    <img :src="'https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/Microsoft_Cortana_transparent.svg/1200px-Microsoft_Cortana_transparent.svg.png'">
                                </v-list-tile-avatar>

                                    <v-list-tile-content>
                                        <v-list-tile-sub-title>Trash</v-list-tile-sub-title>
                                        <v-list-tile-title>Nick cleaned the apartment.</v-list-tile-title>
                                    </v-list-tile-content>

                            </v-list-tile>

                            <v-list-tile :key="item.title" avatar @click="">
                                <v-list-tile-avatar>
                                    <img :src="'https://www.w3schools.com/w3images/avatar2.png'">
                                </v-list-tile-avatar>

                                    <v-list-tile-content>
                                        <v-list-tile-sub-title>Nicholas</v-list-tile-sub-title>
                                        <v-list-tile-title>Don't forget next week is thanksgiving.</v-list-tile-title>
                                    </v-list-tile-content>

                            </v-list-tile>
                        </template>
                    </v-list>

                </div>
            </v-card>

        </v-flex>
    </v-layout>
    <v-layout row>
        <v-flex xs12>
            <v-card class="dashboard-card">
                <v-card-title primary-title>
                    <div class="title">Todos</div>
                </v-card-title>
                <div class="card-scroll-content">
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
                </div>
            </v-card>
            <v-spaacer />
        </v-flex>
    </v-layout>

    <v-layout xs8 row>

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

.v-input__control {
    margin: auto;
}

.v-card.dashboard-card {
    height: 350px;
    font-family:"'Roboto', sans-serif !important";

    .v-card__title {
        // background-color:#5b5b60;
        // color:white;
    }

    .card-scroll-content {
        height: 290px;
        overflow-y: scroll;
        overflow-x: hidden;
    }
}
</style>
