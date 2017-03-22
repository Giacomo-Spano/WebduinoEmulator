using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class DoorSensor : Sensor
    {
        public bool statusOpen;

        public override String getJSON()
        {
            String json = "";
            json += "{";
            json += "\"statusopen\":";
            if (statusOpen)
                json += "true";
            else
                json += "false";
            json += ",\"name\":\"";
            json += sensorname + "\"";
            json += ",\"type\":\"doorsensor\"";
            json += ",\"addr\":\"";
            json += getSensorAddress() + "\"}";
            return json;
        }

        bool getStatusOpen()
        {
            return statusOpen;
        }
    }
}
