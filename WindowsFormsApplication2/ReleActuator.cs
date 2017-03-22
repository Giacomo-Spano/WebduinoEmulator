using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class ReleActuator : Sensor
    {
        public bool releOn;

        public override String getJSON()
        {
            String json = "";
            json += "{";
            json += "\"releon\":";
            if (releOn)
                json += "true";
            else
                json += "false";
            json += ",\"name\":\"";
            json += sensorname + "\"";
            json += ",\"type\":\"releactuator\"";
            json += ",\"addr\":\"";
            json += getSensorAddress() + "\"}";
            return json;
        }
    }
}
