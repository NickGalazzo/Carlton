using Carlton.Dashboard.ViewModels.CarltonTree;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carlton.Dashboard.Client.TestBed
{
    public class TestBedConfigurationBuilder
    {
        private CarltonTreeViewModel _model;

        private readonly List<Tuple<Type, string>> _componentTestStates;

        public TestBedConfigurationBuilder()
        {
            _model = new CarltonTreeViewModel();
            _componentTestStates = new List<Tuple<Type, string>>();
        }

        public TestBedConfigurationBuilder AddComponent<TComponent>(string stateName)
            where TComponent : ComponentBase
        {
            _componentTestStates.Add(Tuple.Create(typeof(TComponent), stateName));
            return this;
        }

        public IEnumerable<TreeItem> Build()
        {
            var treeItems = new List<TreeItem>();

            var statesGroupedByComponent = _componentTestStates.GroupBy(o => o.Item1);

            statesGroupedByComponent.ToList().ForEach(group =>
            {
                var children = new List<TreeItem>();
                var treeItem = new TreeItem { Text = group.Key.Name, Children = children };

                group.ToList().ForEach(tup => children.Add(new TreeItem { Text = tup.Item2 }));
                treeItems.Add(treeItem);

            });
            return treeItems;
        }
    }
}
