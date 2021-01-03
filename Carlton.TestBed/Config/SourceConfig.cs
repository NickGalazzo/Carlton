namespace Carlton.TestBed
{
    public class SourceConfig
    {
        public string SourceBasePath { get; init; }

        public SourceConfig(string sourceBasePath)
        {
            SourceBasePath = sourceBasePath;
        }
    }
}
