namespace Carlton.Dashboard.Components.Tree
{
    public class TreeStyle
    {
        public static readonly TreeStyle DefaultTreeStyle = new TreeStyle
        { 
            ExpandNodeIconClass = "mdi mdi-24px mdi-chevron-right",
            CollapseNodeIconClass = "mdi mdi-24px mdi-chevron-down",
            NodeTitleClass = "p-1 curosr-pointer",
            NodeTitleSelectedClass = "bg-primary text-white",
        };

        public string ExpandNodeIconClass { get; set; }
        public string CollapseNodeIconClass { get; set; }
        public string NodeTitleClass { get; set; }
        public string NodeTitleSelectedClass { get; set; }
    }
}
