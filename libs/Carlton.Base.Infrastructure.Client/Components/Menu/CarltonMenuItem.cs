using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carlton.Base.Client.Components.Menu
{
    public class CarltonMenuItem
    {
        public string MenuItemName { get; }
        public Func<Task> MenuItemEvent { get; }
        public IEnumerable<CarltonMenuItem> Submenu { get; }
        public bool IsSubmenu { get { return Submenu.Any(); } }

        public CarltonMenuItem(string menuItemName, Func<Task> menuItemEvent)
        {
            MenuItemName = menuItemName;
            MenuItemEvent = menuItemEvent;
            Submenu = new List<CarltonMenuItem>();
        }

        public CarltonMenuItem(string menuItemName, IEnumerable<CarltonMenuItem> submenu)
        {
            MenuItemName = menuItemName;
            MenuItemEvent = () => Task.CompletedTask;
            Submenu = submenu;
        }       
    }
}
