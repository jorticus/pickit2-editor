using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PICkit2V2;

namespace PicKit2_Script_Editor
{
    public partial class fmPartWizard : Form
    {
        private DeviceFile DevFile;
        private int step = 1;
        private Control currentGroupBox = null;

        public int SelectedFamily { get { return cbDeviceFamily.SelectedIndex; } }
        //public int SelectedPart { get { return ((KeyValuePair<string, int>)cbBasePart.SelectedItem).Value; } }
        public int SelectedPart { get { return (int)cbBasePart.SelectedValue; } }
        public string PartName { get { return txtPartName.Text; } }
        public int DeviceId { get { return Convert.ToInt32(txtDeviceId.Text, 16); } }
        public int FlashSize { get { return Convert.ToInt32(txtFlashSize.Text, 16); } }

        public fmPartWizard(DeviceFile DevFile)
        {
            InitializeComponent();
            this.DevFile = DevFile;
            this.step = 1;
        }

        private void fmPartWizard_Load(object sender, EventArgs e)
        {
            LoadGui();
        }

        private void LoadGui()
        {
            SwitchHelpPane(cbDeviceFamily, groupBox1);

            // Disable controls
            cbDeviceFamily.Focus();
            cbBasePart.Enabled = false;
            txtPartName.Enabled = false;
            txtDeviceId.Enabled = false;
            txtFlashSize.Enabled = false;
            txtConfigAddr.Enabled = false;
            txtConfigMasks.Enabled = false;
            txtConfigDefaults.Enabled = false;
            btnOk.Enabled = false;

            // Populate Device Families
            cbDeviceFamily.Items.Clear();
            cbDeviceFamily.Items.AddRange(DevFile.Families.Select(f => f.FamilyName).ToArray());
        }

        private void SwitchHelpPane(Control focusedControl, Control helpPane)
        {
            if (currentGroupBox != null)
                currentGroupBox.Visible = false;

            helpPane.Visible = true;
            currentGroupBox = helpPane;

            iconArrow.Top = focusedControl.Top + 5;
        }

        private void CheckOk()
        {
            if (cbDeviceFamily.SelectedIndex >= 0 &&
                cbBasePart.SelectedIndex >= 0 &&
                txtPartName.Text != "" &&
                txtDeviceId.Text != "" &&
                txtFlashSize.Text != "")
            {
                btnOk.Enabled = true;
            }

        }

        private void cbDeviceFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            step = 2;

            cbBasePart.Enabled = true;
            cbBasePart.Focus();

            //SelectedFamily = cbDeviceFamily.SelectedIndex;

            // Populate Parts Box
            var items = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < DevFile.PartsList.Length; i++)
            {
                if (DevFile.PartsList[i].Family == SelectedFamily)
                {
                    items.Add(new KeyValuePair<string, int>(DevFile.PartsList[i].PartName, i));
                }
            }
            cbBasePart.DisplayMember = "Key";
            cbBasePart.ValueMember = "Value";
            cbBasePart.DataSource = items;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {

        }

        private void cbDeviceFamily_Enter(object sender, EventArgs e)
        {
            SwitchHelpPane((sender as Control), groupBox1);
        }

        private void cbBasePart_Enter(object sender, EventArgs e)
        {
            SwitchHelpPane((sender as Control), groupBox2);
        }

        private void cbBasePart_SelectedIndexChanged(object sender, EventArgs e)
        {
            step = 3;

            var selectedDevice = DevFile.PartsList[SelectedPart];
            txtFlashSize.Text = string.Format("{0:X4}", (selectedDevice.ProgramMem + 1) * 2);
            txtConfigAddr.Text = string.Format("{0:X4}", selectedDevice.ConfigAddr);

            txtPartName.Enabled = true;
            txtDeviceId.Enabled = true;
            txtFlashSize.Enabled = true;
            txtPartName.Focus();
        }

        private void txtPartName_Enter(object sender, EventArgs e)
        {
            SwitchHelpPane(txtPartName, groupBox3);
        }

        private void txtDeviceId_TextChanged(object sender, EventArgs e)
        {
            CheckOk();
        }

        private void txtPartName_TextChanged(object sender, EventArgs e)
        {
            CheckOk();
        }

        private void txtDeviceId_Enter(object sender, EventArgs e)
        {
            SwitchHelpPane((sender as Control), groupBox4);
        }

        private void txtFlashSize_Enter(object sender, EventArgs e)
        {
            SwitchHelpPane((sender as Control), groupBox5);
        }

        private void txtFlashSize_TextChanged(object sender, EventArgs e)
        {
            CheckOk();
        }
    }
}
