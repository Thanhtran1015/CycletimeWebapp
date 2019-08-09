using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace IoT.helpers
{
    public class CodeUtilites
    {
        public static async Task SetInterval(Action<object> action, TimeSpan timeout)
        {
            await Task.Delay(timeout).ConfigureAwait(false);
            var obj = action;
            action(obj);

           await SetInterval(action, timeout);
        }
    }
}