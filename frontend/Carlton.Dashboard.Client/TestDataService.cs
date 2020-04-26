using Carlton.Base.Infrastructure.Client.Data;
using Carlton.Dashboard.ViewModels.DinnerGuests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carlton.Dashboard.Client
{
    public class TestDataService : IDataService<DinnerGuestsListViewModel>
    {
        public event EventHandler<ViewModelChangedEventArgs> ViewModelChanged;

        event EventHandler<EventArgs> IReadOnlyDataService<DinnerGuestsListViewModel>.ViewModelChanged
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

        public DinnerGuestsListViewModel GetViewModel()
        {
            return null;
        }

        public Task HandleComponentEvent(IRequest<DinnerGuestsListViewModel> evt)
        {
            throw new NotImplementedException();
        }

        public void ReplaceSate(DinnerGuestsListViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
