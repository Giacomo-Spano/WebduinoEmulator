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

        public CurrentSensor()
        {
            type = "currentsensor";
        }

        public override String getJSON()
        {
            String json = "";
            json += "{";
            json += getCommonJSONFields();

            json += ",\"current\":";
            json += current;

            json += "}";
            return json;
        }

        public float getCurrent()
        {
            return current;
        }
    }
}
