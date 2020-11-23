﻿using MediatR;

namespace Carlton.Base.Client.State
{
    public interface ICarltonRequestFactory
    {
        IRequest<TViewModel> MapToRequest<TViewModel>(ICarltonComponentEvent evt);
        IRequest<TViewModel> GetViewModelRequest<TViewModel>();
    }
}
