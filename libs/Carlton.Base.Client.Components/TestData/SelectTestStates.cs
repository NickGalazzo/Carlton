using System.Collections.Generic;

namespace Carlton.Base.Client.Components.Test
{
    public static class SelectTestStates
    {
        public static Dictionary<string, object> Default()
        {
            return new Dictionary<string, object>()
              {
                  {"Label", "Test" },
                  {"Options",  new Dictionary<int, string>
                        {
                          { 1,  "Option 1" },
                          { 2, "Option 2" },
                          { 3, "Option 3" }
                        }
                  }
              };
        }
    }
}
