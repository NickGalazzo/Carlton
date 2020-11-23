using AutoMapper;
using Carlton.Base.Client.State.Contracts;
using Carlton.TestBed.Client.Shared.NavTree.Models;
using Carlton.TestBed.Client.Shared.NavTree.Requests;
using Carlton.TestBed.Client.State;
using MediatR;
using System;
using System.Collections.Generic;

namespace Carlton.TestBed.Client
{
    public class TestBedRequestMapper : ICarltonRequestFactory
    {
        public const string GET_DATA = "GetData";
        public const string EVENT_CONSOLE_CLEAR = "EventConsoleClear";
        public const string SELECTED_NODE_CHANGED = "SelectedNodeChanged";
        public const string COMPONENT_STATUS_CHANGED = "ComponentStatusChanged";
        public const string VIEW_MODEL_CHANGED_EVENT = "ViewModelChangedEvent";

        private readonly Dictionary<string, Func<object, IBaseRequest>> _dataMap;

        private readonly Dictionary<Type, IBaseRequest> _data = new Dictionary<Type, IBaseRequest>
        {
          //  {typeof(TestBedNavTreeViewModel), new GetTestBedNavTreeViewModelRequest()}
        };

        private readonly IServiceProvider _provider;
        private readonly IMapper _mapper;

        public TestBedRequestMapper(IServiceProvider provider, IMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;


        }

        public IRequest<TViewModel> MapToRequest<TViewModel>(ICarltonComponentEvent evt)
        {
            return _mapper.Map<IRequest<TViewModel>>(evt);
        }

        public IRequest<TViewModel> GetViewModelRequest<TViewModel>()
        {
            return (IRequest<TViewModel>)_provider.GetService(typeof(IRequest<TViewModel>)); 
        }
    }
}


