using System;
using Carlton.Base.Client.Status;

namespace Carlton.TestBed.Client.Shared.ComponentViewer
{
    public class ComponentViewerViewModel
    {
        public Type ComponentType { get; set; }
        public object ComponentViewModel { get; set; }
        public ComponentStatus ComponentStatus { get; set; }
        public bool IsCarltonComponent { get; set; }
    }
}
