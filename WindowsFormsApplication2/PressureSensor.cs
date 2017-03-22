using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class PressureSensor : Sensor
    {
        public float pressure;

        public override String getJSON()
        {
            String json = "";
            json += "{";
            json += "\"pressure\":";
            json += pressure;
            json += ",\"name\":\"";
            json += sensorname + "\"";
            json += ",\"type\":\"pressuresensor\"";
            json += ",\"addr\":\"";
            json += getSensorAddress() + "\"}";
            return json;
        }

        public float getPressure()
        {
            return pressure;
        }
    }
}
