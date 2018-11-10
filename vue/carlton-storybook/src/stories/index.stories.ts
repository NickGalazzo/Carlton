/* eslint-disable react/react-in-jsx-scope, react/no-this-in-sfc */

import { storiesOf } from '@storybook/vue';
import { action } from '@storybook/addon-actions';

//import MyButton from '../components/Button.vue';
//import Welcome from '../components/Welcome.vue';
import Toolbar from '../components/Toolbar.vue';

/*
storiesOf('Welcome', module).add('to Storybook', () => ({
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
  */
  

  storiesOf('Toolbar', module)
  .add('story as a template', () => '<core-toolbar />')
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
