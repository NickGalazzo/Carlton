using System;

namespace Carlton.TestBed.Client.Shared.SourceViewer
{
    public class SourceViewerViewModel
    {
        public Type TestComponentType { get; }
        
        public SourceViewerViewModel(Type testComponentType)
        {
            TestComponentType = testComponentType;
        }
    }
}
