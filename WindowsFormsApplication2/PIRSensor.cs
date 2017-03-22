using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class PIRSensor : Sensor
    {
        public bool motionDetected;

        public override String getJSON()
        {
            String json = "";
            json += "{";
            json += "\"motiondetected\":";
            if (motionDetected)
                json += "true";
            else
                json += "false";
            json += ",\"name\":\"";
            json += sensorname + "\"";
            json += ",\"type\":\"pirsensor\"";
            json += ",\"addr\":\"";
            json += getSensorAddress() + "\"}";
            return json;
        }

        bool getMotionDetected()
        {
            return motionDetected;
        }
    }
}
