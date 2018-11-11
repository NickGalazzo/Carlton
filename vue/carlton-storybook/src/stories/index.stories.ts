/* eslint-disable react/react-in-jsx-scope, react/no-this-in-sfc */

import { storiesOf } from '@storybook/vue';
import { action } from '@storybook/addon-actions';

import MyButton from '../components/Button.vue';
import Welcome from '../components/Welcome.vue';
import Toolbar from '../components/Toolbar.vue';
import Drawer from '../components/Drawer.vue';
import HealthCard from '../components/HealthCard.vue';


storiesOf('Welcome', module)

  .add('to Storybook', () => ({
    components: { Welcome },
    template: '<welcome :showApp="action" />',
  }));

storiesOf('Button', module)
  .add('with text', () => ({
    components: { MyButton },
    template: '<my-button @click="action">Hello Button</my-button>',
    methods: { action: action('clicked') },
  }))
  .add('with some emoji', () => ({
    components: { MyButton },
    template: '<my-button @click="action">😀 😎 👍 💯</my-button>',
    methods: { action: action('clicked') },
  }));


storiesOf('Nav Drawer', module)
  .add('Default', () => ({
    components: {Drawer},
    template: '<drawer/>'
  }));

  storiesOf('Health Card', module)
  .add('Default', () =>({
    components: {HealthCard},
    template: '<health-card/>'
  }));


  /*
storiesOf('Toolbar', module)
  //.addParameters({
  // info: {
  // Your settings
  //},
  //  })
  .add('story as a template', () => '<toolbar />')
*/
















