import { configure } from '@storybook/vue';
import Vue from 'vue';
import Vuetify from 'vuetify'; 
import CoreToolbar from '../src/components/Toolbar.vue';

Vue.use(Vuetify);

Vue.component('core-toolbar', CoreToolbar);

// automatically import all files ending in *.stories.js
const req = require.context('../src/stories', true, /.stories.ts$/);
function loadStories() {
  req.keys().forEach(filename => req(filename));
}

configure(loadStories, module);
