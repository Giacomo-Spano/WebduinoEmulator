﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Heater : Sensor
    {
        public String status;
        public String releStatus;

        public override String getJSON()
        {
            String json = "";
            json += "{";
            json += "\"status\":\"";
            json += status + "\"";
            json += ",\"relestatus\":\"";
            json += releStatus + "\"";
            json += ",\"name\":\"";
            json += sensorname + "\"";
            json += ",\"type\":\"heater\"";
            json += ",\"addr\":\"";
            json += getSensorAddress() + "\"}";
            return json;
        }
    }
}
