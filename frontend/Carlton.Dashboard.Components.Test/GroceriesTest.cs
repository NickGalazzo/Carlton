using Bunit;
using Carlton.Dashboard.Components.Groceries;
using Carlton.Dashboard.ViewModels.Groceries;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Carlton.Dashboard.Components.Test
{
    public class GroceriesTest : TestContext
    {
        [Fact]
        [Trait("GroceriesListItem", "Snapshot")]
        public void GroceriesListItem_Low_Markup()
        {
            // Act
            var cut = RenderComponent<GroceriesListItem>(
                ("ViewModel", new GroceriesListItemViewModel(1, "Toilet Paper", 25))
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.GroceriesListItem_Low);
        }

        [Fact]
        [Trait("GroceriesListItem", "Snapshot")]
        public void GroceriesListItem_Medium_Markup()
        {
            // Act
            var cut = RenderComponent<GroceriesListItem>(
                ("ViewModel", new GroceriesListItemViewModel(1, "Paper Towels", 57))
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.GroceriesListItem_Medium);
        }

        [Fact]
        [Trait("GroceriesListItem", "Snapshot")]
        public void GroceriesListItem_High_Markup()
        {
            // Act
            var cut = RenderComponent<GroceriesListItem>(
                ("ViewModel", new GroceriesListItemViewModel(1, "Dish Soap", 92))
            );

            // Assert
            cut.MarkupMatches(TestComponentMarkupConstants.GroceriesListItem_High);
        }

        [Fact]
        [Trait("GroceriesListItem", "Unit")]
        public void GroceriesListItem_Verify_Label()
        {
            // Act
            var cut = RenderComponent<GroceriesListItem>(
                ("ViewModel", new GroceriesListItemViewModel(1, "Toilet Paper", 25))
            );

            var label = cut.Find(".item-name");

            // Assert
            Assert.Equal("Toilet Paper", label.TextContent);
        }

        [Fact]
        [Trait("GroceriesListItem", "Unit")]
        public void GroceriesListItem_Verify_Progress()
        {
            // Act
            var cut = RenderComponent<GroceriesListItem>(
                ("ViewModel", new GroceriesListItemViewModel(1, "Toilet Paper", 85))
            );

            var progressBar = cut.Find(".progress-bar");

            // Assert
            Assert.Equal("85", progressBar.GetAttribute("aria-valuenow"));
        }

        [Fact]
        [Trait("GroceriesListItem", "Unit")]
        public void GroceriesListItem_LessThan_35_Verify_LowClass()
        {
            // Act
            var cut = RenderComponent<GroceriesListItem>(
                ("ViewModel", new GroceriesListItemViewModel(1, "Toilet Paper", 25))
            );

            var progressBar = cut.Find(".progress-bar");

            // Assert
            Assert.True(progressBar.ClassList.Contains("low"));
        }

        [Fact]
        [Trait("GroceriesListItem", "Unit")]
        public void GroceriesListItem_GreaterThan_35_And_LessThan_75_Verify_MediumClass()
        {
            // Act
            var cut = RenderComponent<GroceriesListItem>(
                ("ViewModel", new GroceriesListItemViewModel(1, "Toilet Paper", 45))
            );

            var progressBar = cut.Find(".progress-bar");

            // Assert
            Assert.True(progressBar.ClassList.Contains("medium"));
        }

        [Fact]
        [Trait("GroceriesListItem", "Unit")]
        public void GroceriesListItem_GreaterThan_75_Verify_HighClass()
        {
            // Act
            var cut = RenderComponent<GroceriesListItem>(
                ("ViewModel", new GroceriesListItemViewModel(1, "Toilet Paper", 85))
            );

            var progressBar = cut.Find(".progress-bar");

            // Assert
            Assert.True(progressBar.ClassList.Contains("high"));
        }

        [Fact]
        [Trait("GroceriesListCard", "Unit")]
        public void GroceriesListCard_ThreeItems_Verify()
        {
            // Act
            var cut = RenderComponent<GroceriesListCard>(
                ("ViewModel", new GroceriesListViewModel
                    {
                        Items = new List<GroceriesListItemViewModel>
                        {
                            new GroceriesListItemViewModel(1, "Toilet Paper", 25),
                            new GroceriesListItemViewModel(1, "Toilet Paper", 45),
                            new GroceriesListItemViewModel(1, "Toilet Paper", 85)
                        }
                    }
                ));

            var items = cut.FindComponents<GroceriesListItem>();

            // Assert
            Assert.Equal(3, items.Count);
        }
    }
}
