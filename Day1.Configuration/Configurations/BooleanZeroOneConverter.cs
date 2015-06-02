using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4.Configurations
{
    public class BooleanZeroOneConverter : ConfigurationConverterBase
    {
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            var incoming = (string)value;
            return incoming == "0" ? false : true;
        }
    }
}
