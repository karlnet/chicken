﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deviceSim
{
    public enum TelemetryTypes
    {
        A = 0, B = 1, C = 2
    }

    public enum DCAC
    {
        DC = 0, AC = 1
    }

    public class TelemetryData
    {
        static Random random = new System.Random();
        public object data { get; set; }
        public string timestamp { get; set; }
        //public TelemetryTypes Type { get; set; }
        public string deviceId { get; set; }
        //public string UID { get; set; }
        //public DCAC DCorAC { get; set; }
        //public string ADSLor3G { get; set; }
        //public string Message { get; set; }
        public static TelemetryData Random(string seqNo, string msg)
        {
            var ret = new TelemetryData()
            {
                data = new { temp1 = random.Next(20, 40), temp2 = random.Next(20, 40), temp3 = random.Next(20, 40), Rh = random.Next(50, 71), weight = random.Next(10, 20) /10.0,fan=1,pressure=random.Next(0,10)/10.0, power= 60 },
                timestamp = string.Format("{0:G}", DateTime.Now),
                //Type = (TelemetryTypes)random.Next(0, 2),
                deviceId = "10010001"
                //UID = "UID-" + Guid.NewGuid().ToString(),
                //DCorAC = (DCAC)random.Next(0, 1),
                //ADSLor3G = random.Next(100) >= 50 ? "ADSL" : "3G",
                //Message = msg
            };
            return ret;
        }
    }

}
