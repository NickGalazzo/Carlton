using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carlton.Base.Client.Components.Test
{
    public static class MenuTestStates
    {
        public static Dictionary<string, object> Default()
        {
            return new Dictionary<string, object>
            {
                {"MenuItems", DefaultMenuItems() }
            };
        }

        public static Dictionary<string, object> SubMenu()
        {
            return new Dictionary<string, object>
            {
                {"MenuItems", MenuItemsWithSubMenu() }
            };
        }

        private static IEnumerable<MenuItem> DefaultMenuItems()
        {
            return new List<MenuItem>
                  {
                          new MenuItem("Option 1", () => Task.CompletedTask),
                          new MenuItem("Option 2", () => Task.CompletedTask),
                          new MenuItem("Option 3", () => Task.CompletedTask)
                  };
        }

        private static IEnumerable<MenuItem> MenuItemsWithSubMenu()
        {
            return new List<MenuItem>
                  {
                          new MenuItem("Option 1", () => Task.CompletedTask),
                          new MenuItem("Option 2", () => Task.CompletedTask),
                          new MenuItem("Option 3", DefaultMenuItems())
                  };
        }
    }
}

