namespace PicKit2_Script_Editor
{
    partial class fmPartWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmPartWizard));
            this.cbBasePart = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDeviceFamily = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFlashSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeviceId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.iconArrow = new System.Windows.Forms.PictureBox();
            this.txtConfigAddr = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtConfigMasks = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtConfigDefaults = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // cbBasePart
            // 
            this.cbBasePart.FormattingEnabled = true;
            this.cbBasePart.Location = new System.Drawing.Point(176, 87);
            this.cbBasePart.Name = "cbBasePart";
            this.cbBasePart.Size = new System.Drawing.Size(161, 21);
            this.cbBasePart.TabIndex = 2;
            this.cbBasePart.SelectedIndexChanged += new System.EventHandler(this.cbBasePart_SelectedIndexChanged);
            this.cbBasePart.Enter += new System.EventHandler(this.cbBasePart_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Pick a similar part to copy";
            // 
            // cbDeviceFamily
            // 
            this.cbDeviceFamily.FormattingEnabled = true;
            this.cbDeviceFamily.Location = new System.Drawing.Point(176, 38);
            this.cbDeviceFamily.Name = "cbDeviceFamily";
            this.cbDeviceFamily.Size = new System.Drawing.Size(161, 21);
            this.cbDeviceFamily.TabIndex = 1;
            this.cbDeviceFamily.SelectedIndexChanged += new System.EventHandler(this.cbDeviceFamily_SelectedIndexChanged);
            this.cbDeviceFamily.Enter += new System.EventHandler(this.cbDeviceFamily_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Device Family";
            // 
            // txtFlashSize
            // 
            this.txtFlashSize.Location = new System.Drawing.Point(176, 224);
            this.txtFlashSize.Name = "txtFlashSize";
            this.txtFlashSize.Size = new System.Drawing.Size(161, 20);
            this.txtFlashSize.TabIndex = 5;
            this.txtFlashSize.TextChanged += new System.EventHandler(this.txtFlashSize_TextChanged);
            this.txtFlashSize.Enter += new System.EventHandler(this.txtFlashSize_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(173, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Flash Size (Hexadecimal)";
            // 
            // txtDeviceId
            // 
            this.txtDeviceId.Location = new System.Drawing.Point(176, 185);
            this.txtDeviceId.Name = "txtDeviceId";
            this.txtDeviceId.Size = new System.Drawing.Size(161, 20);
            this.txtDeviceId.TabIndex = 4;
            this.txtDeviceId.TextChanged += new System.EventHandler(this.txtDeviceId_TextChanged);
            this.txtDeviceId.Enter += new System.EventHandler(this.txtDeviceId_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Device ID (Hexadecimal)";
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(176, 146);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(161, 20);
            this.txtPartName.TabIndex = 3;
            this.txtPartName.TextChanged += new System.EventHandler(this.txtPartName_TextChanged);
            this.txtPartName.Enter += new System.EventHandler(this.txtPartName_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Part Name";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(433, 391);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 21;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(514, 391);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.shapeContainer1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(149, 426);
            this.panel1.TabIndex = 23;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(149, 426);
            this.shapeContainer1.TabIndex = 23;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape1.BorderColor = System.Drawing.SystemColors.Highlight;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 148;
            this.lineShape1.X2 = 148;
            this.lineShape1.Y1 = 0;
            this.lineShape1.Y2 = 425;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PicKit2_Script_Editor.Properties.Resources.microchip21;
            this.pictureBox1.Location = new System.Drawing.Point(7, -7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 150);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(361, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 247);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 43);
            this.label6.TabIndex = 0;
            this.label6.Text = "1. Select the device family for the part you want to create";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(361, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 247);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(13, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 88);
            this.label7.TabIndex = 0;
            this.label7.Text = "2. Select a similar part to base the new part off. \r\n\r\nTry to choose one with a s" +
    "imilar config, Vdd, and size, to avoid having to look up the information in the " +
    "datasheet.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(361, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(215, 247);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(196, 88);
            this.label8.TabIndex = 0;
            this.label8.Text = "3. Enter a name for the part";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.pictureBox2);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(361, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(215, 247);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Example:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(6, 69);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(203, 172);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(13, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(196, 30);
            this.label9.TabIndex = 0;
            this.label9.Text = "4. Enter in the device ID. This can be found in the programmer\'s datasheet";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.pictureBox3);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(361, 22);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(215, 247);
            this.groupBox5.TabIndex = 31;
            this.groupBox5.TabStop = false;
            this.groupBox5.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Example:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(6, 69);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(203, 172);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(13, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 30);
            this.label10.TabIndex = 0;
            this.label10.Text = "5. Specify the flash size. This can be found in the programmer\'s manual.";
            // 
            // iconArrow
            // 
            this.iconArrow.Image = global::PicKit2_Script_Editor.Properties.Resources.arrow_left_12x12;
            this.iconArrow.Location = new System.Drawing.Point(343, 42);
            this.iconArrow.Name = "iconArrow";
            this.iconArrow.Size = new System.Drawing.Size(12, 12);
            this.iconArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconArrow.TabIndex = 25;
            this.iconArrow.TabStop = false;
            // 
            // txtConfigAddr
            // 
            this.txtConfigAddr.Location = new System.Drawing.Point(176, 264);
            this.txtConfigAddr.Name = "txtConfigAddr";
            this.txtConfigAddr.Size = new System.Drawing.Size(161, 20);
            this.txtConfigAddr.TabIndex = 32;
            this.txtConfigAddr.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(173, 248);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Config Address";
            this.label13.Visible = false;
            // 
            // txtConfigMasks
            // 
            this.txtConfigMasks.Location = new System.Drawing.Point(176, 306);
            this.txtConfigMasks.Name = "txtConfigMasks";
            this.txtConfigMasks.Size = new System.Drawing.Size(161, 20);
            this.txtConfigMasks.TabIndex = 34;
            this.txtConfigMasks.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(173, 290);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Config Masks";
            this.label14.Visible = false;
            // 
            // txtConfigDefaults
            // 
            this.txtConfigDefaults.Location = new System.Drawing.Point(176, 346);
            this.txtConfigDefaults.Name = "txtConfigDefaults";
            this.txtConfigDefaults.Size = new System.Drawing.Size(161, 20);
            this.txtConfigDefaults.TabIndex = 36;
            this.txtConfigDefaults.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(173, 330);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "Config Defaults";
            this.label15.Visible = false;
            // 
            // fmPartWizard
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(601, 426);
            this.Controls.Add(this.txtConfigDefaults);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtConfigMasks);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtConfigAddr);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.iconArrow);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbBasePart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDeviceFamily);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFlashSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDeviceId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPartName);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmPartWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Part Wizard";
            this.Load += new System.EventHandler(this.fmPartWizard_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBasePart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDeviceFamily;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFlashSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDeviceId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.PictureBox iconArrow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtConfigAddr;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtConfigMasks;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtConfigDefaults;
        private System.Windows.Forms.Label label15;

    }
}