import Api from './api';

export default {
    getStatuses(){
        return Api().get('/apartmentStatuses');
    }
}