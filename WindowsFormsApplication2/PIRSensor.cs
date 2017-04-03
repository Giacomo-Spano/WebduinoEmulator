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

        public PIRSensor()
        {
            type = "pirsensor";
        }

        public override String getJSON()
        {
            String json = "";
            json += "{";
            json += getCommonJSONFields();

            json += ",\"motiondetected\":";
            json += (motionDetected) ? "true" : json += "false";

            json += "}";
            return json;
        }

        bool getMotionDetected()
        {
            return motionDetected;
        }
    }
}
