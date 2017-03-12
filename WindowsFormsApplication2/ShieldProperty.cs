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

        private String name ;
        private String value = "xxx";
        private int action;

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

        public int Action
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
    }
}
