using System;
using System.Threading.Tasks;

namespace Carlton.Base.Client.Components.Menu
{
    public class CarltonMenuItem
    {
        public string MenuItemName { get; }
        public Func<Task> MenuItemEvent { get; }

        public CarltonMenuItem(string menuItemName, Func<Task> menuItemEvent)
        {
            MenuItemName = menuItemName;
            MenuItemEvent = menuItemEvent;
        }
    }
}
