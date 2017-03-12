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
        

        public String getJSON()
        {
            String json = "";
            json += "{";
            json += "\"temperature\":";
            //json += Util::floatToString(temperature);
            json += getTemperature();
            json += ",\"avtemperature\":";
            //json += Util::floatToString(avTemperature);
            json += getAvTemperature();
            json += ",\"name\":\"";
            json += sensorname + "\"";
            json += ",\"type\":\"temperature\"";
            json += ",\"addr\":\"";
            json += getSensorAddress() + "\"}";
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
