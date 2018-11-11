<template>
<div>
    <v-toolbar tabs color="green">
        <v-toolbar-title class="white--text">Application Health</v-toolbar-title>

        <v-tabs slot="extension" color="green" v-model="model" centered>
            <v-tab color="white" v-for="(environment, i) in environments" :key="i" :href="`#tab-${i}`" class="white--text">
                {{ environment }}
            </v-tab>
        </v-tabs>
    </v-toolbar>

    <v-tabs-items v-model="model">
        <v-tab-item v-for="(environment, i) in environments" :id="`tab-${i}`" :key="i">
            <v-card>
                <v-container fluid grid-list-lg>
                    <v-layout row wrap>
                        <v-flex xs3>
                            <v-card>
                                <v-icon color="green" class="right">mdi-checkbox-blank-circle</v-icon>

                                <v-card-title primary-title>
                                    <div class="title">Identity Service</div>
                                </v-card-title>
                                <v-layout>
                                    <v-spacer></v-spacer>
                                    <v-flex xs5>
                                        <v-img src="https://cdn3.iconfinder.com/data/icons/business-office-1-2/256/Identity_Document-512.png" height="80px" contain></v-img>
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
                                    <div class="title">Garbage Service</div>
                                    <!--<v-icon class="text-xs-right justify-right" justify-right>mdi-account</v-icon>-->
                                </v-card-title>
                                <v-layout>
                                    <v-spacer></v-spacer>
                                    <v-flex xs5 centered>
                                        <v-img src="data:image/png;base64,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" height="80px" contain></v-img>
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
                                    <div class="title">Todo Service</div>
                                </v-card-title>
                                <v-layout>
                                    <v-spacer></v-spacer>
                                    <v-flex xs5 centered>
                                        <v-img src="https://image.flaticon.com/icons/svg/1/1560.svg" height="80px" contain></v-img>
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
                                        <v-img src="https://cdn3.iconfinder.com/data/icons/cleaning-icons/512/Glass_Spray-512.png" height="80px" contain></v-img>
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
                                        <v-img src="https://cdn3.iconfinder.com/data/icons/cleaning-icons/512/Glass_Spray-512.png" height="80px" contain></v-img>
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

</style>
