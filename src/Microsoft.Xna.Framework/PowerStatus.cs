using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework
{
    public static class PowerStatus
    {
        public static event EventHandler PowerStateChanged;

        public static PowerLineStatus PowerLineStatus
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static TimeSpan? BatteryLifeRemaining
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static float? BatteryLifePercent
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static TimeSpan? BatteryFullLifetime
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static BatteryChargeStatus BatteryChargeStatus
        {
            get
            {
                throw new NotImplementedException();
            }
        }

    }
}
