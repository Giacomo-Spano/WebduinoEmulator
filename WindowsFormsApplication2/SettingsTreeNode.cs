using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{

    class SettingsTreeNode : TreeNode
    {
        public Settings settings;


        public SettingsTreeNode(String name)
        {
            this.Text = name;
            //this.shield = shield;
        }
    }
}
