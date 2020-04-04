using MediatR;
using System;
using System.Threading.Tasks;

namespace Carlton.Base.Infrastructure.Client.Data
{
    public class BaseDataService<TViewModel> : IDataService<TViewModel>
    {
        public event EventHandler<EventArgs> ViewModelChanged;

        private TViewModel _state;
        private readonly IMediator _mediator;

        public BaseDataService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public TViewModel GetViewModel()
        {
            return _state;
        }

        protected void ReplaceSate(TViewModel viewModel)
        {
            _state = viewModel;
            ViewModelChanged?.Invoke(this, new ViewModelChangedEventArgs());
        }

        public  async Task HandleComponentEvent(IRequest<TViewModel> request)
        {
            //Send Request to 
            var newEvt = await _mediator.Send(request).ConfigureAwait(false);


            //Replace Data and trigger rebind
            ReplaceSate(newEvt);


            //Notify
            // _mediatrR.Notify(evt);
        }
    }
}


