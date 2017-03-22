using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static WindowsFormsApplication2.Form1;

namespace WindowsFormsApplication2
{

    public class Shield
    {

        public String nodeId;
        public Alpha oAlpha = new Alpha();
        public bool started;

        const int D0 = 16;
        const int D1 = 5;
        const int D2 = 4;
        const int D3 = 0;
        const int D4 = 2;
        const int D5 = 14;
        const int D6 = 12;
        const int D7 = 13;
        const int D8 = 15;
        const int D9 = 3;
        const int D10 = 1;
        String swVersion;

        const int maxIoDevices = 10; // queste sono le porte
        const int maxIoDeviceTypes = 3;  // mweusti sono i tipi di device
        const int ioDevices_Disconnected = 0;
        const int ioDevices_Heater = 1;
        const int ioDevices_OneWireSensors = 2;

        public int id;// = 0; // inizializzato a zero perchè viene impostato dalla chiamata a registershield
        public String MACAddress = "00:01:02:03:04:05";
        public String localPort;
        public String shieldName;
        public bool heaterEnabled;
        public bool temperatureSensorsEnabled;

        static int oneWirePin;
        static int heaterPin; // pin rele heater
        static String powerStatus; // power
        static String lastRestartDate;


        /*String sendHeaterSettingsCommand(JSON json);
        String sendTemperatureSensorsSettingsCommand(JSON json);
        String sendShieldSettingsCommand(JSON jsonStr);
        String sendPowerCommand(JSON jsonStr);
        String sendRegisterCommand(JSON jsonStr);
        String sendResetCommand(JSON jsonStr);
        void checkActuatorsStatus();
        void checkSensorsStatus();*/

        public void checkStatus()
        {
            checkActuatorsStatus();
            checkSensorsStatus();
        }

        void checkActuatorsStatus()
        {
        }

        void checkSensorsStatus()
        {
        }


        public Sensor sensorFromNodeId(String nodeId)
        {
            foreach (Sensor sensor in sensorList)
            {
                if (sensor.nodeId == nodeId)
                {
                    return sensor;
                }
            }
            return null;
        }

        public Sensor actuatorFromNodeId(String nodeId)
        {
            foreach (Sensor sensor in actuatorList)
            {
                if (sensor.nodeId == nodeId)
                {
                    return sensor;
                }
            }
            return null;
        }


        String networkSSID;
        String networkPassword;
        String serverName;//[serverNameLen];
        int serverPort;


        /*ESPDisplay display;
        TFTDisplay tftDisplay;*/

        //List sensorList;
        //List ActuatorList;

        public List<Sensor> sensorList = new List<Sensor>();

        public List<Sensor> actuatorList = new List<Sensor>();
        public string localIP;
        //internal string port;

        public Shield()
        {
            //sensorList.Add(new DS18S20Sensor());
            //sensorList.Add(new DS18S20Sensor());

            //actuatorList.Add(new DS18S20Sensor());
        }


        /*String getSensorsStatusJson();
        String getActuatorsStatusJson();
        String getHeaterStatusJson();
        String getSettingsJson();
        void checkStatus();
        String sendCommand(String jsonStr);*/

        String getSensorsStatusJson()
        {
            String json = "{";
            json += "\"id\":" + id;// shieldid

            json += ",\"temperaturesensorsenabled\":";
            if (getTemperatureSensorsEnabled() == true)
                json += "true";
            else
                json += "false";
            json += ",\"temperaturesensorspin\":\"" + getStrOneWirePin() + "\"";


            json += ",\"sensors\":[";

            if (getTemperatureSensorsEnabled() == true)
            {
                int i = 0;
                foreach (Sensor sensor in sensorList)
                {
                    DS18S20Sensor temperatureSensor = (DS18S20Sensor)sensor;
                    if (i++ != 0)
                        json += ",";
                    json += temperatureSensor.getJSON();
                }
            }

            json += "]";
            json += "}";

            return json;
        }

        /*bool getTemperatureSensorsEnabled()
        {
            return temperatureSensorsEnabled;
        }

        static void setTemperatureSensorsEnabled(bool enabled)
        {
            temperatureSensorsEnabled = enabled;

        }*/

        int getShieldId() { return id; } // static member function

        String getLastRestartDate() { return lastRestartDate; }

        void setLastRestartDate(String date) { lastRestartDate = date; }

        String getIoDevicesTypeName(int type)
        {
            switch (type)
            {
                case 0:
                    return "disconnected";
                case 1:
                    return "Heater";
                case 2:
                    return "OneWire dallasSensors";
            }

            return "empty";
        }


        int getServerPort()
        {
            return serverPort;
        }

        void setServerPort(int port)
        {
            serverPort = port;
        }

        int getHeaterPin()
        {
            return heaterPin;
        }

        /*String getStrHeaterPin()
        {
            if (heaterPin == D0)
                return "D0";
            if (heaterPin == D1)
                return "D1";
            if (heaterPin == D2)
                return "D2";
            if (heaterPin == D3)
                return "D3";
            if (heaterPin == D4)
                return "D4";
            if (heaterPin == D5)
                return "D5";
            if (heaterPin == D6)
                return "D6";
            if (heaterPin == D7)
                return "D7";
            if (heaterPin == D8)
                return "D8";
            if (heaterPin == D9)
                return "D9";
            if (heaterPin == D10)
                return "D10";
        }*/


