using System;
using System.Linq;
using System.Threading.Tasks;

namespace Carlton.Base.Client.Components.Menu
{
    public class CarltonMenuItem
    {
        public string MenuItemName { get; }
        public Func<Task> MenuItemEvent { get; }
        public CarltonMenuItems Submenu { get; }
        public bool IsSubmenu { get { return Submenu.Items.Any(); } }

        public CarltonMenuItem(string menuItemName, Func<Task> menuItemEvent)
           : this(menuItemName, menuItemEvent, null)
        {
        }

        public CarltonMenuItem(string menuItemName, Func<Task> menuItemEvent, CarltonMenuItems submenu)
        {
            MenuItemName = menuItemName;
            MenuItemEvent = menuItemEvent;
            Submenu = submenu ?? new CarltonMenuItems();
        }       
    }
}
