import Vuex from 'vuex';
import apartmentStatusModule from './modules/apartmentStatus';

    
const store = new Vuex.Store({
   modules: {
        apartmentStatus: apartmentStatusModule
   }
});

export default store;