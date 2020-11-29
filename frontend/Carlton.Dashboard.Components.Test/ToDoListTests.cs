using System.Linq;
using Xunit;
using Bunit;
using Carlton.Dashboard.ViewModels;
using Carlton.Dashboard.ViewModels.TestViewModels;

namespace Carlton.Dashboard.Components.Test
{
    public class ToDoListTests : TestContext
    {
        [Fact]
        [Trait("ToDo", "Snapshot")]
        public void ToDoListItem_Unchecked_Markup()
        {
            // Arrange
            var cut = RenderComponent<ToDoListItem>(
                ("ViewModel", ToDoListTestViewModels.ToDoListItemUncheckedViewModel())
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.ToDoListItem_Unchecked);
        }

        [Fact]
        [Trait("ToDo", "Snapshot")]
        public void ToDoListItem_Checked_Markup()
        {
            // Arrange
            var cut = RenderComponent<ToDoListItem>(
                ("ViewModel", ToDoListTestViewModels.ToDoListItemCheckedViewModel())
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.ToDoListItem_Checked);
        }

        [Fact]
        [Trait("ToDo", "ComponentEvent")]
        public void ToDoListItem_Initial_Unchecked_ToDoStatusChangedEvent()
        {
            // Arrange
            var expected = new ToDoStatusChangedEvent(1, true);
            ToDoStatusChangedEvent result = null;
            var cut = RenderComponent<ToDoListItem>(
                ("ViewModel", ToDoListTestViewModels.ToDoListItemUncheckedViewModel()),
                ComponentParameterFactory.EventCallback("OnComponentEvent", (evt) => result = (ToDoStatusChangedEvent)evt)
            );

            // Act
            cut.Find(".carlton-checkbox span").Click();


            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait("ToDo", "ComponentEvent")]
        public void ToDoListItem_Initial_Checked_ToDoStatusChangedEvent()
        {
            // Arrange
            var expected = new ToDoStatusChangedEvent(1, false);
            ToDoStatusChangedEvent result = null;
            var cut = RenderComponent<ToDoListItem>(
                ("ViewModel", ToDoListTestViewModels.ToDoListItemCheckedViewModel()),
                ComponentParameterFactory.EventCallback("OnComponentEvent", (evt) => result = (ToDoStatusChangedEvent)evt)
            );

            // Act
            cut.Find(".carlton-checkbox span").Click();


            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait("ToDo", "Unit")]
        public void ToDoListItem_Label_Verify()
        {
            // Arrange
            var ToDoLabelText = "Take Out Garbage";
            var cut = RenderComponent<ToDoListItem>(
                ("ViewModel", ToDoListTestViewModels.ToDoListItemCheckedViewModel())
            );

            // Act
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
                ("ViewModel", ToDoListTestViewModels.DefaultToDoListViewModel())
            );

            // Act
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
                ("ViewModel", ToDoListTestViewModels.DefaultToDoListViewModel())
            );

            // Act
            var item = cut.FindComponents<ToDoListItem>().First();

            // Assert
            item.MarkupMatches(TestComponentMarkupConstants.ToDoListItem_Unchecked);
        }
    }
}
