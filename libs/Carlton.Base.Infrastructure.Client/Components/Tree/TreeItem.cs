﻿using System;
using System.Collections.Generic;

namespace Carlton.Base.Infrastructure.Client.Components.Tree
{
    public class TreeItem
    {
        public string DisplayName { get;private set; }
        public Type Type { get; private set; }
        public object ViewModel { get; private set; }

        public IEnumerable<TreeItem> Children { get; set; }

        private TreeItem(string displayName, IEnumerable<TreeItem> children)
        {
            DisplayName = displayName;
            Children = children;
        }

        private TreeItem(string displayName, Type type, object viewModel)
        {
            DisplayName = displayName;
            Type = type;
            ViewModel = viewModel;
            Children = new List<TreeItem>();
        }

        public static TreeItem CreateParentNode(string displayName, IEnumerable<TreeItem> children)
        {
            return new TreeItem(displayName, children);
        }

        public static TreeItem CreateChildNode(string displayName, Type type, object viewModel)
        {
            return new TreeItem(displayName, type, viewModel);
        }
    }
}