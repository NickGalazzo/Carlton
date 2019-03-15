import { configure, addDecorator } from '@storybook/vue';
import Vue from 'vue';
import Vuetify from 'vuetify';
import VueRouter from 'vue-router';

import "vuetify/dist/vuetify.css";
import '@mdi/font/css/materialdesignicons.css';

import { withInfo } from '@storybook/addon-info';

Vue.use(Vuetify);
Vue.use(VueRouter);

const req = require.context('../src/stories', true, /.stories.ts$/);
function loadStories() {
  req.keys().forEach(filename => req(filename));
}

configure(loadStories, module);
