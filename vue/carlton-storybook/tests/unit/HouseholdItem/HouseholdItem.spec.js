import { mount, createLocalVue } from "@vue/test-utils";
import VueRouter from "vue-router";
import Vuetify from "vuetify";
import HouseHoldItem from "../../../src/components/HouseholdItems/HouseholdItem.vue";
import { SilenceWarnHack } from "../../SilenceWarnHack";
import data from "./TestData.json";

let wrapper;
const silenceWarnHack = new SilenceWarnHack();

beforeEach(() => {
  silenceWarnHack.enable();
 
  const localVue = createLocalVue();
  localVue.use(Vuetify);
  localVue.use(VueRouter);
  wrapper = mount(HouseHoldItem, {
    localVue,
    propsData: {
      item: data.items[0]
    }
  });

  silenceWarnHack.disable();
});

describe("Render Tests", () => {
  it("Given a HouseHoldItem component Then it should be a valid Vue component", () => {
    expect(wrapper.isVueInstance()).toBeTruthy();
  });  

  it("Given a HouseHoldItem component When percentage is less than 50 Then low item bar should be visible", () => {
    //Arrange
    wrapper.setProps({item: {
        name: "Swiffer",
        percentRemaining: 45
      }});
    
    expect(wrapper.find(".low-item").exists()).toBe(true);
    expect(wrapper.find(".medium-item").exists()).toBe(false);
    expect(wrapper.find(".high-item").exists()).toBe(false);
  });  

  it("Given a HouseHoldItem component When percentage is less than 75 And greater than 50 Then medium item bar should be visible", () => {
    //Arrange
    wrapper.setProps({item: {
        name: "Swiffer",
        percentRemaining: 60
      }});
    
    expect(wrapper.find(".low-item").exists()).toBe(false);
    expect(wrapper.find(".medium-item").exists()).toBe(true);
    expect(wrapper.find(".high-item").exists()).toBe(false);
  });  

  it("Given a HouseHoldItem component When percentage is greater than 75 Then high item bar should be visible", () => {
    //Arrange
    wrapper.setProps({item: {
        name: "Swiffer",
        percentRemaining: 80
      }});
    
    expect(wrapper.find(".low-item").exists()).toBe(false);
    expect(wrapper.find(".medium-item").exists()).toBe(false);
    expect(wrapper.find(".high-item").exists()).toBe(true);
  });  
});

describe("Interaction Tests", () => {
  it("Given a HouseHoldItem component When the view button is clicked Then navigateToHouseholdItem even should be emitted", () => {
    //Arrange
    let button = wrapper.find('button');

    //Act
    button.trigger('click');
    
    //Assert
    expect(wrapper.emitted('navigateToHouseholdItem').length).toBe(1);
  });  
});

