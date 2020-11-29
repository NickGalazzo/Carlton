using System.Collections.Generic;

namespace Carlton.Base.Client.Components.Test
{
    public static class CarltonCheckboxTestStates
    {
        public static Dictionary<string, object> CheckedState()
        {
            return new Dictionary<string, object>
                {
                    { "IsChecked", true }
                };
        }

        public static Dictionary<string, object> UncheckedState()
        {
            return new Dictionary<string, object>
                {
                    { "IsChecked", false }
                };
        }
    }
}
