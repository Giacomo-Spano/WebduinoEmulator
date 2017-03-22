using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class HumiditySensor : Sensor
    {
        public float humidity;

        public override String getJSON()
        {
            String json = "";
            json += "{";
            json += "\"humidity\":";
            json += humidity;
            json += ",\"name\":\"";
            json += sensorname + "\"";
            json += ",\"type\":\"humiditysensor\"";
            json += ",\"addr\":\"";
            json += getSensorAddress() + "\"}";
            return json;
        }

        public float getHumidity()
        {
            return humidity;
        }
    }
}
