namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.Property = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.descriptionColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Value = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Action = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(201, 345);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "001-home.png");
            this.imageList1.Images.SetKeyName(1, "check.png");
            this.imageList1.Images.SetKeyName(2, "cancel.png");
            this.imageList1.Images.SetKeyName(3, "014-networking.png");
            this.imageList1.Images.SetKeyName(4, "009-hot.png");
            this.imageList1.Images.SetKeyName(5, "logout.png");
            this.imageList1.Images.SetKeyName(6, "001-switch.png");
            this.imageList1.Images.SetKeyName(7, "001-ray.png");
            this.imageList1.Images.SetKeyName(8, "003-humidity.png");
            this.imageList1.Images.SetKeyName(9, "004-pressure-indicator.png");
            this.imageList1.Images.SetKeyName(10, "002-presence-indicator.png");
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(784, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 33);
            this.button2.TabIndex = 5;
            this.button2.Text = "save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.saveShields);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(712, 353);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(66, 32);
            this.button3.TabIndex = 6;
            this.button3.Text = "load";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.loadShields);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.objectListView1);
            this.splitContainer1.Size = new System.Drawing.Size(856, 345);
            this.splitContainer1.SplitterDistance = 201;
            this.splitContainer1.TabIndex = 7;
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.Property);
            this.objectListView1.AllColumns.Add(this.descriptionColumn);
            this.objectListView1.AllColumns.Add(this.Value);
            this.objectListView1.AllColumns.Add(this.Action);
            this.objectListView1.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Property,
            this.descriptionColumn,
            this.Value,
            this.Action});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.GridLines = true;
            this.objectListView1.HasCollapsibleGroups = false;
            this.objectListView1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.objectListView1.Location = new System.Drawing.Point(0, 0);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(651, 345);
            this.objectListView1.TabIndex = 8;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.objectListView1_CellEditFinished);
            this.objectListView1.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.objectListView1_CellEditFinishing);
            this.objectListView1.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.objectListView1_CellEditStarting);
            this.objectListView1.CellEditValidating += new BrightIdeasSoftware.CellEditEventHandler(this.objectListView1_CellEditValidating);
            // 
            // Property
            // 
            this.Property.AspectName = "Name";
            this.Property.IsEditable = false;
            this.Property.Text = "Name";
            this.Property.Width = 94;
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.AspectName = "Description";
            this.descriptionColumn.IsEditable = false;
            this.descriptionColumn.Text = "Description";
            this.descriptionColumn.Width = 292;
            // 
            // Value
            // 
            this.Value.AspectName = "Value";
            this.Value.Text = "Value";
            this.Value.Width = 68;
            // 
            // Action
            // 
            this.Action.AspectName = "Action";
            this.Action.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.Action.IsButton = true;
            this.Action.IsEditable = false;
            this.Action.Text = "Action";
            this.Action.Width = 96;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 392);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn Property;
        private BrightIdeasSoftware.OLVColumn Value;
        private BrightIdeasSoftware.OLVColumn Action;
        private BrightIdeasSoftware.OLVColumn descriptionColumn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
    }
}

