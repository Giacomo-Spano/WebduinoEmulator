using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class CurrentSensor : Sensor
    {
        public float current;

        public override String getJSON()
        {
            String json = "";
            json += "{";
            json += "\"current\":";
            json += current;
            json += ",\"name\":\"";
            json += sensorname + "\"";
            json += ",\"type\":\"currentsensor\"";
            json += ",\"addr\":\"";
            json += getSensorAddress() + "\"}";
            return json;
        }

        public float getCurrent()
        {
            return current;
        }
    }
}
