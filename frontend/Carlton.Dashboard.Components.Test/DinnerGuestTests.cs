using Bunit;
using Carlton.Dashboard.Components.DinnerGuests;
using Carlton.Dashboard.Components.DinnerGuests.Events;
using Carlton.Dashboard.ViewModels.DinnerGuests;
using System.Collections.Generic;
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
                ("ViewModel", DinnerGuestsListItemViewModel.CreateHomeForDinnerGuest(1, "Nick"))
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
                ("ViewModel", DinnerGuestsListItemViewModel.CreateNotHomeForDinnerGuest(1, "Steve", new DinnerGuestReason(1, "Japan School")))
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.DinnerGuestsListItem_NotHome);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Snapshot")]
        public void DinnerGuests_SelfStatus_Name()
        {
            // Act
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", new DinnerGuestSelfStatusViewModel(
                                    DinnerGuestsListItemViewModel.CreateHomeForDinnerGuest(1, "Nick"),
                                    new List<DinnerGuestReason>
                                    {
                                        new DinnerGuestReason(1, "Japan School"),
                                        new DinnerGuestReason(2, "Out With Friends")
                                    })));

            var nameElement = cut.Find(".guest-name");

            // Assert
            Assert.Equal("Nick", nameElement.TextContent);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Snapshot")]
        public void DinnerGuests_SelfStatus_IsHome()
        {
            // Act
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", new DinnerGuestSelfStatusViewModel(
                                    DinnerGuestsListItemViewModel.CreateHomeForDinnerGuest(1, "Nick"),
                                    new List<DinnerGuestReason>
                                    {
                                        new DinnerGuestReason(1, "Japan School"),
                                        new DinnerGuestReason(2, "Out With Friends")
                                    })));

            var nameElement = cut.Find("input[type='checkbox'].switch");

            // Assert
            Assert.True(nameElement.HasAttribute("checked"));
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuests_SelfStatus_IsHome_Reason_Disabled()
        {
            // Act
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", new DinnerGuestSelfStatusViewModel(
                                    DinnerGuestsListItemViewModel.CreateHomeForDinnerGuest(1, "Nick"),
                                    new List<DinnerGuestReason>
                                    {
                                        new DinnerGuestReason(1, "Japan School"),
                                        new DinnerGuestReason(2, "Out With Friends")
                                    })));

            var reasonElement = cut.Find(".carlton-select .options");

            // Assert
            Assert.True(reasonElement.HasAttribute("disabled"));
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuests_SelfStatus_IsNotHome_Reason_NotDisabled()
        {
            // Act
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", new DinnerGuestSelfStatusViewModel(
                                    DinnerGuestsListItemViewModel.CreateNotHomeForDinnerGuest(1, "Steve", 
                                    new DinnerGuestReason(1, "Japan School")),
                                    new List<DinnerGuestReason>
                                    {
                                        new DinnerGuestReason(1, "Japan School"),
                                        new DinnerGuestReason(2, "Out With Friends")
                                    })));

            var reasonElement = cut.Find(".carlton-select .options");

            // Assert
            Assert.False(reasonElement.HasAttribute("disabled"));
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuests_SelfStatus_IsHome_Reason_Empty()
        {
            // Act
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", new DinnerGuestSelfStatusViewModel(
                                    DinnerGuestsListItemViewModel.CreateHomeForDinnerGuest(1, "Nick"),
                                    new List<DinnerGuestReason>
                                    {
                                        new DinnerGuestReason(1, "Japan School"),
                                        new DinnerGuestReason(2, "Out With Friends")
                                    })));

            var reasonElement = cut.FindAll(".guest-message");

            Assert.Empty(reasonElement);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "Unit")]
        public void DinnerGuests_SelfStatus_IsNotHome_Reason_Japan_School()
        {
            // Act
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", new DinnerGuestSelfStatusViewModel(
                                    DinnerGuestsListItemViewModel.CreateNotHomeForDinnerGuest(1, "Steve",
                                    new DinnerGuestReason(1, "Japan School")),
                                    new List<DinnerGuestReason>
                                    {
                                        new DinnerGuestReason(1, "Japan School"),
                                        new DinnerGuestReason(2, "Out With Friends")
                                    })));

            var reasonElement = cut.Find(".guest-message");

            // Assert
            Assert.Equal("Japan School", reasonElement.TextContent);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "ComponentEvent")]
        public void DinnerGuests_SelfStatus_IsNotHome_StatusChangedEvent()
        {
            //Act
            DinnerGuestsHomeForDinnerStatusChangeEvent result = null;
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", new DinnerGuestSelfStatusViewModel(
                                    DinnerGuestsListItemViewModel.CreateNotHomeForDinnerGuest(2, "Steve",
                                    new DinnerGuestReason(1, "Japan School")),
                                    new List<DinnerGuestReason>
                                    {
                                        new DinnerGuestReason(1, "Japan School"),
                                        new DinnerGuestReason(2, "Out With Friends")
                                    })),
                 ComponentParameterFactory.EventCallback("OnComponentEvent", (evt) => result = (DinnerGuestsHomeForDinnerStatusChangeEvent)evt));

            //Act
            cut.Find("input.switch").Click();

            // Assert
            Assert.True(result.IsHomeForDinner);
            Assert.Equal(2, result.DinnerGuestId);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "ComponentEvent")]
        public void DinnerGuests_SelfStatus_IsHome_StatusChangedEvent()
        {
            //Act
            DinnerGuestsHomeForDinnerStatusChangeEvent result = null;
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", new DinnerGuestSelfStatusViewModel(
                                    DinnerGuestsListItemViewModel.CreateHomeForDinnerGuest(1, "Nick"),
                                    new List<DinnerGuestReason>
                                    {
                                        new DinnerGuestReason(1, "Japan School"),
                                        new DinnerGuestReason(2, "Out With Friends")
                                    })),
                 ComponentParameterFactory.EventCallback("OnComponentEvent", (evt) => result = (DinnerGuestsHomeForDinnerStatusChangeEvent)evt));

            //Act
            cut.Find("input.switch").Click();

            // Assert
            Assert.False(result.IsHomeForDinner);
            Assert.Equal(1, result.DinnerGuestId);
        }

        [Fact]
        [Trait("DinnerGuestsSelfStatus", "ComponentEvent")]
        public void DinnerGuests_SelfStatus_NotHome_ReasonChangedEvent()
        {
            //Act
            DinnerGuestsReasonChangedEvent result = null;
            var cut = RenderComponent<DinnerGuestsSelfStatus>(
                ("ViewModel", new DinnerGuestSelfStatusViewModel(
                                    DinnerGuestsListItemViewModel.CreateNotHomeForDinnerGuest(2, "Steve",
                                    new DinnerGuestReason(1, "Japan School")),
                                    new List<DinnerGuestReason>
                                    {
                                        new DinnerGuestReason(1, "Japan School"),
                                        new DinnerGuestReason(2, "Out With Friends")
                                    })),
                 ComponentParameterFactory.EventCallback("OnComponentEvent", (evt) => result = (DinnerGuestsReasonChangedEvent)evt));

            //Act
            cut.FindAll(".options div")[1].Click();

            // Assert
            Assert.Equal(2, result.ReasonId);
            Assert.Equal(2, result.DinnerGuestId);
        }

        [Fact]
        [Trait("DinnerGuestsListCard", "Snapshot")]
        public void DinnerGuestsListCard_TwoGuests_Markup()
        {
            // Act
            var cut = RenderComponent<DinnerGuestsListCard>(
                ("ViewModel",
                        new DinnerGuestsListViewModel(
                                    new DinnerGuestSelfStatusViewModel(
                                        DinnerGuestsListItemViewModel.CreateNotHomeForDinnerGuest(1, "Steve",
                                        new DinnerGuestReason(1, "Japan School")),
                                        new List<DinnerGuestReason>
                                        {
                                            new DinnerGuestReason(1, "Japan School"),
                                            new DinnerGuestReason(2, "Out With Friends")
                                        }),
                                    new List<DinnerGuestsListItemViewModel>
                                    {
                                        DinnerGuestsListItemViewModel.CreateHomeForDinnerGuest(1, "Nick"),
                                        DinnerGuestsListItemViewModel.CreateNotHomeForDinnerGuest(2, "Steve",
                                            new DinnerGuestReason(1, "Japan School")),
                                    })));

            var listItems = cut.FindComponents<DinnerGuestsListItem>();

            // Assert
            Assert.Equal(3, listItems.Count);
        }

        [Fact]
        [Trait("DinnerGuestsListCard", "Snapshot")]
        public void DinnerGuestsListCard_SelfStatus_Markup()
        {
            // Act
            var cut = RenderComponent<DinnerGuestsListCard>(
                ("ViewModel",
                        new DinnerGuestsListViewModel(
                                    new DinnerGuestSelfStatusViewModel(
                                        DinnerGuestsListItemViewModel.CreateNotHomeForDinnerGuest(1, "Steve",
                                        new DinnerGuestReason(1, "Japan School")),
                                        new List<DinnerGuestReason>
                                        {
                                            new DinnerGuestReason(1, "Japan School"),
                                            new DinnerGuestReason(2, "Out With Friends")
                                        }),
                                    new List<DinnerGuestsListItemViewModel>
                                    {
                                        DinnerGuestsListItemViewModel.CreateHomeForDinnerGuest(1, "Nick"),
                                        DinnerGuestsListItemViewModel.CreateNotHomeForDinnerGuest(2, "Steve",
                                            new DinnerGuestReason(1, "Japan School")),
                                    })));

            var listItems = cut.FindComponents<DinnerGuestsSelfStatus>();

            // Assert
            Assert.Equal(1, listItems.Count);
        }
    }
}
