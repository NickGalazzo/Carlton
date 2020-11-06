using System;
using System.Collections.Generic;
using System.Text;

namespace Carlton.Dashboard.Components.Test
{
    public static class TestComponentMarkupConstants
    {
        public static string ApartmentStatusListItem_Unchecked = @"<div class='to-do-list-item'>
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

        public static string ApartmentStatusListItem_Checked = @"<div class='to-do-list-item'>
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
    }
}
