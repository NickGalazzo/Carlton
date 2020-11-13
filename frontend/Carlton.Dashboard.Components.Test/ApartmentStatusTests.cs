using Bunit;
using Carlton.Dashboard.Components.ApartmentStatus;
using Carlton.TestBed.Client.TestViewModels;
using Xunit;

namespace Carlton.Dashboard.Components.Test
{
    public class ApartmentStatusTests : TestContext
    {
        [Fact]
        [Trait("ApartmentStatus", "Snapshot")]
        public void ApartmentStatus_Complete_Markup()
        {
            //Act
            var cut = RenderComponent<ApartmentStatusListItem>(
                ("ViewModel", ApartmentStatusTestViewModels.CompletedStatusViewModel())
            );

            //Assert
            cut.MarkupMatches(TestComponentMarkupConstants.ApartmentStatusListItem_Complete);
        }

        [Fact]
        [Trait("ApartmentStatus", "Snapshot")]
        public void ApartmentStatus_Incomplete_Markup()
        {
            // Act
            var cut = RenderComponent<ApartmentStatusListItem>(
                ("ViewModel", ApartmentStatusTestViewModels.InCompleteStatusViewModel())
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.ApartmentStatusListItem_Incomplete);
        }

        [Fact]
        [Trait("ApartmentStatus", "Unit")]
        public void ApartmentStatusListCard_Child_Count_Verify()
        {
            // Act
            var cut = RenderComponent<ApartmentStatusListCard>(
                ("ViewModel", ApartmentStatusTestViewModels.DefaultApartmentStatusViewModel()));

            var items = cut.FindComponents<ApartmentStatusListItem>();

            // Assert
            Assert.Equal(6, items.Count);
        }

        [Fact]
        [Trait("ApartmentStatus", "Snapshot")]
        public void ApartmentStatusListCard_ApartmentStatusListItem_Markup()
        {
            // Act
            var cut = RenderComponent<ApartmentStatusListCard>(
                ("ViewModel", ApartmentStatusTestViewModels.DefaultApartmentStatusViewModel()));

            var item = cut.FindComponent<ApartmentStatusListItem>();

            // Assert
            item.MarkupMatches(TestComponentMarkupConstants.ApartmentStatusListItem_Complete);
        }

        //ToDO Add More Tests for Icon
    }
}
