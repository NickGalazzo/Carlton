using System;
using System.Collections.Generic;
using System.Text;

namespace Carlton.Base.Infrastructure.Client.Components.Select
{
    public class CarltonSelectViewModel
    {
        public string Label { get; }
        public IReadOnlyDictionary<string, int> Options { get; }

        public CarltonSelectViewModel(string label, IReadOnlyDictionary<string, int> options)
        {
            Label = label;
            Options = options;
        }
    }
}
