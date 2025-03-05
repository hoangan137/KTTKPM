using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Utilities
{
    internal static class ObjecExtension
    {
        public static T CopyObject<T>(this object objSource)
        {
            var serialized = JsonConvert.SerializeObject(objSource);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
