namespace Carlton.TestBed.Client.Services
{
    public class TestBedViewModelService
    {
        public object TestComponentViewModel { get; private set; }

        public void UpdateTestComponentViewModel(object vm)
        {
            TestComponentViewModel = vm;
        }
    }
}
