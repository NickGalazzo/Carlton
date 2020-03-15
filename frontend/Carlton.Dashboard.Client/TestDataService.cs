using Carlton.Base.Infrastructure.Client.Data;
using Carlton.Dashboard.ViewModels.HomeForDinner;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carlton.Dashboard.Client
{
    public class TestDataService : IDataService<HomeForDinnerViewModel>
    {
        public event EventHandler<ViewModelChangedEventArgs> ViewModelChanged;

        event EventHandler<EventArgs> IReadOnlyDataService<HomeForDinnerViewModel>.ViewModelChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

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

        public Task HandleComponentEvent(IRequest<HomeForDinnerViewModel> evt)
        {
            throw new NotImplementedException();
        }

        public void ReplaceSate(HomeForDinnerViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
