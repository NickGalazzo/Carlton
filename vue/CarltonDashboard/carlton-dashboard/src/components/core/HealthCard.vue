<template>
  <template>
  <v-tabs fixed-tabs>
    <v-tab
      v-for="(enviornment, i) in enviornments"
      :key="i"
    >
     {{ enviornment }}
    </v-tab>
  </v-tabs>
</template>
</template>

<script script lang="ts">
import Vue from "vue";
import Vue, { PropOptions } from "vue";
import Component from "vue-class-component";

type Link = {
  to: String;
  icon: String;
  text: String;
};

// The @Component decorator indicates the class is a Vue component
@Component({
  props: {
    logo: String
  }
})
export default class CoreDrawer extends Vue {
  //Data
  links: Link[];

  message: string = "Hello!";
  logo: "./img/vuetifylogo.png";

  mounted() {
    this.enviornments = ["Dev", "QA", "Production" ];
  }
}
</script>


<style lang="scss">


</style>
