using System;
using System.Collections.Generic;
using System.Text;

namespace Carlton.Dashboard.Components.Test
{
    public static class TestComponentMarkupConstants
    {
        public static string ToDoListItem_Unchecked = @"<div class='to-do-list-item'>
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

        public static string ToDoListItem_Checked = @"<div class='to-do-list-item'>
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

        public static string ApartmentStatusListItem_Complete = @"
            <div class='row apartment-status-list-item'>
                <div class='col-3 offset-2'>
                    <span class='apt-status-icon mdi mdi-24px mdi-delete'></span>
                </div>
                <div class='col-2'></div>
                <div class='col-3'>
                    <span class='status-value-complete mdi mdi-24px mdi-check-circle'></span>
                </div>
            </div>";

        public static string ApartmentStatusListItem_Incomplete = @"
            <div class='row apartment-status-list-item'>
                <div class='col-3 offset-2'>
                    <span class='apt-status-icon mdi mdi-24px mdi-delete'></span>
                </div>
                <div class='col-2'></div>
                <div class='col-3'>
                    <span class='status-value-incomplete mdi mdi-24px mdi-alert'></span>
                </div>
            </div>";

        public static string DinnerGuestsListItem_Home = @"
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

        public static string DinnerGuestsListItem_NotHome = @"
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
    }
}
