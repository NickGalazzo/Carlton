<template>
   <v-app>
    <!--<core-filter />-->

    <core-toolbar />

    <core-drawer />

    <!--<core-view />-->
  </v-app>
</template>

<script>
import CoreFilter from './components/core/Filter.vue';
import CoreToolbar from './components/core/Toolbar.vue';
import CoreDrawer from './components/core/Drawer.vue';
import CoreView from './components/core/View.vue';

export default {
  name: 'App',
  components: {
    CoreFilter,
    CoreToolbar,
    CoreDrawer,
    CoreView
  },
  data () {
    return {
      //
    }
  }
}
</script>
