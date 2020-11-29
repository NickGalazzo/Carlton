namespace Carlton.Dashboard.Components.Test
{
    public static class TestComponentMarkupConstants
    {
        public const string ToDoListItem_Unchecked = @"<div class='to-do-list-item'>
            <div class='row'>
                <div class='col-1'>
                    <div class='carlton-checkbox'>
                        <span class='align-middle mdi mdi-24px mdi-checkbox-blank-circle-outline'></span>
                    </div>
                </div>
                <span class='col-10'>
                    <span class='to-do-name align-middle'>Take Out Garbage</span>
                </span>
            </div>
        </div>";

        public const string ToDoListItem_Checked = @"<div class='to-do-list-item'>
            <div class='row'>
                <div class='col-1'>
                    <div class='carlton-checkbox'>
               <span class='align-middle mdi mdi-24px mdi-check-circle'></span>
            </div>
                </div>
                <span class='col-10'>
                    <span class='to-do-name align-middle completed'>Take Out Garbage</span>
                </span>
            </div>
        </div>";

        public const string ApartmentStatusListItem_Complete = @"
            <div class='row apartment-status-list-item'>
                <div class='col-3 offset-2'>
                    <span class='apt-status-icon mdi mdi-24px mdi-delete'></span>
                </div>
                <div class='col-2'></div>
                <div class='col-3'>
                    <span class='status-value-complete mdi mdi-24px mdi-check-circle'></span>
                </div>
            </div>";

        public const string ApartmentStatusListItem_Incomplete = @"
            <div class='row apartment-status-list-item'>
                <div class='col-3 offset-2'>
                    <span class='apt-status-icon mdi mdi-24px mdi-delete'></span>
                </div>
                <div class='col-2'></div>
                <div class='col-3'>
                    <span class='status-value-incomplete mdi mdi-24px mdi-alert'></span>
                </div>
            </div>";

        public const string DinnerGuestsListItem_Home = @"
            <div class='row dinner-guests-list-item'>
                <div class='col-3 text-center'>
                    <img class='avatar-img text-center' src='https://www.w3schools.com/w3images/avatar2.png'>
                </div>
                <div class='col-6 text-center'>
                    <div class='guest-name'>Nick</div>
                </div>
                <div class='col-3 text-center'>
                   <span class='mdi mdi-24px mdi-food is-home-for-dinner'></span>
                </div>
            </div>";

        public const string DinnerGuestsListItem_NotHome = @"
            <div class='row dinner-guests-list-item'>
                <div class='col-3 text-center'>
                    <img class='avatar-img text-center' src='https://www.w3schools.com/w3images/avatar2.png'>
                </div>
                <div class='col-6 text-center'>
                    <div class='guest-name'>Steve</div>
                        <div class='guest-message'>Japan School</div>
                </div>
                <div class='col-3 text-center'>
                        <span class='mdi mdi-24px mdi-food '></span>
                </div>
            </div>";

        public const string DinnerGuestsListItem_SelfStatus_NotHome = @" <div class='row dinner-guests-list-item'>
                <div class='col-3 text-center'>
                    <img class='avatar-img text-center' src='https://www.w3schools.com/w3images/avatar2.png'>
                </div>
                <div class='col-6 text-center'>
                    <div class='guest-name'>Steve</div>
                        <div class='guest-message'>Japan School</div>
                </div>
                <div class='col-3 text-center'>
                </div>
            </div>";

        public const string GroceriesListItem_Low = @"<div class='groceries-list-item'>
                <div>
                    <span class='item-name'>Toilet Paper</span>
                </div>
                <div class='progress'>
                    <div class='progress-bar low' role='progressbar' style='width: 25%' aria-valuenow='25' aria-valuemin='0' aria-valuemax='100'></div>
                </div>
            </div>";

        public const string GroceriesListItem_Medium = @"<div class='groceries-list-item'>
            <div>
                <span class='item-name'>Paper Towels</span>
            </div>
            <div class='progress'>
                <div class='progress-bar medium' role='progressbar' style='width: 57%' aria-valuenow='57' aria-valuemin='0' aria-valuemax='100'></div>
            </div>
        </div>";

        public const string GroceriesListItem_High = @"<div class='groceries-list-item'>
            <div>
                <span class='item-name'>Dish Soap</span>
            </div>
            <div class='progress'>
                <div class='progress-bar high' role='progressbar' style='width: 92%' aria-valuenow='92' aria-valuemin='0' aria-valuemax='100'></div>
            </div>
        </div>";

        public const string FeedListItem = @"<div class='feed-list-item'>
            <div class='row'>
                <!--!--><div class='col-2'>
                    <img class='avatar-img' src='https://www.w3schools.com/w3images/avatar2.png'>
                </div>
                <div class='col-8 offset-2'>
                    <div class='feed-title'>Nick</div>
                    <div class='feed-message'>Took Out Garbage</div>
                </div>
            </div>
            <div class='row feed-date-col feed-item-row'>
                <div class='col-8 offset-4'>
                    <span class='feed-date'>moments ago</span>
                </div>
            </div>
        </div>";

        public const string ApartmentStatusCount = @"<div class='apartment-status-count-card '>
           <div class='dashboard-count-card accent-color-2'>
              <div class='carlton-card'>
                 <div class='container'>
                    <div class='card'>
                       <div class='card-body'>
                          <div class='row status-row'>
                             <h5 class='col-9 card-title'></h5>
                             <div class='col-3 status-icon'>
                             </div>
                          </div>
                          <div class='header-content'>
                          </div>
                          <div class='primary-content'>
                             <div class='row'>
                                <div class='col-3 offset-1 count-icon mdi mdi-36px accent-color-2 mdi-home'></div>
                                <span class='col-6 offset-1 count-message'>7 Pending Statuses</span>
                             </div>
                          </div>
                       </div>
                    </div>
                 </div>
              </div>
           </div>
        </div>";

        public const string ToDoCount = @"<div class='to-dos-count-card '>
           <div class='dashboard-count-card accent-color-1'>
              <div class='carlton-card'>
                 <div class='container'>
                    <div class='card'>
                       <div class='card-body'>
                          <div class='row status-row'>
                             <h5 class='col-9 card-title'></h5>
                             <div class='col-3 status-icon'>
                             </div>
                          </div>
                          <div class='header-content'>
                          </div>
                          <div class='primary-content'>
                             <div class='row'>
                                <div class='col-3 offset-1 count-icon mdi mdi-36px accent-color-1 mdi-clipboard-check'></div>
                                <span class='col-6 offset-1 count-message'>7 Open Tasks</span>
                             </div>
                          </div>
                       </div>
                    </div>
                 </div>
              </div>
           </div>
        </div>";

        public const string DinnerGuestsCount = @"
        <div class='dinner-guests-count-card'>
            <div class='dashboard-count-card accent-color-4'>
               <div class='carlton-card'>
                  <div class='container'>
                     <div class='card'>
                        <div class='card-body'>
                           <div class='row status-row'>
                              <h5 class='col-9 card-title'></h5>
                              <div class='col-3 status-icon'>
                              </div>
                           </div>
                           <div class='header-content'>
                           </div>
                           <div class='primary-content'>
                              <div class='row'>
                                 <div class='col-3 offset-1 count-icon mdi mdi-36px accent-color-4 mdi-silverware-fork-knife'></div>
                                 <span class='col-6 offset-1 count-message'>7 Guests for Dinner</span>
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
            </div>";

        public const string GroceriesCount = @"<div class='groceries-count-card '>
           <div class='dashboard-count-card accent-color-3'>
              <div class='carlton-card'>
                 <div class='container'>
                    <div class='card'>
                       <div class='card-body'>
                          <div class='row status-row'>
                             <h5 class='col-9 card-title'></h5>
                             <div class='col-3 status-icon'>
                             </div>
                          </div>
                          <div class='header-content'>
                          </div>
                          <div class='primary-content'>
                             <div class='row'>
                                <div class='col-3 offset-1 count-icon mdi mdi-36px accent-color-3 mdi-cart'></div>
                                <span class='col-6 offset-1 count-message'>7 Low Items</span>
                             </div>
                          </div>
                       </div>
                    </div>
                 </div>
              </div>
           </div>
        </div>";
    }
}

