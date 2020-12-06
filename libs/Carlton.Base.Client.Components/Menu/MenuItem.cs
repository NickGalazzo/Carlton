using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carlton.Base.Client.Components
{
    public class MenuItem
    {
        public string MenuItemName { get; }
        public Func<Task> MenuItemEvent { get; }
        public IEnumerable<MenuItem> Submenu { get; }
        public bool IsSubmenu { get { return Submenu.Any(); } }

        public MenuItem(string menuItemName, Func<Task> menuItemEvent)
        {
            MenuItemName = menuItemName;
            MenuItemEvent = menuItemEvent;
            Submenu = new List<MenuItem>();
        }

        public MenuItem(string menuItemName, IEnumerable<MenuItem> submenu)
        {
            MenuItemName = menuItemName;
            MenuItemEvent = () => Task.CompletedTask;
            Submenu = submenu;
        }       
    }
}
