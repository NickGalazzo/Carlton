import Vue from 'vue';

import { storiesOf } from '@storybook/vue';

import MyButton from './Button.vue';
//import Toolbar from '../components/Toolbar.vue';

storiesOf('MyButton', module)
  .add('story as a template', () => '<my-button :rounded="true">story as a function template</my-button>')
  .add('story as a component', () => ({
    components: { MyButton },
    template: '<my-button :rounded="true">rounded</my-button>'
  }));
  
  //storiesOf('Toolbar', module)
  //.add('story as a template', () => '<core-toolbar>story as a function template</core-toolbar>')
