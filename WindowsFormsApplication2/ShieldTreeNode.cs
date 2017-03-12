﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{

    class ShieldTreeNode : TreeNode
    {
        public Shield shield;

        public ShieldTreeNode(Shield shield)
        {
            this.Text = "shield-"+shield.nodeId;
            this.shield = shield;
        }
    }
}
