using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Net
{
    public sealed class QualityOfService
    {

        internal QualityOfService()
        {
        }

        public TimeSpan AverageRoundtripTime
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int BytesPerSecondDownstream
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int BytesPerSecondUpstream
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsAvailable
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TimeSpan MinimumRoundtripTime
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
