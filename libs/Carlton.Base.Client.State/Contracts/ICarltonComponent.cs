using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;


namespace Carlton.Base.Client.State
{
    public interface ICarltonComponent<TViewModel>
    {
        TViewModel ViewModel { get; set; }
        EventCallback OnComponentEvent { get; init; }
    }
}
