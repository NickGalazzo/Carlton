<template>
<v-card class="dashboard-card">
    <v-card-title primary-title>
        <div class="title">Apartment Status</div>
    </v-card-title>
    <v-container fluid>
        <v-layout row>
            <v-flex xs4>
                <v-icon :color="neutralIconColor" class="right">mdi-delete</v-icon>
            </v-flex>
            <v-spacer></v-spacer>
            <v-flex xs4>
                <v-icon :color="true ? activeColor : 'grey'" class="right">mdi-checkbox-marked-circle</v-icon>
            </v-flex>
            <v-spacer></v-spacer>
        </v-layout>

        <v-layout row>
            <v-flex xs4>
                <v-icon :color="neutralIconColor" class="right">mdi-recycle</v-icon>
            </v-flex>
            <v-spacer></v-spacer>
            <v-flex xs4>
                <v-icon :color="true ? activeColor : 'grey'" class="right">mdi-checkbox-marked-circle</v-icon>
            </v-flex>
            <v-spacer></v-spacer>
        </v-layout>

        <v-layout row>
            <v-flex xs4>
                <v-icon :color="neutralIconColor" class="right">mdi-cart</v-icon>
            </v-flex>
            <v-spacer></v-spacer>
            <v-flex xs4>
                <v-icon :color="true ? activeColor : 'grey'" class="right">mdi-checkbox-marked-circle</v-icon>
            </v-flex>
            <v-spacer></v-spacer>
        </v-layout>

        <v-layout row>
            <v-flex xs4>
                <v-icon :color="neutralIconColor" class="right">mdi-home</v-icon>
            </v-flex>
            <v-spacer></v-spacer>
            <v-flex xs4>
                <v-icon :color="true ? activeColor : 'grey'" class="right">mdi-checkbox-marked-circle</v-icon>
            </v-flex>
            <v-spacer></v-spacer>
        </v-layout>

        <v-layout row>
            <v-flex xs4>
                <v-icon :color="neutralIconColor" class="right">mdi-spray-bottle</v-icon>
            </v-flex>
            <v-spacer></v-spacer>
            <v-flex xs4>
                <v-icon :color="true ? activeColor : 'grey'" class="right">mdi-checkbox-marked-circle</v-icon>
            </v-flex>
            <v-spacer></v-spacer>
        </v-layout>

        <v-layout row>
            <v-flex xs4>
                <v-icon :color="neutralIconColor" class="right">mdi-washing-machine</v-icon>
            </v-flex>
            <v-spacer></v-spacer>
            <v-flex xs4>
                <v-icon :color="true ? activeColor : 'grey'" class="right">mdi-checkbox-marked-circle</v-icon>
            </v-flex>
            <v-spacer></v-spacer>
        </v-layout>
        <v-layout row>
            <v-flex xs4>
                <v-icon :color="neutralIconColor" class="right">mdi-tie</v-icon>
            </v-flex>
            <v-spacer></v-spacer>

            <v-flex xs4>
                <v-icon :color="true ? activeColor : 'grey'" class="right">mdi-checkbox-marked-circle</v-icon>
            </v-flex>
            <v-spacer></v-spacer>

        </v-layout>
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

// The @Component decorator indicates the class is a Vue component
@Component()
export default class ApartmentStatus extends Vue {
    //Data
    activeColor = "";
    neutralIconColor = "";

    mounted() {
        this.activeColor = colors.selected;
        this.neutralIconColor = colors.neutralIcon;
    }
}
</script>

<style lang="scss">
@import "../styles/master.scss";

.dashboard-card {
    .layout {
        margin: 12px;
    }
}
</style>
