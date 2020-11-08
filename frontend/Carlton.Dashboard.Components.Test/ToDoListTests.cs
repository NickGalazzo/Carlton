using Bunit;
using Carlton.Dashboard.Components.ToDo.Events;
using Carlton.Dashboard.Components.ToDos;
using Carlton.TestBed.Client.TestViewModels;
using System.Linq;
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
                ("ViewModel", ToDoListTestViewModels.ToDoListItemUnchecked())
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.ToDoListItem_Unchecked);
        }

        [Fact]
        [Trait("ToDo", "Snapshot")]
        public void ToDoListItem_Checked_Markup()
        {
            // Act
            var cut = RenderComponent<ToDoListItem>(
                ("ViewModel", ToDoListTestViewModels.ToDoListItemChecked())
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.ToDoListItem_Checked);
        }

        [Fact]
        [Trait("ToDo", "ComponentEvent")]
        public void ToDoListItem_Initial_Unchecked_ToDoStatusChangedEvent()
        {
            // Arrange
            ToDoStatusChangedEvent result = null;
            var cut = RenderComponent<ToDoListItem>(
                ("ViewModel", ToDoListTestViewModels.ToDoListItemUnchecked()),
                ComponentParameterFactory.EventCallback("OnComponentEvent", (evt) => result = (ToDoStatusChangedEvent)evt)
            );

            //Act
            cut.Find(".carlton-checkbox span").Click();


            // Assert
            Assert.Equal(1, result.ToDoID);
            Assert.True(result.ToDoCompleted);
        }

        [Fact]
        [Trait("ToDo", "ComponentEvent")]
        public void ToDoListItem_Initial_Checked_ToDoStatusChangedEvent()
        {
            // Arrange
            ToDoStatusChangedEvent result = null;
            var cut = RenderComponent<ToDoListItem>(
                ("ViewModel", ToDoListTestViewModels.ToDoListItemChecked()),
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
        public void ToDoListItem_Label_Verify()
        {
            //Arrange
            var ToDoLabelText = "Take Out Garbage";

            // Act
            var cut = RenderComponent<ToDoListItem>(
                ("ViewModel", ToDoListTestViewModels.ToDoListItemChecked())
            );
            var renderedText = cut.Find("span.to-do-name").TextContent;


            // Assert
            Assert.Equal(ToDoLabelText, renderedText);
        }

        [Fact]
        [Trait("ToDoList", "Unit")]
        public void ToDoList_ToDoListItem_ChildCount_Verify()
        {
            // Arrange
            var cut = RenderComponent<ToDoListCard>(
                ("ViewModel", ToDoListTestViewModels.DefaultToDoList())
            );

            //Act
            var listItems = cut.FindComponents<ToDoListItem>();

            // Assert
            Assert.Equal(3, listItems.Count);
        }

        [Fact]
        [Trait("ToDoList", "Snapshot")]
        public void ToDoList_ToDoListItem_Markup()
        {
            // Arrange
            var cut = RenderComponent<ToDoListCard>(
                ("ViewModel", ToDoListTestViewModels.DefaultToDoList())
            );

            //Act
            var item = cut.FindComponents<ToDoListItem>().First();

            // Assert
            item.MarkupMatches(TestComponentMarkupConstants.ToDoListItem_Unchecked);
        }
    }
}
