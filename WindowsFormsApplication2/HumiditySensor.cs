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

        public HumiditySensor()
        {
            type = "humiditysensor";
        }

        public override String getJSON()
        {
            String json = "";
            json += "{";
            json += getCommonJSONFields();

            json += ",\"humidity\":";
            json += humidity;

            json += "}";
            return json;
        }
        
        public float getHumidity()
        {
            return humidity;
        }
    }
}
