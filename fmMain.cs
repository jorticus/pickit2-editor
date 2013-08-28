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
    public partial class fmMain : Form
    {
        public static DeviceFile DevFile;
        private int currentScriptIndex = 0;

        public fmMain()
        {
            InitializeComponent();
            DevFile = null;// new DeviceFile();

            //ListEditor.DevFile = DevFile;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DevFile = new DeviceFile();

            bool result = false;
            result = DevFile.LoadFromFile("PK2DeviceFile.dat");

            /*
            if (!result) result = DevFile.LoadFromFile("C:\\Program Files\\Microchip\\PICkit 2\\PK2DeviceFile.dat");
            if (!result) result = DevFile.LoadFromFile("C:\\Program Files\\Microchip\\PICkit 2 v2\\PK2DeviceFile.dat");
            if (!result) result = DevFile.LoadFromFile("C:\\Program Files (x86)\\Microchip\\PICkit 2\\PK2DeviceFile.dat");
            if (!result) result = DevFile.LoadFromFile("C:\\Program Files (x86)\\Microchip\\PICkit 2 v2\\PK2DeviceFile.dat");
            */

            if (!result)
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    result = DevFile.LoadFromFile(openFileDialog1.FileName);
                }
            }

            if (result) DeviceFileLoaded();
        }

        private void DeviceFileLoaded()
        {
            //lblFilename.Text = DevFile.Filename;

            // Load Scripts
            listScripts.Items.Clear();
            foreach (var script in DevFile.Scripts)
            {
                listScripts.Items.Add(script.ScriptName);
            }

            LoadScript(21);

            // Load Devices
            treeViewDevices.Nodes.Clear();
            foreach (var family in DevFile.Families)
            {
                var node = treeViewDevices.Nodes.Add(family.FamilyName);
                //node.Tag = family;
                for (int i = 0; i < DevFile.PartsList.Length; i++)
                {
                    var device = DevFile.PartsList[i];
                    if (device.Family == family.FamilyID)
                    {
                        var devnode = node.Nodes.Add(device.PartName);
                        devnode.Tag = i;
                    }
                }
                /*foreach (var device in DevFile.PartsList.Where(p => p.Family == family.FamilyID))
                {
                    var devnode = node.Nodes.Add(device.PartName);
                    devnode.Tag = device.DeviceID;
                }*/
            }
        }

        private void LoadScript(int idx)
        {
            var scr = DevFile.Scripts[idx];
            DisplayRawScript(scr);
            DisplayScript(scr);

            if (!listScripts.Focused)
            {
                listScripts.SelectedIndex = idx;
            }

            propertyGridScript.SelectedObject = scr;

            currentScriptIndex = idx;
        }


        private void DisplayRawScript(DeviceFile.DeviceScripts script)
        {
            int columnCount = 8;
            int columnWidth = (dataGridHex.Width - 32) / columnCount;
            int rowCount = script.ScriptLength / columnCount;

            // Set up columns
            dataGridHex.ColumnCount = columnCount;
            for (int i = 0; i < 8; i++)
            {
                dataGridHex.Columns[i].Width = columnWidth;
            }

            // Set up rows
            dataGridHex.Rows.Clear();
            dataGridHex.RowCount = rowCount + 1;

            // Load the script bytes
            int col = 0;
            int row = 0;
            foreach (var v in script.Script)
            {
                dataGridHex[col, row].Value = string.Format("{0:X4}", v);

                if (col++ == columnCount - 1)
                {
                    col = 0;
                    row++;
                }
            }
        }

        private void DisplayScript(DeviceFile.DeviceScripts script)
        {
            int columnCount = 3;
            int columnWidth = dataGridViewScript.Width / columnCount;
            int rowCount = script.ScriptLength / columnCount;

            // Set up columns
            dataGridViewScript.ColumnCount = columnCount;
            dataGridViewScript.Columns[0].MinimumWidth = 80;
            dataGridViewScript.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewScript.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewScript.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Set up rows
            dataGridViewScript.Rows.Clear();
            dataGridViewScript.RowCount = script.ScriptLength;

            var opcodes = script.ParseScript();

            // Load the script 
            int col = 0;
            int row = 0;
            foreach (var opcode in opcodes)
            {
                dataGridViewScript[0, row].Value = opcode;
                dataGridViewScript[1, row].Value = opcode.Parse();
                dataGridViewScript[2, row].Value = opcode.ParseInst();

                row++;
            }
        }

        private void listScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listScripts.SelectedIndex >= 0)
                LoadScript(listScripts.SelectedIndex);
        }

        // Update the Hex View selection to match the Script View
        private void dataGridViewScript_SelectionChanged(object sender, EventArgs e)
        {
            var cells = dataGridViewScript.SelectedCells;
            dataGridHex.ClearSelection();
            foreach (DataGridViewCell cell in cells)
            {
                var opcell = dataGridViewScript[0, cell.RowIndex];
                var opcode = (opcell.Value as DeviceFile.Opcode);

                if (opcode != null)
                {

                    int idx = opcode.index;
                    int columnCount = dataGridHex.ColumnCount;
                    int col = idx % columnCount;
                    int row = idx / columnCount;


                    for (int i = 0; i < opcode.data.Length + 1; i++)
                    {
                        dataGridHex[col, row].Selected = true;
                        if (col++ == columnCount - 1)
                        {
                            col = 0;
                            row++;
                        }
                    }

                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DevFile = new DeviceFile();
                if (DevFile.LoadFromFile(openFileDialog1.FileName))
                {
                    DeviceFileLoaded();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevFile.SaveToFile(DevFile.Filename);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DevFile.SaveToFile(saveFileDialog1.FileName);
            }
        }

        private void newPartWizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fm = new fmPartWizard(DevFile))
            {
                if (fm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var newPart = DevFile.PartsList[fm.SelectedPart];
                    newPart.PartName = fm.PartName;
                    newPart.DeviceID = (uint)fm.DeviceId;
                    newPart.ProgramMem = (uint)(fm.FlashSize / 2 + 1);
                    //newPart.ConfigAddr = 0;

                    DevFile.AddPart(newPart);

                    // Reload GUI
                    DeviceFileLoaded();
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new fmAbout();
            fm.ShowDialog();
        }

        private void importPartWizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new fmImportPartWizard();
            if (fm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //TODO
            }
        }

        private void treeViewDevices_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                var part = DevFile.PartsList[(int)e.Node.Tag];
                var family = DevFile.Families[part.Family];

                groupBoxDeviceInfo.Text = part.PartName;

                lblDeviceFamily.Text = family.FamilyName;
                lblDeviceId.Text = string.Format("0x{0:X4}", part.DeviceID);
                lblDeviceVdd.Text = string.Format("{0}V - {1}V", part.VddMin, part.VddMax);

                // Note: This could represent either words or bytes, depending on the architecture (eg. PIC24 will be in words)
                uint progmem = part.ProgramMem;
                if (progmem < 1024)
                    lblFlashSize.Text = string.Format("{0}", progmem);
                else
                    lblFlashSize.Text = string.Format("{0}K ({1})", progmem/1000, progmem);

                propertyGridDevice.PropertySort = PropertySort.Categorized;
                propertyGridDevice.SelectedObject = part;
                propertyGridDevice.Tag = (int)e.Node.Tag;
            }
        }

        private void propertyGridDevice_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            int idx = (int)propertyGridDevice.Tag;
            DevFile.PartsList[idx] = (DeviceFile.DevicePartParams)propertyGridDevice.SelectedObject;

            treeViewDevices.SelectedNode.Text = DevFile.PartsList[idx].PartName;
            groupBoxDeviceInfo.Text = DevFile.PartsList[idx].PartName;

        }

        private void propertyGridScript_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            int idx = currentScriptIndex;
            DevFile.Scripts[idx] = (DeviceFile.DeviceScripts)propertyGridScript.SelectedObject;

            listScripts.SelectedIndex = idx;
            listScripts.Items[idx] = DevFile.Scripts[idx].ScriptName;
        }

        private void dataGridHex_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridHex.Focused)
            {
                int idx = e.ColumnIndex + e.RowIndex * dataGridHex.ColumnCount;
                ushort val = (ushort)Convert.ToInt32((string)dataGridHex[e.ColumnIndex, e.RowIndex].Value, 16);

                ushort oldval = DevFile.Scripts[currentScriptIndex].Script[idx];

                if (oldval != val)
                {
                    DevFile.Scripts[currentScriptIndex].Script[idx] = val;
                    LoadScript(currentScriptIndex);
                }

            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void duplicateScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = currentScriptIndex;
            if (selectedIndex >= 0)
            {

                using (var fm = new fmDuplicate())
                {
                    fm.Value = DevFile.Scripts[selectedIndex].ScriptName;
                    fm.Text = "Duplicate Script";

                    if (fm.ShowDialog() == DialogResult.OK)
                    {
                        var newScript = DevFile.Scripts[selectedIndex];

                        newScript.ScriptNumber = (ushort)DevFile.Info.NumberScripts++;
                        newScript.ScriptName = fm.Value;
                        newScript.Script = (ushort[])newScript.Script.Clone();

                        //DevFile.Scripts = DevFile.Scripts.Concat(new List<DeviceFile.DeviceScripts>() { newScript }).ToArray();
                        DevFile.AddScript(newScript);

                        // Reload GUI
                        DeviceFileLoaded();
                        LoadScript(newScript.ScriptNumber);
                    }
                }
            }
        }

        private void addPIC24r2ChipsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var fm = new fmPatcher();

            fm.UpdateDescription(Patcher24r2.description);
            fm.UpdateDeviceList(Patcher24r2.devices.Select(d => d.partName));

            if (fm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Patch in chips
                Patcher24r2.PatchDeviceFile(DevFile);

                // Reload GUI
                DeviceFileLoaded();
            }
        }

        private void listScripts_MouseDown(object sender, MouseEventArgs e)
        {
            listScripts.SelectedIndex = listScripts.IndexFromPoint(e.X, e.Y);
        }
    }
}
