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
    public partial class fmDuplicate : Form
    {
        public string Value { get { return txtName.Text; } set { txtName.Text = value; } }

        public fmDuplicate()
        {
            InitializeComponent();
        }

        private void fmDuplicate_Load(object sender, EventArgs e)
        {

        }
    }
}
