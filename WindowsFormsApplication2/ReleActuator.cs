using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class ReleActuator : Sensor
    {
        public bool releOn;

        public ReleActuator()
        {
            type = "releactuator";
        }

        public override String getJSON()
        {
            String json = "";
            json += "{";
            json += getCommonJSONFields();

            json += "\"releon\":";
            json +=  (releOn) ? "true" : "false";

            json += "}";
            return json;
        }

    }
}
