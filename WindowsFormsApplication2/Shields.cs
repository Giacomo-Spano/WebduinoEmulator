using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace WindowsFormsApplication2
{
    public class Shields //: System.ComponentModel.INotifyPropertyChanged
    {
        public List<Shield> shieldList = new List<Shield>();

        public void setup()
        {
            foreach (Shield shield in shieldList)
            {
                //int id = shield.registerShield();

            }
        }

        public void loop(String nodeId)
        {
            foreach (Shield shield in shieldList)
            {
                shield.checkStatus();
            }
        }

        public bool removeShield(String nodeId)
        {
            Shield shield = shieldFromNodeId(nodeId);
            if (shield != null)
            {
                shieldList.Remove(shield);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Shield shieldFromNodeId(String nodeId)
        {
            foreach (Shield shield in shieldList)
            {
                if (shield.nodeId == nodeId)
                {
                    return shield;
                }
            }
            return null;
        }

        public Shield shieldFromId(int id)
        {
            foreach (Shield shield in shieldList)
            {
                if (shield.id == id)
                {
                    return shield;
                }
            }
            return null;
        }

        public bool removeSensor(String nodeId)
        {
            foreach (Shield shield in shieldList)
            {
                foreach (Sensor sensor in shield.sensorList)
                {
                    if (sensor.nodeId == nodeId)
                    {
                        shield.sensorList.Remove(sensor);
                        return true;
                    }
                }
            }
            return false;
        }
        
        public bool removeActuator(String nodeId)
        {
            foreach (Shield shield in shieldList)
            {
                foreach (Sensor actuator in shield.actuatorList)
                {
                    if (actuator.nodeId == nodeId)
                    {
                        shield.actuatorList.Remove(actuator);
                        return true;
                    }
                }
            }
            return false;
        }

        internal Shield shieldFromId(object shielId)
        {
            throw new NotImplementedException();
        }

        /*        internal void setup()
                {
                    throw new NotImplementedException();
                }*/
    }
}
