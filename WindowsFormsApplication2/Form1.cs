using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using BrightIdeasSoftware;
using System.Diagnostics;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private Thread trd;

        TreeNode currentNode;
        Settings settings = new Settings();

        private int iconHome = 0;
        private int iconCheck = 1;
        private int iconCancel = 2;
        private int iconTemperature = 3;
        private int iconHeater = 4;
        private int iconDoorSensor = 5;
        private int iconReleActuator = 6;
        private int iconCurrentSensor = 7;
        private int iconHumiditySensor = 8;
        private int iconPressureSensor = 9;
        private int iconPIRSensor = 10;

        // shield
        const String property_ShieldName = "shieldName";
        const String property_ShieldStarted = "shieldStarted";
        const String property_ShieldId = "shieldId";
        const String property_MACAddress = "MACAddress";
        const String property_Port = "localport";
        const String property_TemperatureSensorEnabled = "TemperatureSensorEnabled";

        // sensor
        const String property_SensorName = "sensorName";
        // ds18s20 sensor
        const String property_TemperatureSensor_Temperature = "temperaturesensor_temperature";
        // Current sensor
        const String property_CurrentSensor_Current = "currentsensor_current";
        // Humidity sensor
        const String property_HumiditySensor_Current = "humiditysensor_humidity";
        // Pressure sensor
        const String property_PressureSensor_Current = "pressuresensor_pressure";
        // PIR sensor
        const String property_PIRSensor_Current = "pirsensor_motiondetected";
        // Door sensor
        const String property_DoorSensor_Opne = "doorsensor_open";

        //actuator
        const String property_ActuatorName = "actuatorName";
        const String property_ServerIp = "serverIp";
        const String property_ServerPort = "serverPort";
        //heater actuator
        const String property_HeaterStatus = "actuatorName";
        const String property_ReleStatus = "actuatorName";
        const String property_Program = "actuatorName";
        //rele actuator
        const String property_Rele_OpenStatus = "releactuator_open";





        const string fileName = "C:\\scratch\\streamtest.txt";
        public static Shields shields = new Shields();

        Shield shield = new Shield();

        string clickedNode;
        MenuItem myMenuItem;
        ContextMenu mnu = new ContextMenu();

        public List<ShieldProperty> propertyList = new List<ShieldProperty>();

        public Form1()
        {
            InitializeComponent();

            // Create an instance of a MenuItem with caption and an array of submenu
            // items specified.
            myMenuItem = new MenuItem("Add");

            //myMenuItem.Click += new EventHandler(myMenuItem_Click);
            myMenuItem.MenuItems.Add("Temperature Sensor", new EventHandler(addTemperatureSensor_Click));
            myMenuItem.MenuItems.Add("Door Sensor", new EventHandler(addDoorSensor_Click));

            myMenuItem.MenuItems.Add("Current Sensor", new EventHandler(addCurrentSensor_Click));
            myMenuItem.MenuItems.Add("Humidity Sensor", new EventHandler(addHumiditySensor_Click));
            myMenuItem.MenuItems.Add("Pressure Sensor", new EventHandler(addPressureSensor_Click));
            myMenuItem.MenuItems.Add("PIR Sensor", new EventHandler(addPIRSensor_Click));

            myMenuItem.MenuItems.Add("Heater", new EventHandler(addHeaterActuator_Click));
            myMenuItem.MenuItems.Add("Rele actuator", new EventHandler(addReleActuator_Click));

            myMenuItem.MenuItems.Add("Shield", new EventHandler(addShield_Click));
            mnu.MenuItems.Add(myMenuItem);

            mnu.MenuItems.Add("Remove").Click += new EventHandler(remove_Click); ;

        }

        void addHeaterActuator_Click(object sender, EventArgs e)
        {
            Heater heater = new Heater();
            heater.nodeId = Guid.NewGuid().ToString();
            heater.sensorname = "heater " + heater.nodeId;
            heater.setSensorAddress(DateTime.Now.ToString("yy:MM:dd:hh:mm:ss"));
            if (currentNode != null && currentNode is ShieldTreeNode)
            {
                Shield shield = shields.shieldFromNodeId((String)currentNode.Tag);
                shield.actuatorList.Add(heater);
            }
            InitializeTreeView();
        }

        void addReleActuator_Click(object sender, EventArgs e)
        {
            ReleActuator rele = new ReleActuator();
            rele.nodeId = Guid.NewGuid().ToString();
            rele.sensorname = "heater " + rele.nodeId;
            rele.setSensorAddress(DateTime.Now.ToString("yy:MM:dd:hh:mm:ss"));
            if (currentNode != null && currentNode is ShieldTreeNode)
            {
                Shield shield = shields.shieldFromNodeId((String)currentNode.Tag);
                shield.actuatorList.Add(rele);
            }
            InitializeTreeView();
        }

        void addTemperatureSensor_Click(object sender, EventArgs e)
        {
            DS18S20Sensor sensor = new DS18S20Sensor();
            sensor.nodeId = Guid.NewGuid().ToString();
            sensor.sensorname = "temperature sensor ";
            sensor.setSensorAddress(DateTime.Now.ToString("yy:MM:dd:hh:mm:ss"));
            if (currentNode != null && currentNode is ShieldTreeNode)
            {
                Shield shield = shields.shieldFromNodeId((String)currentNode.Tag);
                shield.sensorList.Add(sensor);
            }
            InitializeTreeView();
        }

        void addDoorSensor_Click(object sender, EventArgs e)
        {
            DoorSensor sensor = new DoorSensor();
            sensor.nodeId = Guid.NewGuid().ToString();
            sensor.sensorname = "door sensor ";
            sensor.setSensorAddress(DateTime.Now.ToString("yy:MM:dd:hh:mm:ss"));
            if (currentNode != null && currentNode is ShieldTreeNode)
            {
                Shield shield = shields.shieldFromNodeId((String)currentNode.Tag);
                shield.sensorList.Add(sensor);
            }
            InitializeTreeView();
        }

        void addCurrentSensor_Click(object sender, EventArgs e)
        {
            CurrentSensor sensor = new CurrentSensor();
            sensor.nodeId = Guid.NewGuid().ToString();
            sensor.sensorname = "Current sensor ";
            sensor.setSensorAddress(DateTime.Now.ToString("yy:MM:dd:hh:mm:ss"));
            if (currentNode != null && currentNode is ShieldTreeNode)
            {
                Shield shield = shields.shieldFromNodeId((String)currentNode.Tag);
                shield.sensorList.Add(sensor);
            }
            InitializeTreeView();
        }

        void addHumiditySensor_Click(object sender, EventArgs e)
        {
            HumiditySensor sensor = new HumiditySensor();
            sensor.nodeId = Guid.NewGuid().ToString();
            sensor.sensorname = "humidity sensor ";
            sensor.setSensorAddress(DateTime.Now.ToString("yy:MM:dd:hh:mm:ss"));
            if (currentNode != null && currentNode is ShieldTreeNode)
            {
                Shield shield = shields.shieldFromNodeId((String)currentNode.Tag);
                shield.sensorList.Add(sensor);
            }
            InitializeTreeView();
        }

        void addPressureSensor_Click(object sender, EventArgs e)
        {
            PressureSensor sensor = new PressureSensor();
            sensor.nodeId = Guid.NewGuid().ToString();
            sensor.sensorname = "pressure sensor ";
            sensor.setSensorAddress(DateTime.Now.ToString("yy:MM:dd:hh:mm:ss"));
            if (currentNode != null && currentNode is ShieldTreeNode)
            {
                Shield shield = shields.shieldFromNodeId((String)currentNode.Tag);
                shield.sensorList.Add(sensor);
            }
            InitializeTreeView();
        }

        void addPIRSensor_Click(object sender, EventArgs e)
        {
            PIRSensor sensor = new PIRSensor();
            sensor.nodeId = Guid.NewGuid().ToString();
            sensor.sensorname = "PIR sensor ";
            sensor.setSensorAddress(DateTime.Now.ToString("yy:MM:dd:hh:mm:ss"));
            if (currentNode != null && currentNode is ShieldTreeNode)
            {
                Shield shield = shields.shieldFromNodeId((String)currentNode.Tag);
                shield.sensorList.Add(sensor);
            }
            InitializeTreeView();
        }

        void addShield_Click(object sender, EventArgs e)
        {
            shield = new Shield();
            Guid guid = Guid.NewGuid();
            shield.nodeId = Guid.NewGuid().ToString();
            shield.shieldName = "shield " + shield.nodeId;
            shield.localPort = "80";
            shield.MACAddress = DateTime.Now.ToString("yy:MM:dd:hh:mm:ss");
            shields.shieldList.Add(shield);
            InitializeTreeView();
        }

        void remove_Click(object sender, EventArgs e)
        {
            if (currentNode is ShieldTreeNode)
            {
                shields.removeShield((String)currentNode.Tag);
                treeView1.Nodes.Remove(treeView1.SelectedNode);
            }
            else if (currentNode is SensorTreeNode)
            {
                shields.removeSensor((String)currentNode.Tag);
                treeView1.Nodes.Remove(treeView1.SelectedNode);
            }
            else if (currentNode is ActuatorTreeNode)
            {
                shields.removeActuator((String)currentNode.Tag);
                treeView1.Nodes.Remove(treeView1.SelectedNode);
            }
        }



        //public Alpha oAlpha = new Alpha();
        private void Form1_Load(object sender, System.EventArgs e)
        {

            //Thread trd = new Thread(new ThreadStart(this.ThreadTask));
            /*Thread trd = new Thread(new ThreadStart(oAlpha.Beta));
            trd.IsBackground = true;
            trd.Start();*/
            /*Alpha oAlpha = new Alpha();
            oAlpha.port = "8001";
            Thread trd = new Thread(new ThreadStart(oAlpha.Beta));
            trd.IsBackground = true;
            trd.Start();*/

            load();

            shields.setup();
            timer1.Interval = 20000; // specify interval time as you want
            //t.Tick += new EventHandler(timer_Tick);
            timer1.Start();

            objectListView1.ButtonClick += cellButtonClick;
        }

        public void cellButtonClick(object sender, CellClickEventArgs e)
        {
            Debug.WriteLine(String.Format("Button clicked: ({0}, {1}, {2})", e.RowIndex, e.SubItem, e.Model));

            // Take some action on e.Model based on which button (e.ColumnIndex) was clicked

            ShieldProperty property = (ShieldProperty)e.Model;
            if (property.Name.Equals(property_TemperatureSensor_Temperature))
            {

                Shield shield = shields.shieldFromNodeId(property.NodeId);
                shield.sendSensorsStatus();
            }
            else if (property.Name.Equals(property_ShieldId))
            {
                Shield shield = shields.shieldFromNodeId(property.NodeId);
                shield.registerShield();
            }
            // If something about the object changed, you probably want to refresh the model
            this.objectListView1.RefreshObject(e.Model);
        }

        /*private void ThreadTask()
        {

            WebServer ws = new WebServer(SendResponse, "http://192.168.1.3:8000/webduino/");
            ws.start();

            ws.Run();

            //WebServer ws2 = new WebServer(SendResponse, "http://192.168.1.3:8001/webduino/");
            //ws2.Run();

        }*/

        public class Alpha
        {
            public String port = "8000";
            public String localIP = "192.168.1.3";
            public String nodeId;
            // This method that will be called when the thread is started
            public void Beta()
            {
                Shield shield = shields.shieldFromNodeId(nodeId);
                WebServer ws = new WebServer(SendResponse, "http://" + localIP + ":" + port + "/");
                if (ws.start())
                {
                    ws.Run();
                    if (shield != null)
                        shield.started = true;
                }
                else
                {
                    if (shield != null)
                        shield.started = false;
                }

            }


            public string SendResponse(HttpListenerRequest request)
            {
                if (request.HttpMethod == "POST")
                {
                    var body = new StreamReader(request.InputStream).ReadToEnd();
                }

                if (request.RawUrl.Equals("/temperaturesensorstatus"))
                {
                    Shield shield = shields.shieldFromNodeId(nodeId);
                    return string.Format("<HTML><BODY>My web page.<br>{0}</BODY></HTML>", DateTime.Now);
                }

                return string.Format("<HTML><BODY>My web page.<br>{0}</BODY></HTML>", DateTime.Now);
            }
        };

        public static string SendStatusResponse(HttpListenerRequest request)
        {
            if (request.HttpMethod == "POST")
            {
                var body = new StreamReader(request.InputStream).ReadToEnd();
            }

            return string.Format("<HTML><BODY>My web page.<br>{0}</BODY></HTML>", DateTime.Now);
        }



        private void InitializeTreeView()
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();

            SettingsTreeNode settingsNode = new SettingsTreeNode("Settings");
            settingsNode.settings = settings;
            settingsNode.ImageIndex = iconHome;
            settingsNode.SelectedImageIndex = iconHome;
            treeView1.Nodes.Add(settingsNode);

            foreach (Shield shield in shields.shieldList)
            {
                ShieldTreeNode shieldNode = new ShieldTreeNode(shield);
                shieldNode.Tag = shield.nodeId;
                if (shield.started)
                {
                    shieldNode.ImageIndex = iconCheck;
                    shieldNode.SelectedImageIndex = iconCheck;
                }
                else
                {
                    shieldNode.ImageIndex = iconCancel;
                    shieldNode.SelectedImageIndex = iconCancel;
                }

                foreach (Sensor sensor in shield.sensorList)
                {
                    SensorTreeNode sensorNode = new SensorTreeNode(sensor);
                    sensorNode.shieldNodeId = shield.nodeId;
                    sensorNode.Tag = sensor.nodeId;

                    int sensorIconIndex = 0;
                    if (sensor is DS18S20Sensor)
                    {
                        sensorIconIndex = iconTemperature;
                    }
                    else if (sensor is DoorSensor)
                    {
                        sensorIconIndex = iconDoorSensor;
                    }
                    else if (sensor is CurrentSensor)
                    {
                        sensorIconIndex = iconCurrentSensor;
                    }
                    else if (sensor is PIRSensor)
                    {
                        sensorIconIndex = iconPIRSensor;
                    }
                    else if (sensor is HumiditySensor)
                    {
                        sensorIconIndex = iconHumiditySensor;
                    }
                    else if (sensor is PressureSensor)
                    {
                        sensorIconIndex = iconPressureSensor;
                    }
                    sensorNode.ImageIndex = sensorIconIndex;
                    sensorNode.SelectedImageIndex = sensorIconIndex;

                    shieldNode.Nodes.Add(sensorNode);
                }
                foreach (Sensor actuator in shield.actuatorList)
                {
                    ActuatorTreeNode actuatorNode = new ActuatorTreeNode(actuator);
                    actuatorNode.shieldNodeId = shield.nodeId;
                    actuatorNode.Tag = actuator.nodeId;
                    int sensorIconIndex = 0;
                    if (actuator is Heater)
                    {
                        sensorIconIndex = iconHeater;
                    } else if (actuator is ReleActuator)
                    {
                        sensorIconIndex = iconReleActuator;
                    }
                    actuatorNode.ImageIndex = sensorIconIndex;
                    actuatorNode.SelectedImageIndex = sensorIconIndex;

                    shieldNode.Nodes.Add(actuatorNode);
                }

                treeView1.Nodes[0].Nodes.Add(shieldNode);
            }

            treeView1.EndUpdate();

            treeView1.ExpandAll();
        }



        protected void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //currentNode = null;
            this.objectListView1.ClearObjects();
            propertyList = new List<ShieldProperty>();
            currentNode = e.Node;

            if (e.Node is ShieldTreeNode)
            {
                ShieldTreeNode node = (ShieldTreeNode)e.Node;
                Shield shield = shields.shieldFromNodeId((String)node.Tag);
                // name
                ShieldProperty sp = new ShieldProperty();
                sp.Name = property_ShieldName;
                sp.Description = "Shield name";
                sp.Value = shield.shieldName;
                propertyList.Add(sp);
                // started
                sp = new ShieldProperty();
                sp.Name = property_ShieldStarted;
                sp.Description = "Scheda avviata";
                if (shield.started)
                    sp.Value = "Started";
                else
                    sp.Value = "Not Started";
                propertyList.Add(sp);
                objectListView1.DisableObject(sp);
                // id
                sp = new ShieldProperty();
                sp.Name = property_ShieldId;
                sp.Description = "Shield id";
                sp.Value = "" + shield.id;
                sp.Action = "register";
                propertyList.Add(sp);
                // port
                sp = new ShieldProperty();
                sp.Name = property_Port;
                sp.Description = "local port";
                sp.Value = "" + shield.localPort;
                propertyList.Add(sp);
                // mac addrress
                sp = new ShieldProperty();
                sp.Name = property_MACAddress;
                sp.Description = "MAC Address";
                sp.Value = shield.MACAddress;
                propertyList.Add(sp);
                // temperaturesensorsenabled
                sp = new ShieldProperty();
                sp.Name = property_TemperatureSensorEnabled;
                sp.Description = "Temperature sensor enabled";
                if (shield.temperatureSensorsEnabled)
                    sp.Value = "Enabled";
                else
                    sp.Value = "Disabled";
                propertyList.Add(sp);
            }
            else if (e.Node is SensorTreeNode)
            {
                SensorTreeNode node = (SensorTreeNode)e.Node;
                Shield shield = shields.shieldFromNodeId(node.shieldNodeId);
                Sensor sensor = shield.sensorFromNodeId((String)node.Tag);

                ShieldProperty sp = new ShieldProperty();
                sp.NodeId = node.shieldNodeId;
                sp.Name = property_SensorName;
                sp.Description = "Sensor name";
                sp.Value = sensor.sensorname;
                propertyList.Add(sp);

                if (sensor is DS18S20Sensor)
                {
                    sp = new ShieldProperty();
                    sp.NodeId = node.shieldNodeId;
                    sp.Name = property_TemperatureSensor_Temperature;
                    sp.Description = "Temperature";
                    DS18S20Sensor dsSensor = (DS18S20Sensor)sensor;
                    sp.Value = "" + dsSensor.temperature;
                    sp.Action = "Update";

                    propertyList.Add(sp);
                }
            }
            else if (e.Node is ActuatorTreeNode)
            {
                ActuatorTreeNode node = (ActuatorTreeNode)e.Node;
                Shield shield = shields.shieldFromNodeId(node.shieldNodeId);
                Sensor actuator = shield.actuatorFromNodeId((String)node.Tag);

                ShieldProperty sp = new ShieldProperty();
                sp.NodeId = node.shieldNodeId;
                sp.Name = property_ActuatorName;
                sp.Description = "Actuator name";
                sp.Value = actuator.sensorname;
                propertyList.Add(sp);
            }
            else if (e.Node is SettingsTreeNode)
            {
                SettingsTreeNode node = (SettingsTreeNode)e.Node;

                ShieldProperty sp = new ShieldProperty();
                sp.Name = property_ServerIp;
                sp.Value = Settings.serverIpAddress;
                sp.Description = "Server Ip Address";
                propertyList.Add(sp);
                sp = new ShieldProperty();
                sp.Name = property_ServerPort;
                sp.Description = "Server Port";
                sp.Value = "" + Settings.serverPort;
                propertyList.Add(sp);
            }

            this.objectListView1.SetObjects(propertyList);
            this.objectListView1.Refresh();
        }

        private void sendSensorStatusButton_Click_1(object sender, EventArgs e)
        {
            shield.sendSensorsStatus();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                currentNode = e.Node;
                if (e.Node is ShieldTreeNode)
                {
                    clickedNode = e.Node.Name;
                    mnu.Show(treeView1, e.Location);
                    ShieldTreeNode shieldNode = (ShieldTreeNode)e.Node;
                }
                else
                {
                    clickedNode = e.Node.Name;
                    mnu.Show(treeView1, e.Location);
                    TreeNode shieldNode = e.Node;
                }
            }
            else if (e.Button == MouseButtons.Left)
            {

            }
        }

        private void saveShields(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            String str = "{ \"settings\":{";

            str += "\"serverip\":\"";
            str += Settings.serverIpAddress;
            str += "\"";

            str += ",\"port\":";
            str += Settings.serverPort;

            str += "}";

            str += ",\"shields\":";

            String jsonarray = "[";
            int i = 0;
            foreach (Shield shield in shields.shieldList)
            {

                String json = shield.getShieldJSON();

                if (i++ != 0)
                    jsonarray += ",";
                jsonarray += json;

            }
            jsonarray += "]";

            str += jsonarray + "}";

            try
            {
                System.IO.FileStream wFile;
                byte[] byteData = null;
                byteData = Encoding.ASCII.GetBytes(str);

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                wFile = new FileStream(fileName, FileMode.CreateNew);
                wFile.Write(byteData, 0, byteData.Length);
                wFile.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void loadShields(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            byte[] buffer;

            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                try
                {
                    int length = (int)fileStream.Length;  // get file length
                    buffer = new byte[length];            // create buffer
                    int count;                            // actual number of bytes read
                    int sum = 0;                          // total number of bytes read

                    // read until Read method returns 0 (end of the stream has been reached)
                    while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                        sum += count;  // sum is a buffer offset for next reading
                }
                finally
                {
                    fileStream.Close();
                }

                string result = System.Text.Encoding.UTF8.GetString(buffer);

                JObject strJson = JObject.Parse(result);

                String strSettings = strJson.GetValue("settings").ToString();
                JObject jsonSettings = JObject.Parse(strSettings);
                Settings.serverIpAddress = (String)jsonSettings.GetValue("serverip");
                Settings.serverPort = Int32.Parse((String)jsonSettings.GetValue("port"));

                String strShields = strJson.GetValue("shields").ToString();
                JArray jarray = JArray.Parse(strShields);
                foreach (JObject json in jarray)
                {
                    Shield shield = new Shield();
                    shield.nodeId = Guid.NewGuid().ToString();
                    shield.shieldName = (String)json.GetValue("shieldName");
                    shield.MACAddress = (String)json.GetValue("MAC");
                    shield.localPort = (String)json.GetValue("localPort");
                    if (json.GetValue("temperatureSensorsEnabled") != null)
                        shield.temperatureSensorsEnabled = (bool)json.GetValue("temperatureSensorsEnabled");
                    else
                        shield.temperatureSensorsEnabled = false;

                    JArray sensors = (JArray)json.GetValue("sensors");
                    foreach (JObject sensor in sensors)
                    {
                        Sensor newSensor;
                        String type = (String)sensor.GetValue("type");
                        if (type.Equals("temperature"))
                        {
                            newSensor = new DS18S20Sensor();
                        }
                        else if (type.Equals("doorsensor"))
                        {
                            newSensor = new DoorSensor();
                        }
                        else if (type.Equals("pressuresensor"))
                        {
                            newSensor = new PressureSensor();
                        }
                        else if (type.Equals("humiditysensor"))
                        {
                            newSensor = new HumiditySensor();
                        }
                        else if (type.Equals("currentsensor"))
                        {
                            newSensor = new CurrentSensor();
                        }
                        else
                        {
                            continue;
                        }
                        newSensor.nodeId = Guid.NewGuid().ToString();
                        newSensor.sensorname = (String)sensor.GetValue("name");
                        newSensor.setSensorAddress((String)sensor.GetValue("addr"));
                        shield.sensorList.Add(newSensor);
                    }

                    JArray actuators = (JArray)json.GetValue("actuators");
                    foreach (JObject actuator in actuators)
                    {
                        Sensor newActuator;
                        String type = (String)actuator.GetValue("type");
                        if (type.Equals("heater"))
                        {
                            newActuator = new Heater();
                        }
                        else if (type.Equals("releactuator"))
                        {
                            newActuator = new ReleActuator();
                        }
                        else
                        {
                            continue;
                        }
                        newActuator.nodeId = Guid.NewGuid().ToString();
                        newActuator.sensorname = (String)actuator.GetValue("name");
                        newActuator.setSensorAddress((String)actuator.GetValue("addr"));
                        shield.actuatorList.Add(newActuator);                        
                    }


                    shields.shieldList.Add(shield);
                    //InitializeTreeView();

                    shield.oAlpha.port = shield.localPort;
                    shield.localIP = shield.oAlpha.localIP;
                    shield.oAlpha.nodeId = shield.nodeId;
                    Thread trd = new Thread(new ThreadStart(shield.oAlpha.Beta));
                    trd.IsBackground = true;
                    trd.Start();

                    shield.registerShield();

                }
            }
            catch (Exception e)
            {
                ///fileStream.Close();
            }
            InitializeTreeView();

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void objectListView1_CellEditValidating(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {

        }

        private void objectListView1_CellEditFinished(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (currentNode != null && e.Column.Text.Equals("Value"))
            {
                if (currentNode is ShieldTreeNode)
                {
                    ShieldTreeNode node = (ShieldTreeNode)currentNode;
                    Shield shield = shields.shieldFromNodeId((String)node.Tag);

                    ShieldProperty property = (ShieldProperty)e.RowObject;
                    if (property.Name.Equals(property_ShieldName))
                    {
                        shield.shieldName = (string)e.NewValue;
                    }
                    else if (property.Name.Equals(property_MACAddress))
                    {
                        shield.MACAddress = (string)e.NewValue;
                    }
                    else if (property.Name.Equals(property_Port))
                    {
                        shield.localPort = (string)e.NewValue;
                    }
                    else if (property.Name.Equals(property_TemperatureSensorEnabled))
                    {
                        if (e.NewValue.Equals("Enabled"))
                        {
                            shield.temperatureSensorsEnabled = true;
                        }
                        else
                        {
                            shield.temperatureSensorsEnabled = false;
                        }
                    }

                }
                else if (currentNode is SensorTreeNode)
                {
                    SensorTreeNode node = (SensorTreeNode)currentNode;
                    Shield shield = shields.shieldFromNodeId(node.shieldNodeId);
                    Sensor sensor = shield.sensorFromNodeId((String)node.Tag);

                    ShieldProperty property = (ShieldProperty)e.RowObject;
                    if (property.Name.Equals(property_SensorName))
                    {
                        sensor.sensorname = (string)e.NewValue;
                    }
                    else if (sensor is DS18S20Sensor)
                    {
                        DS18S20Sensor tempSensor = (DS18S20Sensor)sensor;
                        if (property.Name.Equals(property_TemperatureSensor_Temperature))
                        {
                            tempSensor.temperature = float.Parse((string)e.NewValue);
                        }
                    }

                }
                else if (currentNode is ActuatorTreeNode)
                {
                    ActuatorTreeNode node = (ActuatorTreeNode)currentNode;
                    Shield shield = shields.shieldFromNodeId(node.shieldNodeId);
                    Sensor actuator = shield.sensorFromNodeId((String)node.Tag);

                    ShieldProperty property = (ShieldProperty)e.RowObject;
                    if (property.Name.Equals(property_ActuatorName))
                    {
                        actuator.sensorname = (string)e.NewValue;
                    }

                }
                else if (currentNode is SettingsTreeNode)
                {
                    SettingsTreeNode node = (SettingsTreeNode)currentNode;
                    ShieldProperty property = (ShieldProperty)e.RowObject;
                    if (property.Name.Equals(property_ServerIp))
                    {
                        Settings.serverIpAddress = (string)e.NewValue;
                        Settings.serverIpAddress = (string)e.NewValue;
                    }
                    else if (property.Name.Equals(property_ServerPort))
                    {
                        Settings.serverPort = Int32.Parse((string)e.NewValue);
                    }
                }
            }


        }

        private void registerButton_Click_1(object sender, EventArgs e)
        {
            int id = shield.registerShield();

            shieldIdTextBox.Text = "" + id;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void objectListView1_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (e.Column.Text.Equals("Value") && e.ListViewItem.Text.Equals(property_TemperatureSensorEnabled))
            {

                ComboBox cb = new ComboBox();
                cb.Bounds = e.CellBounds;
                cb.Font = ((ObjectListView)sender).Font;
                cb.DropDownStyle = ComboBoxStyle.DropDownList;
                cb.Items.Add("Enabled");
                cb.Items.Add("Disabled");
                cb.SelectedIndex = 0; // should select the entry that reflects the current value
                e.Control = cb;
            }
        }

        private void objectListView1_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                string value = ((ComboBox)e.Control).SelectedItem.ToString();
                if (e.Column.Text.Equals("Value"))
                {
                    //((ShieldProperty)e.RowObject).Value = value; // does not update value
                    //objectListView1.UpdateObjects(propertyList);
                    e.NewValue = value;
                }

            }


        }
    }
}
