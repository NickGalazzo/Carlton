import Vue from 'vue';
import Router from 'vue-router';
import DashboardView from './views/Dashboard.vue';
import UserProfile from '.views/UserProfile.vue';
import TableList from '.views/TableList.vue';
import Typography from '.views/Typography.vue';
import Icons from '.views/Icons.vue';
import Maps from '.views/Maps.vue';
import Notifications from '.views/Notifications.vue';


Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
   {
    path: '/dashboard',
    component: DashboardView,
  },
 /* {
    path: '/user-profile',
    name: 'User Profile',
    component: UserProfile,
  },
   {
    path: '/table-list',
    name: 'Table List',
    component: TableList,
  },
  {
    path: '/typography',
    component: Typography,
  },
 {
    path: '/icons',
    component: Icons
  },
  {
    path: '/maps',
    component: Maps,
  },
  {
    path: '/notifications',
    component: Notifications,
  },*/
  ],
});

