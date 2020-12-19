using System;
using System.Collections.Generic;
using System.Linq;

namespace Carlton.Base.Client.Components
{
    public record TreeItem<TNode>
    {
        public string DisplayName { get; init; }
        public bool IsParentNode { get { return Children.Any(); } }

        //Parent Properties
        public IEnumerable<TreeItem<TNode>> Children { get; set; }

        //Child Properties
        public int LeafId { get; init; }
        public Type Type { get; init; }
        public TNode LeafNodeObj { get; init; }


        private TreeItem(string displayName, IEnumerable<TreeItem<TNode>> children)
        {
            DisplayName = displayName;
            Children = children;
        }

        private TreeItem(int leafId, string displayName, Type type, TNode obj)
        {
            LeafId = leafId;
            DisplayName = displayName;
            Type = type;
            LeafNodeObj = obj;
            Children = new List<TreeItem<TNode>>();
        }

        public static TreeItem<TNode> CreateParentNode(string displayName, IEnumerable<TreeItem<TNode>> children)
        {
            return new TreeItem<TNode>(displayName, children);
        }

        public static TreeItem<TNode> CreateLeafNode(int leafId, string displayName, Type type, TNode obj)
        {
            return new TreeItem<TNode>(leafId, displayName, type, obj);
        }
    }
}
