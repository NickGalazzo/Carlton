import Vuex from 'vuex';
import ApartmentStatusService from '../../api/apartmentStatusService';
import {
    SET_APARTMENT_STATUSES, 
    TAKEOUT_GARBAGE,
    TAKEOUT_RECYLCE, 
    SET_GARBAGE_DAY,
    SET_RECYCLE_DAY, 
    CLEANED_APARTMENT, 
    CLEANED_PERIOD_ELAPSED, 
    DROPPED_OFF_LAUNDRY,
    PICKED_UP_LAUNDRY, 
    DROPPED_OFF_DRY_CLEANING, 
    PICKED_UP_DRY_CLEANING } from '../mutationsTypes';

const apartmentStatusModule = {
    state: {
        garbage: 
            {
                name: "garbage",
                icon: "mdi-delete",
                statusId: 1
            },
        recyle: 
            {
                name: "recycle",
                icon: "mdi-recycle",
                statusId: 1
            },
        householdItems: 
            {
                name: "householdItems",
                icon: "mdi-cart",
                statusId: 1
            },
         clean: 
            {
                name: "Clean",
                icon: "mdi-spray-bottle",
                statusId: 1
            },
         laundry: 
            {
                name: "laundry",
                icon: "mdi-washing-machine",
                statusId: 1
            },
         dryCleaning: 
            {
                name: "dryCleaning",
                icon: "mdi-tie",
                statusId: 1
            }
        },
    actions: {
        async loadApartmentStatuses (context, payload) {
            let statuses = await ApartmentStatusService.getStatuses();
            context.commit('SET_APARTMENT_STATUSES', statuses);
        }
    }, 
    mutations: {
        [SET_APARTMENT_STATUSES] (state, statuses){
            state = statuses;
        },
        [TAKEOUT_GARBAGE] (state){
            state.garbage.statusId = 1;
        },
        [TAKEOUT_RECYLCE] (state){
            state.recycle.statusId = 1;
        },
        [SET_GARBAGE_DAY](state){
            state.garbage.statusId  = 2;
        },
        [SET_RECYCLE_DAY](state) {
            state.garbage.statusId  = 2;
        },
        [CLEANED_APARTMENT](state){
            state.clean.statusId  = 1;
        },
        [CLEANED_PERIOD_ELAPSED](state){
            state.clean.statusId  = 2;
        },
        [DROPPED_OFF_LAUNDRY](state) {
            state.laundry.statusId  = 2
        },
        [PICKED_UP_LAUNDRY](state) {
            state.laundry.statusId  = 1
        },
        [DROPPED_OFF_DRY_CLEANING](state){
            state.dryCleaning.statusId  = 2
        },
        [PICKED_UP_DRY_CLEANING](state){
            state.dryCleaning.statusId  = 1
        }
    },
};

export const mutations = apartmentStatusModule.mutations;
export default apartmentStatusModule;

