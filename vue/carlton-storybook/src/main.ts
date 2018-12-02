import { configure, addDecorator } from '@storybook/vue';
import Vue from 'vue';
import Vuetify from 'vuetify';

import "vuetify/dist/vuetify.css";
import '@mdi/font/css/materialdesignicons.css';

import { withInfo } from '@storybook/addon-info';

Vue.use(Vuetify);

// automatically import all files ending in *.stories.js 
const req = require.context('../src/stories', true, /.stories.ts$/);
function loadStories() {
  req.keys().forEach(filename => req(filename));
}

configure(loadStories, module);