using System;
using System.Threading.Tasks;
using Carlton.Base.Client.State;
using Carlton.TestBed.Client.State;
using MediatR;

namespace Carlton.TestBed.Client.Shared.ComponentViewer
{
    public class ComponentViewerViewModel
    {
        public Type ComponentType { get; init; }
        public object ComponentViewModel { get; init; }
        public ComponentStatus ComponentStatus { get; init; }
        public bool IsCarltonComponent { get; init; }
    }
}
