using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carlton.Base.Infrastructure.Client.Events;
using Carlton.Base.Infrastructure.Client.Components.Tree;

namespace Carlton.Base.Infrastructure.Client.Components.TestBed
{
    public class TestBedService
    {
        public delegate void ComponentEventFiredHandler(IComponentEvent evt);
        public event EventHandler<IComponentEvent> ComponentEventFired;
        public event EventHandler ComponentChanged;

        public event EventHandler ComponentViewModelChanged;

        public CarltonTreeViewModel CarltonTreeViewModel {get; set;}

        public void UpdateComponentViewModel(object vm)
        {
            CarltonTreeViewModel.SelectedItem.ViewModel = vm;
            ComponentViewModelChanged?.Invoke(this, new EventArgs());
        }

        private object _viewModel;
        public object ViewModel 
        { 
            get
            {
                return _viewModel;
            }
            set
            {
                _viewModel = value;
                if(_viewModel != value)
                    ComponentChanged?.Invoke(this, new EventArgs());
            }
        }

        public void FireEvent(object sender, IComponentEvent evt)
        {
            ComponentEventFired.Invoke(sender, evt);
        }
    }
}
