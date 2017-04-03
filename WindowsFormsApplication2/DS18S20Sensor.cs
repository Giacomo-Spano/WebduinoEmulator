using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class DS18S20Sensor : Sensor
    {
        public float temperature;
        public float avTemperature;

        public DS18S20Sensor()
        {
            type = "temperature";
        }

        public override String getJSON()
        {
            String json = "";
            json += "{";
            json += getCommonJSONFields();

            json += ",\"temperature\":";
            json += getTemperature();
            json += ",\"avtemperature\":";
            json += getAvTemperature();

            json += "}";
            return json;
        }

        float getTemperature()
        {
            return temperature;
        }

        float getAvTemperature()
        {
            return avTemperature;
        }
    }
}
