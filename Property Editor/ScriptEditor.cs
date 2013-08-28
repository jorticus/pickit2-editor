using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Design;
using PICkit2V2;
using System.Globalization;


namespace PicKit2_Script_Editor
{

    #region TypeConverter
    /// <summary>
    /// This converts a script index to and from a string value in the property grid.
    /// When editing, both the script index and the script name are valid input.
    /// </summary>
    public class ScriptConverter : StringConverter
    {
        private DeviceFile DevFile { get { return fmMain.DevFile; } }

        
        public override bool CanConvertTo(ITypeDescriptorContext context,
                                  System.Type destinationType)
        {
            // Tell the property grid we can convert the type for DeviceScript objects
            if (destinationType == typeof(DeviceFile.DeviceScripts)) //should this be typeof(string)?
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
                               CultureInfo culture,
                               object value,
                               System.Type destinationType)
        {
            // The property value is a ushort index into the script array
            if (destinationType == typeof(System.String) &&
                 value is ushort)
            {
                ushort index = (ushort)value;
                if (index == 0)
                    return "-";
                else
                {
                    // Return the name of the script
                    return DevFile.Scripts[index-1].ScriptName;
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context,
                              System.Type sourceType)
        {
            // Tell the property grid we can convert from a string
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
                              CultureInfo culture, object value)
        {
            if (value is string)
            {
                ushort index = 0;

                // Allow this to specify no script
                if (((value as string) == "-") || ((value as string) == ""))
                    return (ushort)0;

                // The string might be an index to the array
                if (ushort.TryParse((value as string), out index))
                {
                    if (index < DevFile.Scripts.Length)
                        return index;
                }
                
                // Else the string might be the script name
                string name = (value as string).ToLower();
                try
                {
                    var script = DevFile.Scripts.First(s => s.ScriptName.ToLower() == name);
                    return script.ScriptNumber;
                }
                catch
                {
                    // No such script name
                }

                // Otherwise we can't convert it
                throw new ArgumentException("'" + (string)value + "' is not a valid script name or index");

            }
            return base.ConvertFrom(context, culture, value);
        }
    }

    #endregion

    #region ScriptEditor
    /// <summary>
    /// ScriptEditor provides a dropdown list of scripts that can be selected.
    ///
    /// Using the context parameter in EditValue, you have access to the calling object
    /// as well as the property we're being asked to edit.
    /// </summary>
    internal class ScriptEditor : UITypeEditor
    {
        private DeviceFile DevFile { get { return fmMain.DevFile; } }
        IWindowsFormsEditorService edSvc;

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            ListBox lb;
            if (context.Instance is PICkit2V2.DeviceFile.DevicePartParams)
                edSvc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            if (edSvc != null)
            {
                lb = BuildListBox(value, context);
                lb.SelectedIndexChanged += SelectionComplete;
                edSvc.DropDownControl(lb);

                if (lb.SelectedIndex >= 0)
                    return (ushort)lb.SelectedIndex;
            }

            return value;
        }

        private ListBox BuildListBox(Object defaultValue, ITypeDescriptorContext context)
        {
            ListBox lb = new ListBox();

            // Populate list box with script names
            lb.Items.Add("-");
            foreach (var script in fmMain.DevFile.Scripts)
            {
                lb.Items.Add(script.ScriptName);
            }

            lb.SelectedIndex = (ushort)defaultValue;
            return lb;
        }

        private void SelectionComplete(Object sender, EventArgs e)
        {
            if (edSvc != null)
                edSvc.CloseDropDown();
        }
    }
    #endregion
}
