using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class ShieldProperty
    {
        public ShieldProperty()
        {
        }
        private String nodeId;
        private String started;
        private String name ;
        private String value;
        private String description;
        private String action;
        private String temperatureSensorEnabled;

        public string NodeId
        {
            get
            {
                return nodeId;
            }

            set
            {
                this.nodeId = value;
            }
        }

        public string Started
        {
            get
            {
                return started;
            }

            set
            {
                this.started = value;
            }
        }

        public string TemperatureSensorEnabled
        {
            get
            {
                return temperatureSensorEnabled;
            }

            set
            {
                this.temperatureSensorEnabled = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                this.name = value;
            }
        }

        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public string Action
        {
            get
            {
                return action;
            }

            set
            {
                action = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }
    }
}
