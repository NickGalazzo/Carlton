using System.Collections.Generic;

namespace Carlton.Base.Client.Components.Menu
{
    public class CarltonMenuItems
    {
        public IEnumerable<CarltonMenuItem> Items { get; }

        public CarltonMenuItems(IEnumerable<CarltonMenuItem> items)
        {
            Items = items;
        }
    }
}
