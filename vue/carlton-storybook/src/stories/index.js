import Vue from 'vue';

import { storiesOf } from '@storybook/vue';

//import MyButton from './Button.vue';
import Toolbar from '../components/Toolbar.vue';

//storiesOf('MyButton', module)

   
  storiesOf('Toolbar', module)
  .add('story as a template', () => '<core-toolbar></core-toolbar>')
