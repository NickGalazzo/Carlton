namespace Carlton.Base.Client.Components
{
    public class TreeStyle
    {
        public static readonly TreeStyle DefaultTreeStyle = new TreeStyle
        { 
            ExpandNodeIconClass = "mdi mdi-24px mdi-chevron-right",
            CollapseNodeIconClass = "mdi mdi-24px mdi-chevron-down",
            NodeTitleClass = "p-1 curosr-pointer",
            NodeTitleSelectedClass = "selected-tree-node",
        };

        public string ExpandNodeIconClass { get; set; }
        public string CollapseNodeIconClass { get; set; }
        public string NodeTitleClass { get; set; }
        public string NodeTitleSelectedClass { get; set; }
    }
}
