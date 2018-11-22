<template>
<v-card class="dashboard-card feed-card">
    <v-card-title primary-title>
        <div class="title">Feed</div>
    </v-card-title>

    <div class="card-scroll-content">
        <v-container fluid>
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

                    <v-subheader v-if="true">
                        Yesterday
                    </v-subheader>
                    <v-list-tile :key="item.title" avatar @click="">
                        <v-list-tile-avatar>
                            <img :src="'https://www.w3schools.com/w3images/avatar2.png'">
                                </v-list-tile-avatar>

                            <v-list-tile-content>
                                <v-list-tile-sub-title>Nicholas</v-list-tile-sub-title>
                                <v-list-tile-title>Don't forget next week is thanksgiving.</v-list-tile-title>
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

                    <v-list-tile :key="item.title" avatar @click="">
                        <v-list-tile-avatar>
                            <img :src="'https://www.w3schools.com/w3images/avatar2.png'">
                                </v-list-tile-avatar>

                            <v-list-tile-content>
                                <v-list-tile-sub-title>Nicholas</v-list-tile-sub-title>
                                <v-list-tile-title>Don't forget next week is thanksgiving.</v-list-tile-title>
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
export default class Feed extends Vue {
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

.feed-card {
    min-width: 350px;

    
}
</style>
