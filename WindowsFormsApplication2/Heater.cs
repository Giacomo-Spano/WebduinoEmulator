using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Heater : Sensor
    {
        
        public String getJSON()
        {
            String json = "";
            json += "{";
            json += ",\"name\":\"";
            json += sensorname + "\"";
            json += ",\"type\":\"heater\"";
            json += ",\"addr\":\"";
            json += getSensorAddress() + "\"}";
            return json;
        }
    }
}
