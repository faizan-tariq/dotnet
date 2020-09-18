using System;
using SampleDotNet.Interface;

namespace SampleDotNet.Service
{
    public class SystemDateTime : ITimeStamp
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}
