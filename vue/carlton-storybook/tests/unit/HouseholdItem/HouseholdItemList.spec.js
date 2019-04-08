import { mount, createLocalVue } from "@vue/test-utils";
import VueRouter from "vue-router";
import Vuetify from "vuetify";
import HouseHoldItem from "../../../src/components/HouseholdItems/HouseholdItem.vue";
import HouseHoldItemList from "../../../src/components/HouseholdItems/HouseHoldItemList.vue";
import { SilenceWarnHack } from "../../SilenceWarnHack";
import data from "./TestData.json";

let wrapper;
const silenceWarnHack = new SilenceWarnHack();

beforeEach(() => {
  silenceWarnHack.enable();
 
  const localVue = createLocalVue();
  localVue.use(Vuetify);
  localVue.use(VueRouter);
  wrapper = mount(HouseHoldItemList, {
    localVue,
    propsData: {
      items: data.items
    }
  });

  silenceWarnHack.disable();
});

describe("Render Tests", () => {
  it("Given a HouseHoldItemList component Then it should be a valid Vue component", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });  

  it("Given a HouseHoldItemList component When 8 items are passed in Then should result in 8 HouseHoldItem child components rendered ", () => {    
    expect(wrapper.findAll(HouseHoldItem).length).toBe(8);
  });  
});