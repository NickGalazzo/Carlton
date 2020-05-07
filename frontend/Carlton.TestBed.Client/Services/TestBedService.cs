using System;
using System.Collections.Generic;
using Carlton.Base.Client.Components.Status;
using Carlton.TestBed.TestBedNavTree;

namespace Carlton.TestBed.Client.Services
{
    public class TestBedService
    {
        private readonly TestBedNavService _navService;
        private readonly TestBedViewModelService _vmService;
        private readonly TestBedEventService _eventService;
        private readonly TestBedStatusService _statusService;


        public IEnumerable<TestBedNavTreeItem> TreeItems { get { return _navService.NavTree; } }
        public Type TestComponentType { get { return _navService.TestComponentType; } }
        public bool IsTestComponentCarltonComponent { get { return _navService.IsTestComponentCarltonComponent; } }
        public ComponentStatus TestComponentStatus { get { return _statusService.TestComponentStatus; } }
        public object TestComponentViewModel { get { return _vmService.TestComponentViewModel; } }
        public IList<object> ComponentEvents { get { return _eventService.ComponentEvents; } }
       

        public Action<TestBedNavTreeItem> SelectItem { get { return _navService.SelectItem; } }
        public Action<object> AddComponentEvent { get { return _eventService.AddComponentEvent; } }
        public Action ClearEvents { get { return _eventService.ClearEvents; } }
        public Action<ComponentStatus> UpdateComponentStatus { get { return _statusService.UpdateComponentStatus; } }
        public Action<object> UpdateTestComponentViewModel { get { return _vmService.UpdateTestComponentViewModel; } }

        public TestBedService(TestBedNavService navService, TestBedViewModelService vmService,
            TestBedEventService eventService, TestBedStatusService statusService)
        {
            _navService = navService;
            _vmService = vmService;
            _eventService = eventService;
            _statusService = statusService;

            navService.SelectedItemChanged += (sender, newSelectedItem) =>
            {
                _vmService.UpdateTestComponentViewModel(newSelectedItem.ViewModel);
            };
        }
    }
}
