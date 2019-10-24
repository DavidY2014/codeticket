using System;

namespace Extension.Util
{
    public class UniqueGenerator
    {
        public static string UniId()
        {
            long currentTicks = DateTime.Now.Ticks;
            DateTime dtFrom = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long currentMillis = (currentTicks - dtFrom.Ticks) / 10000;
            return currentMillis.ToString();
        }
    }
}
