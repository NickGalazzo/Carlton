﻿using Carlton.Base.Client.Components.Menu;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carlton.Base.Client.Components.Test
{
    public static class CarltonMenuTestStates
    {
        public static Dictionary<string, object> Default()
        {
            return new Dictionary<string, object>
            {
                {"MenuItems", DefaultMenuItems() }
            };
        }

        private static CarltonMenuItems DefaultMenuItems()
        {
            return new CarltonMenuItems(new List<CarltonMenuItem>
                  {
                          new CarltonMenuItem("Option 1", () => Task.CompletedTask),
                          new CarltonMenuItem("Option 2", () => Task.CompletedTask),
                          new CarltonMenuItem("Option 3", () => Task.CompletedTask)
                  });
        }
    }
}

