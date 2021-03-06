﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace STM_PC_1.StmConn.Configuration
{
    class StmConfig
    {
        public int UdpEndpointPort { get; set; }
        public string WindowType { get; set; }
        public long AmplitudeSamplingDelay { get; set; }
        public int SamplingFrequency { get; set; }
        public string UdpEndpointIP { get; set; }

        public StmConfig()
        {
            WindowType = "";
            UdpEndpointIP = "";
            AmplitudeSamplingDelay = 0;
            SamplingFrequency = 0;
            UdpEndpointPort = 0;
        }

        public String toString()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(this);
        }

        static public StmConfig parse(string jsonMsg)
        {
            JavaScriptSerializer deserializer = new JavaScriptSerializer();
            return (StmConfig)deserializer.Deserialize(jsonMsg, typeof(StmConfig));
        }
    }
}
