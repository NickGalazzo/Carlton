<template>
  <v-content>
    <div id="core-view">
      <v-fade-transition mode="out-in">
        <router-view />
      </v-fade-transition>
    </div>
    <core-footer v-if="$route.name !== 'Maps'" />
  </v-content>
</template>

<script script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component';

// The @Component decorator indicates the class is a Vue component
@Component({
  // All component options are allowed in here
})
export default class CoreView extends Vue {
  // Initial data can be declared as instance properties
  message: string = 'Hello!'

  // Component methods can be declared as instance methods
  onClick (): void {
    window.alert(this.message)
  }
}

</script>

<style>
#core-view {
  padding-bottom: 100px;
}
</style>
