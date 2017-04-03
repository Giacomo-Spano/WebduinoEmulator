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

        public PressureSensor()
        {
            type = "pressuresensor";
        }

        public override String getJSON()
        {
            String json = "";
            json += "{";
            json += getCommonJSONFields();

            json += ",\"pressure\":";
            json += pressure;

            json += "}";
            return json;
        }
        
        public float getPressure()
        {
            return pressure;
        }
    }
}
