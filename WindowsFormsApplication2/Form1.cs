using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using JamesWright.SimpleHttp;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        private Thread trd;

        TreeNode currentNode;

        const string fileName = "C:\\Users\\gs163400\\Documents\\temp\\streamtest.txt";
        Shields shields = new Shields();

        Shield shield = new Shield();
        //public List<Shield> shieldList = new List<Shield>();

        string clickedNode;
        MenuItem myMenuItem;// = new MenuItem("Show Me");

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
            myMenuItem.MenuItems.Add("Heater", new EventHandler(addHeater_Click));
            myMenuItem.MenuItems.Add("Shield", new EventHandler(addShield_Click));
            mnu.MenuItems.Add(myMenuItem);

            /*myMenuItem = new MenuItem("Remove");
            //myMenuItem.Click += new EventHandler(myMenuItem_Click);
            myMenuItem.MenuItems.Add("Sensor", new EventHandler(Removepicture_Click));
            myMenuItem.MenuItems.Add("Adapter", new EventHandler(Addpicture_Click));
            mnu.MenuItems.Add(myMenuItem);*/

            mnu.MenuItems.Add("Remove").Click += new EventHandler(remove_Click); ;

        }

        void addHeater_Click(object sender, EventArgs e)
        {
            Heater heater = new Heater();
            Guid guid = Guid.NewGuid();
            heater.nodeId = guid.ToString();
            heater.sensorname = "heater " + heater.nodeId;
            if (currentNode != null && currentNode is ShieldTreeNode)
            {
                Shield shield = shields.shieldFromNodeId((String)currentNode.Tag);
                shield.actuatorList.Add(heater);
            }
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

        void addTemperatureSensor_Click(object sender, EventArgs e)
        {
            DS18S20Sensor sensor = new DS18S20Sensor();
            Guid guid = Guid.NewGuid();
            sensor.nodeId = guid.ToString();
            sensor.sensorname = "temperature sensor " + sensor.nodeId;
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
            shield.nodeId = guid.ToString();
            shield.shieldName = "shield " + shield.nodeId;
            shields.shieldList.Add(shield);
            InitializeTreeView();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            Thread trd = new Thread(new ThreadStart(this.ThreadTask));
            trd.IsBackground = true;
            trd.Start();

            /*Shield shield = new Shield();
            shield.shieldName = "sield1";
            shield.nodeId = "1";
            shields.shieldList.Add(shield);

            shield = new Shield();
            shield.shieldName = "sield2";
            shield.nodeId = "2";
            shields.shieldList.Add(shield);

            shield = new Shield();
            shield.shieldName = "sield3";
            shield.nodeId = "3";
            shields.shieldList.Add(shield);*/

            load();

            //InitializeTreeView();
        }

        private void ThreadTask()
        {
            App app = new App();

            app.Get("/", async (req, res) =>
            {
                res.Content = "<p>You did a GET.</p>";
                res.ContentType = "text/html";
                await res.SendAsync();
            });

            app.Post("/", async (req, res) =>
            {
                res.Content = "<p>You did a POST: " + await req.GetBodyAsync() + "</p>";
                res.ContentType = "text/html";
                await res.SendAsync();
            });

            app.Put("/", async (req, res) =>
            {
                res.Content = "<p>You did a PUT: " + await req.GetBodyAsync() + "</p>";
                res.ContentType = "text/html";
                await res.SendAsync();
            });

            app.Delete("/", async (req, res) =>
            {
                res.Content = "<p>You did a DELETE: " + await req.GetBodyAsync() + "</p>";
                res.ContentType = "text/html";
                await res.SendAsync();
            });

            app.Start();


        }

        private void InitializeTreeView()
        {
            treeView1.BeginUpdate();

            treeView1.Nodes.Clear();

            treeView1.Nodes.Add("Shields");

            foreach (Shield shield in shields.shieldList)
            {
                ShieldTreeNode node = new ShieldTreeNode(shield);

                node.Tag = shield.nodeId;

                foreach (Sensor sensor in shield.sensorList)
                {
                    SensorTreeNode sensorNode = new SensorTreeNode(sensor);
                    node.Nodes.Add(sensorNode);
                }
                foreach (Sensor actuator in shield.actuatorList)
                {
                    ActuatorTreeNode actuatorNode = new ActuatorTreeNode(actuator);
                    node.Nodes.Add(actuatorNode);
                }

                treeView1.Nodes[0].Nodes.Add(node);
            }

            treeView1.EndUpdate();

            treeView1.ExpandAll();
        }

        protected void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            currentNode = null;
            this.objectListView1.ClearObjects();
            propertyList = new List<ShieldProperty>();
            currentNode = e.Node;

            if (e.Node is ShieldTreeNode)
            {
                ShieldTreeNode node = (ShieldTreeNode)e.Node;
                ShieldProperty sp = new ShieldProperty();
                sp.Name = "name";
                sp.Value = node.shield.shieldName;
                propertyList.Add(sp);

            }
            else if (e.Node is SensorTreeNode)
            {
                SensorTreeNode node = (SensorTreeNode)e.Node;
                ShieldProperty sp = new ShieldProperty();
                sp.Name = "Sensor name";
                sp.Value = node.sensor.sensorname;
                propertyList.Add(sp);
            }
            else if (e.Node is ActuatorTreeNode)
            {
                ActuatorTreeNode node = (ActuatorTreeNode)e.Node;

                ShieldProperty sp = new ShieldProperty();
                sp.Name = "Actuator name";
                sp.Value = node.actuator.sensorname;
                propertyList.Add(sp);
            }

            this.objectListView1.SetObjects(propertyList);

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            int id = shield.registerShield();

            shieldIdTextBox.Text = "" + id;
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

            try
            {
                System.IO.FileStream wFile;
                byte[] byteData = null;
                byteData = Encoding.ASCII.GetBytes(jsonarray);
                wFile = new FileStream(fileName, FileMode.CreateNew | FileMode.Truncate);
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

                JArray jarray = JArray.Parse(result);

                foreach (JObject json in jarray)
                {
                    Shield shield = new Shield();
                    shield.shieldName = (String)json.GetValue("shieldName");

                    JArray sensors = (JArray)json.GetValue("sensors");
                    foreach (JObject sensor in sensors)
                    {
                        {
                            String type = (String)sensor.GetValue("type");
                            if (type.Equals("temperature"))
                            {
                                DS18S20Sensor tempSensor = new DS18S20Sensor();
                                tempSensor.sensorname = (String)sensor.GetValue("sensorname");

                                shield.sensorList.Add(tempSensor);
                            }
                        }
                    }
                    shields.shieldList.Add(shield);
                }
            }
            catch
            {
                ///fileStream.Close();
            }

            InitializeTreeView();
        }

        private void SerializeList()
        {
            // Create an instance of System.Xml.Serialization.XmlSerializer
            XmlSerializer serializer = new XmlSerializer(shields.GetType());

            // Create an instance of System.IO.TextWriter 
            // to save the serialized object to disk
            TextWriter textWriter = new StreamWriter("C:\\Users\\gs163400\\Documents\\temp\\prova.xml");

            // Serialize the employeeList object
            serializer.Serialize(textWriter, shields);

            // Close the TextWriter
            textWriter.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void objectListView1_CellEditValidating(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {

        }

        private void objectListView1_CellEditFinished(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (currentNode != null)
            {
                if (currentNode is ShieldTreeNode)
                {
                    ShieldTreeNode node = (ShieldTreeNode)currentNode;
                    foreach (ShieldProperty property in propertyList)
                    {
                        if (property.Name.Equals("name"))
                        {
                            node.shield.shieldName = property.Value;
                        }
                    }
                }
                else if (currentNode is SensorTreeNode)
                {
                    SensorTreeNode node = (SensorTreeNode)currentNode;
                    foreach (ShieldProperty property in propertyList)
                    {
                        if (property.Name.Equals("Sensor name"))
                        {
                            node.sensor.sensorname = property.Value;
                        }
                    }
                }
                else if (currentNode is ActuatorTreeNode)
                {
                    ActuatorTreeNode node = (ActuatorTreeNode)currentNode;
                    foreach (ShieldProperty property in propertyList)
                    {
                        if (property.Name.Equals("Actuator name"))
                        {
                            node.actuator.sensorname = property.Value;
                        }
                    }
                }
            }
        }
    }
}
