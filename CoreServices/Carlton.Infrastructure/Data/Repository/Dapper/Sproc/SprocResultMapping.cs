using System;

namespace Carlton.Infrastructure.Data.Repository.Dapper
{
    public class SprocResultMapping<T>
    {
        public Type[] Types { get; }
        public Func<object[], T> MappingFunc { get; }
        public string[] SplitColumns { get; }

        public SprocResultMapping(Type[] types, Func<object[], T> mappingFunc, string[] splitColumns)
        {
            Types = types;
            MappingFunc = mappingFunc;
            SplitColumns = splitColumns;
        }
    }
}
