using Xunit;
using Bunit;
using Carlton.Dashboard.ViewModels;
using Carlton.Dashboard.ViewModels.TestViewModels;

namespace Carlton.Dashboard.Components.Test
{
    public class DinnerGuestTests : TestContext
    {
        [Fact]
        [Trait("DinnerGuestsListItem", "Snapshot")]
        public void DinnerGuests_Home_Markup()
        {
            // Arrange
            var cut = RenderComponent<DinnerGuestsListItem>(
                ("ShowIndicator", true),
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestHomeViewModel())
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.DinnerGuestsListItem_Home);
        }

        [Fact]
        [Trait("DinnerGuestsListItem", "Snapshot")]
        public void DinnerGuests_NotHome_Markup()
        {
            // Arrange
            var cut = RenderComponent<DinnerGuestsListItem>(
                 ("ShowIndicator", true),
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestNotHomeViewModel())
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.DinnerGuestsListItem_NotHome);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuestsSelfStatus_Name_Verify()
        {
            // Arrange
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfHomeViewModel()));

            // Act
            var nameElement = cut.Find(".guest-name");

            // Assert
            Assert.Equal("Nick", nameElement.TextContent);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuestsSelfStatus_IsHome_Verify()
        {
            // Arrange
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfHomeViewModel()));

            // Act
            var nameElement = cut.Find("input[type='checkbox'].switch");

            // Assert
            Assert.True(nameElement.HasAttribute("checked"));
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuestsSelfStatus_IsHome_Reason_Disabled_Verify()
        {
            // Arrange
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfHomeViewModel()));

            // Act
            var reasonElement = cut.Find(".carlton-select .options");

            // Assert
            Assert.True(reasonElement.HasAttribute("disabled"));
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuestsSelfStatus_IsNotHome_Reason_NotDisabled_Verify()
        {
            // Arrange
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfNotHomeViewModel()));

            // Act
            var reasonElement = cut.Find(".carlton-select .options");

            // Assert
            Assert.False(reasonElement.HasAttribute("disabled"));
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuestsSelfStatus_IsHome_Reason_Empty_Verify()
        {
            // Arrange
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfHomeViewModel()));

            // Act
            var reasonElement = cut.FindAll(".guest-message");

            // Assert
            Assert.Empty(reasonElement);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuestsSelfStatus_IsNotHome_Reason_Japan_School_Verify()
        {
            // Arrange
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfNotHomeViewModel()));

            // Act
            var reasonElement = cut.Find(".guest-message");

            // Assert
            Assert.Equal("Japan School", reasonElement.TextContent);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "ComponentEvent")]
        public void DinnerGuestsSelfStatus_IsNotHome_StatusChangedEvent()
        {
            // Arrange
            var expected = new DinnerGuestsHomeForDinnerStatusChangeEvent(2, true);
            DinnerGuestsHomeForDinnerStatusChangeEvent result = null;
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfNotHomeViewModel()),
                 ComponentParameterFactory.EventCallback("OnComponentEvent", (evt) => result = (DinnerGuestsHomeForDinnerStatusChangeEvent) evt));
            
            // Act
            cut.Find("input.switch").Click();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "ComponentEvent")]
        public void DinnerGuestsSelfStatus_IsHome_StatusChangedEvent()
        {
            // Arrange
            var expected = new DinnerGuestsHomeForDinnerStatusChangeEvent(1, false);
            DinnerGuestsHomeForDinnerStatusChangeEvent result = null;
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfHomeViewModel()),
                 ComponentParameterFactory.EventCallback("OnComponentEvent", (evt) => result = (DinnerGuestsHomeForDinnerStatusChangeEvent)evt));
            
            // Act
            cut.Find("input.switch").Click();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "ComponentEvent")]
        public void DinnerGuestsSelfStatus_NotHome_ReasonChangedEvent()
        {
            // Arrange
            var expected = new DinnerGuestsReasonChangedEvent(2, 2);
            DinnerGuestsReasonChangedEvent result = null;
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfNotHomeViewModel()),
                 ComponentParameterFactory.EventCallback("OnComponentEvent", (evt) => result = (DinnerGuestsReasonChangedEvent)evt));

            // Act
            cut.FindAll(".options div")[1].Click();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuestsSelfStatus_DinnerGuestsListItem_ChildCount_Verify()
        {
            // Assert
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
             ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfNotHomeViewModel()));

            // Act
            var items = cut.FindComponents<DinnerGuestsListItem>();

            // Assert
            Assert.Equal(1, items.Count);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Snapshoht")]
        public void DinnerGuestsSelfStatus_DinnerGuestsListItem_Markup()
        {
            // Arrange
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
             ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfNotHomeViewModel()));

            // Act
            var item = cut.FindComponent<DinnerGuestsListItem>();

            // Assert
            item.MarkupMatches(TestComponentMarkupConstants.DinnerGuestsListItem_SelfStatus_NotHome);
        }

        [Fact]
        [Trait("DinnerGuestsListCard", "Unit")]
        public void DinnerGuestsListCard_DinnerGuestsListItem_ChildCount_Verify()
        {
            // Arrange
            var cut = RenderComponent<DinnerGuestsListCard>(
                ("ViewModel", DinnerGuestsTestViewModels.DefaultHomeForDinnerViewModel()));

            // Act
            var listItems = cut.FindComponents<DinnerGuestsListItem>();

            // Assert
            Assert.Equal(3, listItems.Count);
        }

        [Fact]
        [Trait("DinnerGuestsListCard", "Snapshot")]
        public void DinnerGuestsListCard_DinnerGuestListItem_Markup()
        {
            // Arrange
            var cut = RenderComponent<DinnerGuestsListCard>(
                ("ViewModel", DinnerGuestsTestViewModels.DefaultHomeForDinnerViewModel()));

            // Act
            var listItem = cut.FindComponents<DinnerGuestsListItem>()[1];

            // Assert
            listItem.MarkupMatches(TestComponentMarkupConstants.DinnerGuestsListItem_Home);
        }

        [Fact]
        [Trait("DinnerGuestsListCard", "Unit")]
        public void DinnerGuestsListCard_SelfStatus_ChildCount_Verify()
        {
            // Arrange
            var cut = RenderComponent<DinnerGuestsListCard>(
                ("ViewModel", DinnerGuestsTestViewModels.DefaultHomeForDinnerViewModel()));

            // Act
            var listItems = cut.FindComponents<DinnerGuestsSelfStatus>();

            // Assert
            Assert.Equal(1, listItems.Count);
        }
    }
}
