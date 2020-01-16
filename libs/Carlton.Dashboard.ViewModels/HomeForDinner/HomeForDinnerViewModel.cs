using Carlton.Base.Data;
using System.Collections.Generic;

namespace Carlton.Dashboard.ViewModels.HomeForDinner
{
    public class HomeForDinnerViewModel : IViewModel
    {
        public List<DinnerGuests> DinnerGuests { get; set; }
    }
}
