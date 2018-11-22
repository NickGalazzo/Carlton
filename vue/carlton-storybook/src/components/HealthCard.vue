<template>
<v-card>
    <v-card-title primary-title>
        <v-layout>
            <v-flex xs4>
                <div class="card-img">
                    <v-icon size="35">mdi-account-circle</v-icon>
                </div>
            </v-flex>
            <v-flex xs8>
                <v-subheader v-if="true">
                    Identity Service
                </v-subheader>
            </v-flex>
            <v-spacer></v-spacer>
        </v-layout>
    </v-card-title>
    <v-card-content>
        <v-card-actions>
            <v-btn flat>Details</v-btn>

            <v-spacer></v-spacer>
            <v-btn icon @click="show = !show">
                <v-icon>{{ show ? 'mdi-chevron-up' : 'mdi-chevron-down' }}</v-icon>
            </v-btn>
        </v-card-actions>

        <v-slide-y-transition v-show="show">

            <v-list subheader two-line v-show="show">
                <v-subheader>Dependencies</v-subheader>

                <v-list-tile @click="">
                    <v-layout row>
                        <v-flex xs3>
                            <v-img src="https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/Postgresql_elephant.svg/1200px-Postgresql_elephant.svg.png" height="50px" contain></v-img>
                        </v-flex>
                        <v-flex xs6>
                            <v-list-tile-content @click="sound = !sound">
                                <v-list-tile-title>Postgres Database</v-list-tile-title>
                            </v-list-tile-content>
                        </v-flex>

                        <v-flex xs3 style="margin:auto">
                            <v-icon color="green" class="right">mdi-check-circle-outline</v-icon>
                        </v-flex>
                    </v-layout>
                </v-list-tile>

                <v-list-tile @clik="">
                    <v-layout row>
                        <v-flex xs3>
                            <v-img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTatfY9pavyXntfu-i_p8ZN9FHdn37i8SIGU58NQPcDrTLVUKaq" height="50px" contain></v-img>
                        </v-flex>
                        <v-flex xs6>
                            <v-list-tile-content @click="sound = !sound">
                                <v-list-tile-title>RabbitMQ</v-list-tile-title>
                            </v-list-tile-content>
                        </v-flex>

                        <v-flex xs3 style="margin:auto">
                            <v-icon color="green" class="right">mdi-check-circle-outline</v-icon>
                        </v-flex>
                    </v-layout>
                </v-list-tile>

            </v-list>
        </v-slide-y-transition>
    </v-card-content>
</v-card>
</template>

<script lang="ts">
import Vue from "vue";
import Vue, {
    PropOptions
} from "vue";
import Component from "vue-class-component";

@Component({
    props: {

    }
})
export default class HealthCard extends Vue {
    //Data
    environments: string[] = ["Dev", "QA", "Production"];
    text: string = "This is text";
    show: bool = false;

    mounted() {
        this.environments = ["Dev", "QA", "Production"];
        this.text = "This is  text";
        this.show = false;
    }
}
</script>

<style lang="scss">
body {
    font-family: 'Roboto', sans-serif !important
}

.health-card {
    height: 200px;
    border-radius: 5px;

    .v-card__title {
        background-color: white;
        //color:white;
    }
}
</style>
