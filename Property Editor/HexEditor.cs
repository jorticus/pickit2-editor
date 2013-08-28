using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace PicKit2_Script_Editor
{
    /// <summary>
    /// Displays integers as a hexadecimal,
    /// and allows both base 16 (when prefixed with '0x') and base 10 input
    /// </summary>
    public class HexConverter : StringConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context,
                                  System.Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
                               CultureInfo culture,
                               object value,
                               System.Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                int size = System.Runtime.InteropServices.Marshal.SizeOf(value) * 2;
                return string.Format("0x{0:X"+size.ToString()+"}", value);
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
                var type = context.PropertyDescriptor.PropertyType;
                string v = (value as string);
                int n = 10;

                // Hexadecimal
                if (v.StartsWith("0x"))
                {
                    v = v.Substring(2);
                    n = 16;
                }

                // Convert number
                Int64 val = Convert.ToInt64(v, n);
                return Convert.ChangeType(val, type);
            }
            return base.ConvertFrom(context, culture, value);
        }

        private object ConvertHexadecimal(ITypeDescriptorContext context, CultureInfo culture, object value)
        {

            return null;
        }

        private object ConvertDecimal(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return null;
        }
    }
}
