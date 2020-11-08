using Bunit;
using Carlton.Dashboard.Components.DinnerGuests;
using Carlton.Dashboard.Components.DinnerGuests.Events;
using Carlton.TestBed.Client.TestViewModels;
using Xunit;

namespace Carlton.Dashboard.Components.Test
{
    public class DinnerGuestTests : TestContext
    {
        [Fact]
        [Trait("DinnerGuestsListItem", "Snapshot")]
        public void DinnerGuests_Home_Markup()
        {
            // Act
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
            // Act
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
            // Act
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfHomeViewModel()));

            var nameElement = cut.Find(".guest-name");

            // Assert
            Assert.Equal("Nick", nameElement.TextContent);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuestsSelfStatus_IsHome_Verify()
        {
            // Act
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfHomeViewModel()));

            var nameElement = cut.Find("input[type='checkbox'].switch");

            // Assert
            Assert.True(nameElement.HasAttribute("checked"));
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuestsSelfStatus_IsHome_Reason_Disabled_Verify()
        {
            // Act
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfHomeViewModel()));

            var reasonElement = cut.Find(".carlton-select .options");

            // Assert
            Assert.True(reasonElement.HasAttribute("disabled"));
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuestsSelfStatus_IsNotHome_Reason_NotDisabled_Verify()
        {
            // Act
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfNotHomeViewModel()));

            var reasonElement = cut.Find(".carlton-select .options");

            // Assert
            Assert.False(reasonElement.HasAttribute("disabled"));
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuestsSelfStatus_IsHome_Reason_Empty_Verify()
        {
            // Act
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfHomeViewModel()));

            var reasonElement = cut.FindAll(".guest-message");

            Assert.Empty(reasonElement);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuestsSelfStatus_IsNotHome_Reason_Japan_School_Verify()
        {
            // Act
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfNotHomeViewModel()));

            var reasonElement = cut.Find(".guest-message");

            // Assert
            Assert.Equal("Japan School", reasonElement.TextContent);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "ComponentEvent")]
        public void DinnerGuestsSelfStatus_IsNotHome_StatusChangedEvent()
        {
            //Act
            DinnerGuestsHomeForDinnerStatusChangeEvent result = null;
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfNotHomeViewModel()),
                 ComponentParameterFactory.EventCallback("OnComponentEvent", (evt) => result = (DinnerGuestsHomeForDinnerStatusChangeEvent)evt));

            //Act
            cut.Find("input.switch").Click();

            // Assert
            Assert.True(result.IsHomeForDinner);
            Assert.Equal(2, result.DinnerGuestId);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "ComponentEvent")]
        public void DinnerGuestsSelfStatus_IsHome_StatusChangedEvent()
        {
            //Act
            DinnerGuestsHomeForDinnerStatusChangeEvent result = null;
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfHomeViewModel()),
                 ComponentParameterFactory.EventCallback("OnComponentEvent", (evt) => result = (DinnerGuestsHomeForDinnerStatusChangeEvent)evt));

            //Act
            cut.Find("input.switch").Click();

            // Assert
            Assert.False(result.IsHomeForDinner);
            Assert.Equal(1, result.DinnerGuestId);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "ComponentEvent")]
        public void DinnerGuestsSelfStatus_NotHome_ReasonChangedEvent()
        {
            //Act
            DinnerGuestsReasonChangedEvent result = null;
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfNotHomeViewModel()),
                 ComponentParameterFactory.EventCallback("OnComponentEvent", (evt) => result = (DinnerGuestsReasonChangedEvent)evt));

            //Act
            cut.FindAll(".options div")[1].Click();

            // Assert
            Assert.Equal(2, result.ReasonId);
            Assert.Equal(2, result.DinnerGuestId);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuestsSelfStatus_DinnerGuestsListItem_ChildCount_Verify()
        {
            //Act
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
             ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfNotHomeViewModel()));

            var items = cut.FindComponents<DinnerGuestsListItem>();

            //Assert
            Assert.Equal(1, items.Count);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Snapshoht")]
        public void DinnerGuestsSelfStatus_DinnerGuestsListItem_Markup()
        {
            //Act
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
             ("ViewModel", DinnerGuestsTestViewModels.DinnerGuestsSelfNotHomeViewModel()));

            var item = cut.FindComponent<DinnerGuestsListItem>();

            //Assert
            item.MarkupMatches(TestComponentMarkupConstants.DinnerGuestsListItem_SelfStatus_NotHome);
        }

        [Fact]
        [Trait("DinnerGuestsListCard", "Unit")]
        public void DinnerGuestsListCard_DinnerGuestsListItem_ChildCount_Verify()
        {
            // Act
            var cut = RenderComponent<DinnerGuestsListCard>(
                ("ViewModel", DinnerGuestsTestViewModels.DefaultHomeForDinnerViewModel()));

            var listItems = cut.FindComponents<DinnerGuestsListItem>();

            // Assert
            Assert.Equal(3, listItems.Count);
        }

        [Fact]
        [Trait("DinnerGuestsListCard", "Snapshot")]
        public void DinnerGuestsListCard_DinnerGuestListItem_Markup()
        {
            // Act
            var cut = RenderComponent<DinnerGuestsListCard>(
                ("ViewModel", DinnerGuestsTestViewModels.DefaultHomeForDinnerViewModel()));

            var listItem = cut.FindComponents<DinnerGuestsListItem>()[1];

            // Assert
            listItem.MarkupMatches(TestComponentMarkupConstants.DinnerGuestsListItem_Home);
        }

        [Fact]
        [Trait("DinnerGuestsListCard", "Unit")]
        public void DinnerGuestsListCard_SelfStatus_ChildCount_Verify()
        {
            // Act
            var cut = RenderComponent<DinnerGuestsListCard>(
                ("ViewModel", DinnerGuestsTestViewModels.DefaultHomeForDinnerViewModel()));

            var listItems = cut.FindComponents<DinnerGuestsSelfStatus>();

            // Assert
            Assert.Equal(1, listItems.Count);
        }
    }
}
