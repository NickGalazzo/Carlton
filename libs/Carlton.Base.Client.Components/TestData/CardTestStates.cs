using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlton.Base.Client.Components.TestData
{
    public static class CardTestStates
    {
        public static Dictionary<string, object> DefaultState()
        {
            return new Dictionary<string, object>
            {
                { "CardTitle", "Test"}
            };
        }

        public static Dictionary<string, object> DefaultListState()
        {
            return new Dictionary<string, object>
            {
                { "CardTitle", "Test"},
                { "Items", new List<string> {"Item 1", "Item 2", "Item 3"} },
                { "ItemTemplate", listFragment }
            };
        }

        private static readonly RenderFragment<string> listFragment = (str) => itemFragment;

        private static readonly RenderFragment itemFragment = builder =>
        {
            builder.OpenElement(1, "div");
            builder.AddContent(2, "Some Content");
            builder.CloseElement();
        };
    }
}
