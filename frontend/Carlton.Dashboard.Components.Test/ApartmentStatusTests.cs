using Xunit;
using Bunit;
using Carlton.Dashboard.ViewModels.TestViewModels;

namespace Carlton.Dashboard.Components.Test
{
    public class ApartmentStatusTests : TestContext
    {
        [Fact]
        [Trait("ApartmentStatusItem", "Snapshot")]
        public void ApartmentStatus_Complete_Markup()
        {
            // Arrange
            var cut = RenderComponent<ApartmentStatusListItem>(
                ("ViewModel", ApartmentStatusTestViewModels.CompletedStatusViewModel())
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.ApartmentStatusListItem_Complete);
        }

        [Fact]
        [Trait("ApartmentStatusItem", "Snapshot")]
        public void ApartmentStatus_Incomplete_Markup()
        {
            // Arrange
            var cut = RenderComponent<ApartmentStatusListItem>(
                ("ViewModel", ApartmentStatusTestViewModels.InCompleteStatusViewModel())
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.ApartmentStatusListItem_Incomplete);
        }

        [Fact]
        [Trait("ApartmentStatusItem", "Unit")]
        public void ApartmentStatus_Complete_Checked_Icon_Verify()
        {
            // Arrange
            var cut = RenderComponent<ApartmentStatusListItem>(
                ("ViewModel", ApartmentStatusTestViewModels.CompletedStatusViewModel())
            );

            // Act
            var checkedSpan = cut.Find(".status-value-complete.mdi-check-circle");

            //Assert
            Assert.NotNull(checkedSpan);
        }

        [Fact]
        [Trait("ApartmentStatusItem", "Unit")]
        public void ApartmentStatus_Complete_Unchecked_Icon_Verify()
        {
            // Arrange
            var cut = RenderComponent<ApartmentStatusListItem>(
                ("ViewModel", ApartmentStatusTestViewModels.InCompleteStatusViewModel())
            );

            // Act
            var uncheckedSpan = cut.Find(".status-value-incomplete.mdi-alert");

            // Assert
            Assert.NotNull(uncheckedSpan);
        }

        [Fact]
        [Trait("ApartmentStatusItem", "Unit")]
        public void ApartmentStatus_Garbage_Icon_Verify()
        {
            // Arrange
            var cut = RenderComponent<ApartmentStatusListItem>(
                ("ViewModel", ApartmentStatusTestViewModels.GarbageViewModel())
            );

            // Act
            var iconSpan = cut.Find("span.mdi-delete");

            //Assert
            Assert.NotNull(iconSpan);
        }

        [Fact]
        [Trait("ApartmentStatusItem", "Unit")]
        public void ApartmentStatus_Recycle_Icon_Verify()
        {
            // Arrange
            var cut = RenderComponent<ApartmentStatusListItem>(
                ("ViewModel", ApartmentStatusTestViewModels.RecycleViewModel())
            );

            // Act
            var iconSpan = cut.Find("span.mdi-recycle");

            //Assert
            Assert.NotNull(iconSpan);
        }

        [Fact]
        [Trait("ApartmentStatusItem", "Unit")]
        public void ApartmentStatus_Groceries_Icon_Verify()
        {
            // Arrange
            var cut = RenderComponent<ApartmentStatusListItem>(
                ("ViewModel", ApartmentStatusTestViewModels.GroceriesViewModel())
            );

            // Act
            var iconSpan = cut.Find("span.mdi-cart");

            // Assert
            Assert.NotNull(iconSpan);
        }

        [Fact]
        [Trait("ApartmentStatusItem", "Unit")]
        public void ApartmentStatus_Cleaning_Icon_Verify()
        {
            // Arrange
            var cut = RenderComponent<ApartmentStatusListItem>(
                ("ViewModel", ApartmentStatusTestViewModels.CleaningViewModel())
            );

            // Act
            var iconSpan = cut.Find("span.mdi-spray-bottle");

            // Assert
            Assert.NotNull(iconSpan);
        }

        [Fact]
        [Trait("ApartmentStatusItem", "Unit")]
        public void ApartmentStatus_Laundry_Icon_Verify()
        {
            // Arrange
            var cut = RenderComponent<ApartmentStatusListItem>(
                ("ViewModel", ApartmentStatusTestViewModels.LaundryViewModel())
            );

            // Act
            var iconSpan = cut.Find("span.mdi-washing-machine");

            // Assert
            Assert.NotNull(iconSpan);
        }

        [Fact]
        [Trait("ApartmentStatusItem", "Unit")]
        public void ApartmentStatus_DryCleaning_Icon_Verify()
        {
            // Arrange
            var cut = RenderComponent<ApartmentStatusListItem>(
                ("ViewModel", ApartmentStatusTestViewModels.DryCleaningViewModel())
            );

            // Act
            var iconSpan = cut.Find("span.mdi-tie");

            // Assert
            Assert.NotNull(iconSpan);
        }

        [Fact]
        [Trait("ApartmentStatusList", "Unit")]
        public void ApartmentStatusListCard_Child_Count_Verify()
        {
            // Arrange
            var cut = RenderComponent<ApartmentStatusListCard>(
                ("ViewModel", ApartmentStatusTestViewModels.DefaultApartmentStatusViewModel()));

            // Act
            var items = cut.FindComponents<ApartmentStatusListItem>();

            // Assert
            Assert.Equal(6, items.Count);
        }

        [Fact]
        [Trait("ApartmentStatusList", "Snapshot")]
        public void ApartmentStatusListCard_ApartmentStatusListItem_Markup()
        {
            // Arrange
            var cut = RenderComponent<ApartmentStatusListCard>(
                ("ViewModel", ApartmentStatusTestViewModels.DefaultApartmentStatusViewModel()));

            // Act
            var item = cut.FindComponent<ApartmentStatusListItem>();

            // Assert
            item.MarkupMatches(TestComponentMarkupConstants.ApartmentStatusListItem_Complete);
        }
    }
}
