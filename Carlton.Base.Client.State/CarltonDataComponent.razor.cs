using Microsoft.AspNetCore.Components;

namespace Carlton.Base.Client.State.Components
{
    public partial class DataComponent<TComponent, TViewModel> where TComponent : ComponentBase, ICarltonComponent<TViewModel>
    {
    }
}
