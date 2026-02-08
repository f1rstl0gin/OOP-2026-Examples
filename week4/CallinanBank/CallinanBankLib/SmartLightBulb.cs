using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallinanBankLib
{
    public class SmartLightBulb : SmartDevice
    {
        public SmartLightBulb(string deviceId, string name) : base(deviceId, name)
        {
        }

        public override string GetStatus()
        {
            return $"SmartLightBulb '{Name}' (ID: {DeviceId}) is {(IsOnline ? "Online" : "Offline")} and {(IsPoweredOn ? "On" : "Off")}.";
        }
    }
}
