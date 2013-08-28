namespace PicKit2_Script_Editor
{
    partial class fmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPartWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importPartWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPIC24r2ChipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageScripts = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.propertyGridScript = new System.Windows.Forms.PropertyGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewScript = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridHex = new System.Windows.Forms.DataGridView();
            this.listScripts = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.duplicateScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageDevices = new System.Windows.Forms.TabPage();
            this.propertyGridDevice = new System.Windows.Forms.PropertyGrid();
            this.groupBoxDeviceInfo = new System.Windows.Forms.GroupBox();
            this.lblDeviceFamily = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblDeviceVdd = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFlashSize = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDeviceId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.treeViewDevices = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageScripts.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScript)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHex)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPageDevices.SuspendLayout();
            this.groupBoxDeviceInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "dat";
            this.openFileDialog1.FileName = "PK2DeviceFile.dat";
            this.openFileDialog1.Filter = "PK2DeviceFile|*.dat|All files|*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(574, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "scriptItemMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(111, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(111, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPartWizardToolStripMenuItem,
            this.importPartWizardToolStripMenuItem,
            this.addPIC24r2ChipsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // newPartWizardToolStripMenuItem
            // 
            this.newPartWizardToolStripMenuItem.Name = "newPartWizardToolStripMenuItem";
            this.newPartWizardToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.newPartWizardToolStripMenuItem.Text = "New Part Wizard";
            this.newPartWizardToolStripMenuItem.Click += new System.EventHandler(this.newPartWizardToolStripMenuItem_Click);
            // 
            // importPartWizardToolStripMenuItem
            // 
            this.importPartWizardToolStripMenuItem.Name = "importPartWizardToolStripMenuItem";
            this.importPartWizardToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.importPartWizardToolStripMenuItem.Text = "Import Part Wizard";
            this.importPartWizardToolStripMenuItem.Visible = false;
            this.importPartWizardToolStripMenuItem.Click += new System.EventHandler(this.importPartWizardToolStripMenuItem_Click);
            // 
            // addPIC24r2ChipsToolStripMenuItem
            // 
            this.addPIC24r2ChipsToolStripMenuItem.Name = "addPIC24r2ChipsToolStripMenuItem";
            this.addPIC24r2ChipsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.addPIC24r2ChipsToolStripMenuItem.Text = "Add PIC24r2 Chips";
            this.addPIC24r2ChipsToolStripMenuItem.Click += new System.EventHandler(this.addPIC24r2ChipsToolStripMenuItem_Click_1);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageDevices);
            this.tabControl1.Controls.Add(this.tabPageScripts);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(550, 495);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPageScripts
            // 
            this.tabPageScripts.Controls.Add(this.groupBox1);
            this.tabPageScripts.Controls.Add(this.listScripts);
            this.tabPageScripts.Location = new System.Drawing.Point(4, 22);
            this.tabPageScripts.Name = "tabPageScripts";
            this.tabPageScripts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScripts.Size = new System.Drawing.Size(542, 469);
            this.tabPageScripts.TabIndex = 0;
            this.tabPageScripts.Text = "Scripts";
            this.tabPageScripts.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.propertyGridScript);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dataGridViewScript);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridHex);
            this.groupBox1.Location = new System.Drawing.Point(193, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 457);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Script";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Properties";
            // 
            // propertyGridScript
            // 
            this.propertyGridScript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGridScript.HelpVisible = false;
            this.propertyGridScript.Location = new System.Drawing.Point(13, 32);
            this.propertyGridScript.Name = "propertyGridScript";
            this.propertyGridScript.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridScript.Size = new System.Drawing.Size(317, 73);
            this.propertyGridScript.TabIndex = 9;
            this.propertyGridScript.ToolbarVisible = false;
            this.propertyGridScript.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGridScript_PropertyValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Parsed Script (READ ONLY)";
            // 
            // dataGridViewScript
            // 
            this.dataGridViewScript.AllowUserToAddRows = false;
            this.dataGridViewScript.AllowUserToDeleteRows = false;
            this.dataGridViewScript.AllowUserToResizeColumns = false;
            this.dataGridViewScript.AllowUserToResizeRows = false;
            this.dataGridViewScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewScript.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewScript.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridViewScript.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewScript.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewScript.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewScript.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewScript.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewScript.Location = new System.Drawing.Point(13, 225);
            this.dataGridViewScript.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewScript.Name = "dataGridViewScript";
            this.dataGridViewScript.RowHeadersVisible = false;
            this.dataGridViewScript.RowHeadersWidth = 75;
            this.dataGridViewScript.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewScript.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewScript.RowTemplate.Height = 17;
            this.dataGridViewScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewScript.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewScript.Size = new System.Drawing.Size(317, 221);
            this.dataGridViewScript.TabIndex = 7;
            this.dataGridViewScript.SelectionChanged += new System.EventHandler(this.dataGridViewScript_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Raw Script Data";
            // 
            // dataGridHex
            // 
            this.dataGridHex.AllowUserToAddRows = false;
            this.dataGridHex.AllowUserToDeleteRows = false;
            this.dataGridHex.AllowUserToResizeColumns = false;
            this.dataGridHex.AllowUserToResizeRows = false;
            this.dataGridHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridHex.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridHex.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridHex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridHex.ColumnHeadersVisible = false;
            this.dataGridHex.Location = new System.Drawing.Point(13, 124);
            this.dataGridHex.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridHex.Name = "dataGridHex";
            this.dataGridHex.RowHeadersVisible = false;
            this.dataGridHex.RowHeadersWidth = 75;
            this.dataGridHex.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridHex.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridHex.RowTemplate.Height = 17;
            this.dataGridHex.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridHex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridHex.Size = new System.Drawing.Size(317, 80);
            this.dataGridHex.TabIndex = 5;
            this.dataGridHex.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridHex_CellValueChanged);
            // 
            // listScripts
            // 
            this.listScripts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listScripts.ContextMenuStrip = this.contextMenuStrip1;
            this.listScripts.FormattingEnabled = true;
            this.listScripts.Location = new System.Drawing.Point(8, 12);
            this.listScripts.Name = "listScripts";
            this.listScripts.Size = new System.Drawing.Size(179, 446);
            this.listScripts.TabIndex = 4;
            this.listScripts.SelectedIndexChanged += new System.EventHandler(this.listScripts_SelectedIndexChanged);
            this.listScripts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listScripts_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.duplicateScriptToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(158, 26);
            // 
            // duplicateScriptToolStripMenuItem
            // 
            this.duplicateScriptToolStripMenuItem.Name = "duplicateScriptToolStripMenuItem";
            this.duplicateScriptToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.duplicateScriptToolStripMenuItem.Text = "Duplicate Script";
            this.duplicateScriptToolStripMenuItem.Click += new System.EventHandler(this.duplicateScriptToolStripMenuItem_Click);
            // 
            // tabPageDevices
            // 
            this.tabPageDevices.Controls.Add(this.propertyGridDevice);
            this.tabPageDevices.Controls.Add(this.groupBoxDeviceInfo);
            this.tabPageDevices.Controls.Add(this.treeViewDevices);
            this.tabPageDevices.Location = new System.Drawing.Point(4, 22);
            this.tabPageDevices.Name = "tabPageDevices";
            this.tabPageDevices.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDevices.Size = new System.Drawing.Size(542, 469);
            this.tabPageDevices.TabIndex = 1;
            this.tabPageDevices.Text = "Devices";
            this.tabPageDevices.UseVisualStyleBackColor = true;
            // 
            // propertyGridDevice
            // 
            this.propertyGridDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGridDevice.Location = new System.Drawing.Point(207, 103);
            this.propertyGridDevice.Name = "propertyGridDevice";
            this.propertyGridDevice.Size = new System.Drawing.Size(317, 360);
            this.propertyGridDevice.TabIndex = 2;
            this.propertyGridDevice.ToolbarVisible = false;
            this.propertyGridDevice.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGridDevice_PropertyValueChanged);
            // 
            // groupBoxDeviceInfo
            // 
            this.groupBoxDeviceInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDeviceInfo.Controls.Add(this.lblDeviceFamily);
            this.groupBoxDeviceInfo.Controls.Add(this.label10);
            this.groupBoxDeviceInfo.Controls.Add(this.lblDeviceVdd);
            this.groupBoxDeviceInfo.Controls.Add(this.label8);
            this.groupBoxDeviceInfo.Controls.Add(this.lblFlashSize);
            this.groupBoxDeviceInfo.Controls.Add(this.label6);
            this.groupBoxDeviceInfo.Controls.Add(this.lblDeviceId);
            this.groupBoxDeviceInfo.Controls.Add(this.label3);
            this.groupBoxDeviceInfo.Location = new System.Drawing.Point(207, 6);
            this.groupBoxDeviceInfo.Name = "groupBoxDeviceInfo";
            this.groupBoxDeviceInfo.Size = new System.Drawing.Size(317, 91);
            this.groupBoxDeviceInfo.TabIndex = 1;
            this.groupBoxDeviceInfo.TabStop = false;
            this.groupBoxDeviceInfo.Text = "Device Info";
            // 
            // lblDeviceFamily
            // 
            this.lblDeviceFamily.AutoSize = true;
            this.lblDeviceFamily.Location = new System.Drawing.Point(103, 16);
            this.lblDeviceFamily.Name = "lblDeviceFamily";
            this.lblDeviceFamily.Size = new System.Drawing.Size(10, 13);
            this.lblDeviceFamily.TabIndex = 7;
            this.lblDeviceFamily.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Family";
            // 
            // lblDeviceVdd
            // 
            this.lblDeviceVdd.AutoSize = true;
            this.lblDeviceVdd.Location = new System.Drawing.Point(103, 67);
            this.lblDeviceVdd.Name = "lblDeviceVdd";
            this.lblDeviceVdd.Size = new System.Drawing.Size(10, 13);
            this.lblDeviceVdd.TabIndex = 5;
            this.lblDeviceVdd.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Vdd";
            // 
            // lblFlashSize
            // 
            this.lblFlashSize.AutoSize = true;
            this.lblFlashSize.Location = new System.Drawing.Point(103, 50);
            this.lblFlashSize.Name = "lblFlashSize";
            this.lblFlashSize.Size = new System.Drawing.Size(10, 13);
            this.lblFlashSize.TabIndex = 3;
            this.lblFlashSize.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Flash Size";
            // 
            // lblDeviceId
            // 
            this.lblDeviceId.AutoSize = true;
            this.lblDeviceId.Location = new System.Drawing.Point(103, 33);
            this.lblDeviceId.Name = "lblDeviceId";
            this.lblDeviceId.Size = new System.Drawing.Size(10, 13);
            this.lblDeviceId.TabIndex = 1;
            this.lblDeviceId.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Device ID";
            // 
            // treeViewDevices
            // 
            this.treeViewDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewDevices.Location = new System.Drawing.Point(8, 12);
            this.treeViewDevices.Name = "treeViewDevices";
            this.treeViewDevices.Size = new System.Drawing.Size(193, 451);
            this.treeViewDevices.TabIndex = 0;
            this.treeViewDevices.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDevices_AfterSelect);
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 534);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fmMain";
            this.Text = "PicKit2 Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageScripts.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScript)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHex)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPageDevices.ResumeLayout(false);
            this.groupBoxDeviceInfo.ResumeLayout(false);
            this.groupBoxDeviceInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPartWizardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageScripts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewScript;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridHex;
        private System.Windows.Forms.ListBox listScripts;
        private System.Windows.Forms.ToolStripMenuItem importPartWizardToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem duplicateScriptToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid propertyGridScript;
        private System.Windows.Forms.TabPage tabPageDevices;
        private System.Windows.Forms.TreeView treeViewDevices;
        private System.Windows.Forms.GroupBox groupBoxDeviceInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDeviceFamily;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblDeviceVdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblFlashSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDeviceId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PropertyGrid propertyGridDevice;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPIC24r2ChipsToolStripMenuItem;
    }
}

