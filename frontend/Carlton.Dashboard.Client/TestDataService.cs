using Carlton.Base.Data;
using Carlton.Client.Base.Data;
using Carlton.Dashboard.Components.HomeForDinner;
using Carlton.Dashboard.ViewModels.HomeForDinner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carlton.Dashboard.Client
{
    public class TestDataService : IDataService<HomeForDinnerViewModel>
    {
        public event EventHandler<ViewModelChangedEventArgs> ViewModelChanged;

        public HomeForDinnerViewModel GetViewModel()
        {
            return new HomeForDinnerViewModel
            {
                DinnerGuests = new List<DinnerGuests>
                {
                    new DinnerGuests("test", true, "asdfsd"),
                    new DinnerGuests("test2", false, "dasdfsdf")
                }
            };
        }

        public void ReplaceSate(HomeForDinnerViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
