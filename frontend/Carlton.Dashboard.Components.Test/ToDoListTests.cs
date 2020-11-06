using Bunit;
using Carlton.Dashboard.Components.ApartmentStatus;
using Carlton.Dashboard.Components.ToDo.Events;
using Carlton.Dashboard.Components.ToDos;
using Carlton.Dashboard.ViewModels.ApartmentStatus;
using Carlton.Dashboard.ViewModels.ToDos;
using System;
using System.Collections.Generic;
using Xunit;

namespace Carlton.Dashboard.Components.Test
{
    public class ToDoListTests : TestContext
    {
        [Fact]
        [Trait("ToDo", "Snapshot")]
        public void ToDoListItem_Unchecked_Markup()
        {
            // Act
            var cut = RenderComponent<ToDoListItem>(
                ("ViewModel", new ToDoListItemViewModel(1, "Take Out Garbage", false))
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.ApartmentStatusListItem_Unchecked);
        }

        [Fact]
        [Trait("ToDo", "Snapshot")]
        public void ToDoListItem_Checked_Markup()
        {
            // Act
            var cut = RenderComponent<ToDoListItem>(
                ("ViewModel", new ToDoListItemViewModel(1, "Take Out Garbage", true))
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.ApartmentStatusListItem_Checked);
        }

        [Fact]
        [Trait("ToDo", "Event")]
        public void ToDoListItem_CompnentEvent_ToDo_Check()
        {
            // Arrange
            ToDoStatusChangedEvent result = null;
            var cut = RenderComponent<ToDoListItem>(
                ("ViewModel", new ToDoListItemViewModel(1, "Take out Garbage", false)),
                ComponentParameterFactory.EventCallback("OnComponentEvent", (evt) => result = (ToDoStatusChangedEvent)evt)
            );

            //Act
            cut.Find(".carlton-checkbox span").Click();


            // Assert
            Assert.Equal(1, result.ToDoID);
            Assert.True(result.ToDoCompleted);
        }

        [Fact]
        [Trait("ToDo", "Event")]
        public void ToDoListItem_CompnentEvent_ToDo_Uncheck()
        {
            // Arrange
            ToDoStatusChangedEvent result = null;
            var cut = RenderComponent<ToDoListItem>(
                ("ViewModel", new ToDoListItemViewModel(1, "Take out Garbage", true)),
                ComponentParameterFactory.EventCallback("OnComponentEvent", (evt) => result = (ToDoStatusChangedEvent)evt)
            );

            //Act
            cut.Find(".carlton-checkbox span").Click();


            // Assert
            Assert.Equal(1, result.ToDoID);
            Assert.False(result.ToDoCompleted);
        }

        [Fact]
        [Trait("ToDo", "Unit")]
        public void ToDoListItem_Verify_Label()
        {
            //Arrange
            var ToDoLabelText = "Take Out Garbage";

            // Act
            var cut = RenderComponent<ToDoListItem>(
                ("ViewModel", new ToDoListItemViewModel(1, ToDoLabelText, true))
            );
            var renderedText = cut.Find("span.to-do-name").TextContent;


            // Assert
            Assert.Equal(ToDoLabelText, renderedText);
        }


        [Fact]
        [Trait("ToDoList", "Snapshot")]
        public void ToDoList_Snapshot()
        {
            // Arrange
            var cut = RenderComponent<ToDoListCard>(
                ("ViewModel", new ToDoListViewModel(new List<ToDoListItemViewModel>
                {
                    new ToDoListItemViewModel(1, "Take Out Garbage", false),
                    new ToDoListItemViewModel(2, "Go Shopping", false),
                    new ToDoListItemViewModel(3, "Prepare Dinner", true)
                }))
            );

            //Act
            var listItems = cut.FindAll("li .to-do-list-item");

            // Assert
            Assert.Equal(3, listItems.Count);
        }

        [Fact]
        [Trait("ToDoList", "Snapshot")]
        public void ToDoList_ToDoListItem_Snapshot()
        {
            // Arrange
            var cut = RenderComponent<ToDoListCard>(
                ("ViewModel", new ToDoListViewModel(new List<ToDoListItemViewModel>
                {
                    new ToDoListItemViewModel(1, "Take Out Garbage", false),
                    new ToDoListItemViewModel(2, "Go Shopping", false),
                    new ToDoListItemViewModel(3, "Prepare Dinner", true)
                }))
            );

            //Act
            var item = cut.FindAll(".to-do-list-item")[0];

            // Assert
            item.MarkupMatches(TestComponentMarkupConstants.ApartmentStatusListItem_Unchecked);
        }
    }
}
