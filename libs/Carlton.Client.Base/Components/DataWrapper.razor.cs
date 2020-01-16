using System;
using Carlton.Base.Data;
using Carlton.Client.Base.Data;
using Carlton.Client.Base.Events;
using Microsoft.AspNetCore.Components;

namespace Carlton.Client.Base.Components
{
    public partial class DataWrapper<TViewModel>
        where TViewModel : IViewModel
    {
        [Parameter]
        public RenderFragment<ComponentDataWrapperContext<TViewModel>> ChildComponent { get; set; }

        [Inject]
        private IDataService<TViewModel> DataService { get; set; }

        [Inject]
        private IServiceProvider ServiceProvider { get; set; } 

        private ComponentDataWrapperContext<TViewModel> Context { get; set; }
        private TViewModel ViewModel { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ViewModel = DataService.GetViewModel();
            Context = new ComponentDataWrapperContext<TViewModel>(ViewModel, ComponentEventHandler);
            DataService.ViewModelChanged += DataService_ViewModelChanged;
        }

        private void DataService_ViewModelChanged(object sender, ViewModelChangedEventArgs e)
        {
            ViewModel = DataService.GetViewModel();
        }


        public void ComponentEventHandler(IComponentEvent<IComponentEventResult> evt)
        {
            var handlerType = typeof(IComponentEventHandler<,>).MakeGenericType(evt.GetType(), typeof(IComponentEventResult));
            dynamic handler = ServiceProvider.GetService(handlerType);
           // handler.Handle((dynamic)evt);
        }
    }
}

