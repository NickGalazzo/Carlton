using Bunit;
using Carlton.Dashboard.Components.ApartmentStatus;
using Carlton.Dashboard.ViewModels.ApartmentStatus;
using Carlton.Dashboard.ViewModels.CountCards;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Carlton.Dashboard.Components.Test
{
    public class ApartmentStatusTests : TestContext
    {
        [Fact]
        [Trait("ApartmentStatus", "Snapshot")]
        public void ApartmentStatus_Complete_Markup()
        {
            // Act
            var cut = RenderComponent<ApartmentStatusListItem>(
                ("ViewModel", new ApartmentGarbageStatusListItemViewModel(ApartmentStatuses.Complete))
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.ApartmentStatusListItem_Complete);
        }

        [Fact]
        [Trait("ApartmentStatus", "Snapshot")]
        public void ApartmentStatus_Incomplete_Markup()
        {
            // Act
            var cut = RenderComponent<ApartmentStatusListItem>(
                ("ViewModel", new ApartmentGarbageStatusListItemViewModel(ApartmentStatuses.Incomplete))
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.ApartmentStatusListItem_Incomplete);
        }

        [Fact]
        [Trait("ApartmentStatus", "Snapshot")]
        public void ApartmentStatusListCard_Markup()
        {
            // Act
            var cut = RenderComponent<ApartmentStatusListCard>(
                ("ViewModel",
                    new ApartmentStatusListViewModel(new List<ApartmentStatusListItemViewModel>
                    {
                        new ApartmentGarbageStatusListItemViewModel(ApartmentStatuses.Incomplete),
                        new ApartmentRecycleStatusListItemViewModel(ApartmentStatuses.Incomplete),
                        new ApartmentLaundryStatusListItemViewModel(ApartmentStatuses.Complete)
                    })
                 ));

            var items = cut.FindAll(".apartment-status-list-item");


            // Assert
            Assert.Equal(3, items.Count);
        }

        [Fact]
        [Trait("ApartmentStatus", "Snapshot")]
        public void ApartmentStatusListCard_ApartmentStatusListItem_Markup()
        {
            // Act
            var cut = RenderComponent<ApartmentStatusListCard>(
                ("ViewModel",
                    new ApartmentStatusListViewModel(new List<ApartmentStatusListItemViewModel>
                    {
                        new ApartmentGarbageStatusListItemViewModel(ApartmentStatuses.Incomplete),
                        new ApartmentRecycleStatusListItemViewModel(ApartmentStatuses.Incomplete),
                        new ApartmentLaundryStatusListItemViewModel(ApartmentStatuses.Complete)
                    })
                 ));

            var item = cut.FindAll(".apartment-status-list-item")[0];


            // Assert
            item.MarkupMatches(TestComponentMarkupConstants.ApartmentStatusListItem_Incomplete);
        }
    }
}
