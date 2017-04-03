using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class DoorSensor : Sensor
    {
        private bool statusOpen;

        public DoorSensor()
        {
            type = "doorsensor";
        }

        public override String getJSON()
        {
            String json = "";
            json += "{";
            json += getCommonJSONFields();

            json += ",\"statusopen\":";
            json += (statusOpen) ? "true" : "false";

            json += "}";
            return json;
        }

        public bool getStatusOpen()
        {
            return statusOpen;
        }
        public void setStatusOpen(bool status)
        {
            statusOpen = status;
        }
    }
}
