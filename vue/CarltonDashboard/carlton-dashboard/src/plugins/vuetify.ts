import Vue from 'vue';
import Vuetify, {VList} from 'vuetify/lib';
import {Ripple} from 'vuetify/lib/directives';
import 'vuetify/src/stylus/app.styl';


Vue.use(Vuetify, {
  iconfont: 'md',
  components: {
    VList
  },
  directives : {
  Ripple,
}
});

