using Carlton.Base.Client.State.Contracts;
using Carlton.TestBed.Client.Shared.EventConsole.Requests;
using Carlton.TestBed.Client.Shared.NavTree.Models;
using Carlton.TestBed.Client.Shared.NavTree.Requests;
using Carlton.TestBed.Client.Shared.StatusSwitch;
using Carlton.TestBed.Client.Shared.ViewModelViewer;
using Carlton.TestBed.Client.State;
using MediatR;
using System;
using System.Collections.Generic;

namespace Carlton.TestBed.Client
{
    public class TestBedRequestMapper : ICarltonEventRequestMapper
    {
        public const string GET_DATA = "GetData";
        public const string EVENT_CONSOLE_CLEAR = "EventConsoleClear";
        public const string SELECTED_NODE_CHANGED = "SelectedNodeChanged";
        public const string COMPONENT_STATUS_CHANGED = "ComponentStatusChanged";
        public const string VIEW_MODEL_CHANGED_EVENT = "ViewModelChangedEvent";

        private readonly Dictionary<string, Func<object, IBaseRequest>> _dataMap;
        

        public TestBedRequestMapper()
        {
            _dataMap = new Dictionary<string, Func<object, IBaseRequest>>
            {
                { GET_DATA, (_) =>  new GetViewModelRequest<object>() },
                { EVENT_CONSOLE_CLEAR, (_) => new ClearEventsRequest() },
                { SELECTED_NODE_CHANGED, (_) => new SelectNewComponentRequest()  },
                { COMPONENT_STATUS_CHANGED, (_) => new StatusChangeRequest() },
                { VIEW_MODEL_CHANGED_EVENT, (_) => new ChangeViewModelRequest() }
            };
        }
        //{ NodeNameToSelect = ((SelectedNodeChangedEvent)_).NodeName}

        public ICarltonComponentRequest<TViewModel> MapToRequest<TViewModel>(ICarltonComponentEvent evt)
        {
            return (ICarltonComponentRequest<TViewModel>) _dataMap[evt.EventName](evt);
        }

        public ICarltonComponentRequest<TViewModel> GetViewModelRequest<TViewModel>()
        {
            return null; // (ICarltonComponentRequest<TViewModel>)_dataMap[GET_DATA](null);
        }
    }
}
