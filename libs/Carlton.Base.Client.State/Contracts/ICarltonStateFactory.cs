using MediatR;
using System;
using System.Collections.Generic;

namespace Carlton.Base.Client.State
{
    public interface ICarltonStateFactory
    {
        Type GetComponentType<TViewModel>();
        IEnumerable<string> GetComponentStateEvents<TViewModel>();
        IRequest<TViewModel> CreateViewModelRequest<TViewModel>();
        IRequest<Unit> CreateComponentEventRequest(object sender, object componentEvent);
    }
}
