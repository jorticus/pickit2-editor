using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicKit2_Script_Editor
{
    public partial class fmPatcher : Form
    {
        public fmPatcher()
        {
            InitializeComponent();
        }

        private void fmPatcher_Load(object sender, EventArgs e)
        {

        }

        public void UpdateDeviceList(IEnumerable<string> devices)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(devices.ToArray());
        }

        public void UpdateDescription(string desc)
        {
            labelDesc.Text = desc;
        }
    }
}
