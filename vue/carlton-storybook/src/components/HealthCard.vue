<template>
<div>
    <v-toolbar tabs color="#eeeeee">
        <v-toolbar-title class="black--text">Application Health</v-toolbar-title>

        <v-tabs slot="extension" color="green" v-model="model" centered>
            <v-tab color="white" v-for="(environment, i) in environments" :key="i" :href="`#tab-${i}`" class="white--text">
                {{ environment }}
            </v-tab>
        </v-tabs>
    </v-toolbar>

    <v-tabs-items v-model="model">
        <v-tab-item v-for="(environment, i) in environments" :id="`tab-${i}`" :key="i">
            <v-card>
                <v-container fluid grid-list-lg style="background-color:#eeeeee">
                    <v-layout row wrap>
                        <v-flex xs3>
                            <v-card class="rounded-card">
                               
                                <v-card-title primary-title style="background-color:#364150;color:white;">
                                    <div class="title">Identity Service</div>
                                     <v-icon color="green" class="right" style="background-colr:#364150;">mdi-check-circle-outline</v-icon>
                                </v-card-title>
                                <v-layout>
                                    <v-spacer></v-spacer>
                                    <v-flex xs4>
                                        <v-img src="https://previews.123rf.com/images/businessvector/businessvector1510/businessvector151000099/45788615-icono-de-tarjetas-de-identificaci%C3%B3n.jpg" height="50px" contain></v-img>
                                    </v-flex>
                                    <v-spacer></v-spacer>
                                </v-layout>
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
                                            <v-img src="https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/Postgresql_elephant.svg/1200px-Postgresql_elephant.svg.png" height="50px" contain></v-img>
                                            <v-list-tile-content @click="sound = !sound">
                                                <v-list-tile-title>Postgres Database</v-list-tile-title>
                                            </v-list-tile-content>

                                            <v-icon color="green" class="right">mdi-check-circle-outline</v-icon>
                                        </v-list-tile>

                                        <v-list-tile @click="">
                                            <v-img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTatfY9pavyXntfu-i_p8ZN9FHdn37i8SIGU58NQPcDrTLVUKaq" height="50px" contain></v-img>
                                            <v-list-tile-content @click="sound = !sound">
                                                <v-list-tile-title>RabbitMQ</v-list-tile-title>
                                            </v-list-tile-content>
                                            <v-icon color="green" class="right">mdi-check-circle-outline</v-icon>
                                        </v-list-tile>

                                    </v-list>
                                </v-slide-y-transition>
                            </v-card>
                        </v-flex>

                        <v-flex xs3>
                            <v-card>
                                <v-card-title primary-title>
                                    <!--<div class="title">Garbage Service</div>-->
                                    <v-icon color="#364150" class="text-xs-right justify-right" justify-right>mdi-account</v-icon>
                                </v-card-title>
                                <v-layout>
                                    <v-spacer></v-spacer>
                                    <v-flex xs5 centered>
                                        <v-img src="https://www.iconsdb.com/icons/preview/green/trash-10-xxl.png" height="50px" contain></v-img>
                                    </v-flex>
                                    <v-spacer></v-spacer>
                                </v-layout>
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
                                            <v-list-tile-content @click="sound = !sound">
                                                <v-list-tile-title>Postgres Database</v-list-tile-title>
                                            </v-list-tile-content>
                                            <v-icon color="green" class="right">mdi-checkbox-blank-circle</v-icon>
                                        </v-list-tile>

                                        <v-list-tile @click="">
                                            <v-list-tile-content @click="sound = !sound">
                                                <v-list-tile-title>RabbitMQ Message Bus</v-list-tile-title>
                                            </v-list-tile-content>
                                            <v-icon color="green" class="right">mdi-checkbox-blank-circle</v-icon>
                                        </v-list-tile>

                                    </v-list>
                                </v-slide-y-transition>
                            </v-card>
                        </v-flex>
                        <v-flex xs3>
                            <v-card>
                                <v-icon color="#364150" class="right">mdi-checkbox-blank-circle</v-icon>

                                <v-card-title primary-title color="#364150">
                                    <div class="title">Todo Service</div>
                                </v-card-title>
                                <v-layout>
                                    <v-spacer></v-spacer>
                                    <v-flex xs5 centered>
                                        <v-img src="https://image.flaticon.com/icons/svg/1/1560.svg" height="50px" contain></v-img>
                                    </v-flex>
                                    <v-spacer></v-spacer>
                                </v-layout>
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
                                            <v-list-tile-content @click="sound = !sound">
                                                <v-list-tile-title>Postgres Database</v-list-tile-title>
                                            </v-list-tile-content>
                                            <v-icon color="green" class="right">mdi-checkbox-blank-circle</v-icon>
                                        </v-list-tile>

                                        <v-list-tile @click="">
                                            <v-list-tile-content @click="sound = !sound">
                                                <v-list-tile-title>RabbitMQ Message Bus</v-list-tile-title>
                                            </v-list-tile-content>
                                            <v-icon color="green" class="right">mdi-checkbox-blank-circle</v-icon>
                                        </v-list-tile>

                                    </v-list>
                                </v-slide-y-transition>
                            </v-card>
                        </v-flex>

                        <v-flex xs3>
                            <v-card>
                                <v-icon color="green" class="right">mdi-checkbox-blank-circle</v-icon>

                                <v-card-title primary-title>
                                    <div class="title">Cleaning Service</div>
                                    <!--<v-icon class="text-xs-right justify-right" justify-right>mdi-account</v-icon>-->
                                </v-card-title>
                                <v-layout>
                                    <v-spacer></v-spacer>
                                    <v-flex xs5 centered>
                                        <v-img src="https://cdn3.iconfinder.com/data/icons/cleaning-icons/512/Glass_Spray-512.png" height="50px" contain></v-img>
                                    </v-flex>
                                    <v-spacer></v-spacer>
                                </v-layout>
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
                                            <v-list-tile-content @click="sound = !sound">
                                                <v-list-tile-title>Postgres Database</v-list-tile-title>
                                            </v-list-tile-content>
                                            <v-icon color="green" class="right">mdi-checkbox-marked-circle</v-icon>
                                        </v-list-tile>

                                        <v-list-tile @click="">
                                            <v-list-tile-content @click="sound = !sound">
                                                <v-list-tile-title>RabbitMQ Message Bus</v-list-tile-title>
                                            </v-list-tile-content>
                                            <v-icon color="green" class="right">mdi-checkbox-marked-circle</v-icon>
                                        </v-list-tile>

                                    </v-list>
                                </v-slide-y-transition>
                            </v-card>
                        </v-flex>

                        <v-flex xs3>
                            <v-card>
                                <v-icon color="green" class="right">mdi-checkbox-blank-circle</v-icon>

                                <v-card-title primary-title>
                                    <div class="title">Cleaning Service</div>
                                    <!--<v-icon class="text-xs-right justify-right" justify-right>mdi-account</v-icon>-->
                                </v-card-title>
                                <v-layout>
                                    <v-spacer></v-spacer>
                                    <v-flex xs5 centered>
                                        <v-img src="https://cdn3.iconfinder.com/data/icons/cleaning-icons/512/Glass_Spray-512.png" height="50px" contain></v-img>
                                    </v-flex>
                                    <v-spacer></v-spacer>
                                </v-layout>
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
                                            <v-list-tile-content @click="sound = !sound">
                                                <v-list-tile-title>Postgres Database</v-list-tile-title>
                                            </v-list-tile-content>
                                            <v-icon color="green" class="right">mdi-checkbox-blank-circle</v-icon>
                                        </v-list-tile>

                                        <v-list-tile @click="">
                                            <v-list-tile-content @click="sound = !sound">
                                                <v-list-tile-title>RabbitMQ Message Bus</v-list-tile-title>
                                            </v-list-tile-content>
                                            <v-icon color="green" class="right">mdi-checkbox-blank-circle</v-icon>
                                        </v-list-tile>

                                    </v-list>
                                </v-slide-y-transition>
                            </v-card>
                        </v-flex>
                    </v-layout>
                </v-container>
            </v-card>

        </v-tab-item>
    </v-tabs-items>
</div>
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
.v-tabs__bar {
  //  border-radius: 10px;
}

.rounded-card {
    border-radius: 1px;

    i {
        margin-left: 20px;
    }
}
</style>
