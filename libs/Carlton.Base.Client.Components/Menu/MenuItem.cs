using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carlton.Base.Client.Components
{
    public record MenuItems(IEnumerable<MenuItem> Items);
    public record MenuItem(string MenuItemName, Func<Task> MenuItemEvent);
}
