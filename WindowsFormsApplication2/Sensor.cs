using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Sensor
    {
        public String nodeId;
        public String address;
        public bool enabled;
        public String type;

        public Sensor()
        {
            type = "sensor";
        }

        virtual public String getJSON()
        {
            return "";
        }

        public String getCommonJSONFields()
        {
            String json = "";
            json += "\"name\":\"";
            json += sensorname + "\"";
            json += ",\"type\":\"";
            json += type + "\"";
            json += ",\"enabled\":";
            json += enabled ? "true" : "false";
            json += ",\"addr\":\"";
            json += getSensorAddress() + "\"";
            return json;
        }
        public String getSensorAddress()
        {
            return address;
        }

        public void setSensorAddress(String address)
        {
            this.address = address;
        }

        public String sensorname = "sensorname";
        //int sensorAddr[8]; // indirizzi sensori

    };
}
