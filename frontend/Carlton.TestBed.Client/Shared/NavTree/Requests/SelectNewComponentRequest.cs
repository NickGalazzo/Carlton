using Carlton.Base.Client.State.Contracts;
using Carlton.TestBed.Client.Shared.NavTree.Models;

namespace Carlton.TestBed.Client.Shared.NavTree.Requests
{
    public class SelectNewComponentRequest : ICarltonComponentRequest<TestBedNavTreeViewModel>
    {
        public string NodeNameToSelect { get; set; }
    }
}