        String getStrOneWirePin()
        {
            if (oneWirePin == D0)
                return "D0";
            if (oneWirePin == D1)
                return "D1";
            if (oneWirePin == D2)
                return "D2";
            if (oneWirePin == D3)
                return "D3";
            if (oneWirePin == D4)
                return "D4";
            if (oneWirePin == D5)
                return "D5";
            if (oneWirePin == D6)
                return "D6";
            if (oneWirePin == D7)
                return "D7";
            if (oneWirePin == D8)
                return "D8";
            if (oneWirePin == D9)
                return "D9";
            if (oneWirePin == D10)
                return "D10";

            return "invalid";
        }


        void setHeaterPin(int pin)
        {
            heaterPin = pin;
        }

        int getOneWirePin()
        {
            return oneWirePin;
        }

        void setOneWirePin(int pin)
        {
            oneWirePin = pin;
        }

        bool getHeaterEnabled()
        {
            return heaterEnabled;
        }

        void setHeaterEnabled(bool enabled)
        {
            heaterEnabled = enabled;
        }

        bool getTemperatureSensorsEnabled()
        {
            return temperatureSensorsEnabled;
        }

        void setTemperatureSensorsEnabled(bool enabled)
        {
            temperatureSensorsEnabled = enabled;

        }

        String getLocalPort()
        {
            return localPort;
        }

        void setLocalPort(String port)
        {
            localPort = port;
        }

        String getNetworkSSID()
        {
            return networkSSID;
        }

        void setNetworkSSID(String ssid)
        {
            //logger.print(tag, "\n\t >>setNetworkSSID: " + ssid);
            networkSSID = ssid;
            //logger.print(tag, "\n\t networkSSID="+ networkSSID);
        }

        String getNetworkPassword()
        {

            return networkPassword;
        }

        void setNetworkPassword(String password)
        {
            //logger.print(tag, "\n\t >>setNetworkPassword: " + password);
            networkPassword = password;
            //logger.print(tag, "\n\t networkPassword=" + networkPassword);
        }

        String getServerName()
        {
            return serverName;
        }

        void setServerName(String name)
        {
            serverName = name;
        }

        String getShieldName()
        {
            return shieldName;
        }

        void setShieldName(String name)
        {
            shieldName = name;
        }

        String getPowerStatus()
        {
            return powerStatus;
        }

        void setPowerStatus(String status)
        {
            powerStatus = status;
        }

        public bool sendSensorsStatus()
        {
            if (getShieldId() == 0)
            {
                return false;
            }

            String str = getSensorsStatusJson();
            HttpHelper hplr = new HttpHelper();
            hplr.sendPost(Settings.serverIpAddress, Settings.serverPort, "webduino/sensor", str);

            return true;
        }

        public int registerShield()
        {
            String str = "{";
            str += "\"event\":\"register\",";

            str += "\"shield\": ";
            str += "{";
            str += "\"MAC\":\"" + MACAddress + "\"";
            str += ",\"shieldName\":\"" + getShieldName() + "\"";
            str += ",\"localIP\":\"" + localIP + "\"";
            str += ",\"localport\":\"" + getLocalPort() + "\"";

            // sensori
            str += ",\"sensors\":[";
            int i = 0;
            foreach (Sensor sensor in sensorList)
            {
                /*if (temperatureSensorsEnabled)
                {*/
                    //DS18S20Sensor temperatureSensor = (DS18S20Sensor)sensor;
                    if (i != 0)
                        str += ",";
                    str += sensor.getJSON();
                    i++;
                //}
            }
            str += "]";

            // attuatori
            str += ",\"actuators\":[";
            //str += hearterActuator.getJSON();
            str += "]";
            str += "}";

            str += "}";

            HttpHelper hplr = new HttpHelper();

            try
            {
                String result = hplr.sendPost(Settings.serverIpAddress, Settings.serverPort, "webduino/shield", str);


                dynamic jsonResult = JObject.Parse(result);
                id = jsonResult.id;

                //oAlpha.shieldId = id;//

               
                return id;

            }
            catch (Exception e)
            {
                
                return -1;
            }
        }


        public String getShieldJSON()
        {
            String str = "{";

            str += "\"MAC\":\"" + MACAddress + "\"";
            str += ",\"shieldName\":\"" + getShieldName() + "\"";
            str += ",\"localIP\":\"" + localIP + "\"";
            str += ",\"localPort\":\"" + getLocalPort() + "\"";
            if (temperatureSensorsEnabled)
                str += ",\"temperatureSensorsEnabled\":true";
            else
                str += ",\"temperatureSensorsEnabled\":false";

            // sensori
            str += ",\"sensors\":[";
            int nSensors = 0;
            foreach (Sensor sensor in sensorList)
            {
                if (nSensors++ != 0)
                        str += ",";
                    str += sensor.getJSON();
            }
            str += "]";

            // attuatori
            str += ",\"actuators\":[";
            int nActuators = 0;
            foreach (Sensor actuator in actuatorList)
            {
                if (nActuators++ != 0)
                    str += ",";
                str += actuator.getJSON();
            }
            str += "]";

            str += "}";

            return str;
        }

    };
}
