using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Heater : Sensor
    {
        public String status;
        public bool releStatus;

        public Heater()
        {
            type = "Heater";
        }

        public override String getJSON()
        {
            String json = "";
            json += "{";
            json += getCommonJSONFields();

            json += ",\"status\":\"";
            json += status + "\"";
            json += ",\"relestatus\":\"";
            json += releStatus ? "true" : "false";

            json += "\"}";
            return json;
        }

    }
}
