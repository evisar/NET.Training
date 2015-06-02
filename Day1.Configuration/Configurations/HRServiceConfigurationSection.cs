using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication4.Configurations
{    
    public class HRServiceConfigurationSection: ConfigurationSection
    {

        public Dictionary<string, string> ExtendedAttributes { get; private set; }
        public Dictionary<string, XmlElement> ExtendedElements { get; private set; }

        public HRServiceConfigurationSection()
        {
            this.ExtendedAttributes = new Dictionary<string, string>();
            this.ExtendedElements = new Dictionary<string, XmlElement>();
        }
        
        [TypeConverter(typeof(BooleanZeroOneConverter))]
        [ConfigurationProperty("isRemote", DefaultValue=true)]
        public bool IsRemote
        {
            get
            {
                return (bool)this["isRemote"];
            }
            set
            {
                this["isRemote"] = value;
            }
        }

        [TypeConverter(typeof(TypeNameConverter))]
        [ConfigurationProperty("type", IsRequired=true)]
        public Type ServiceType
        {
            get
            {
                return (Type)this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }

        [ConfigurationProperty("address", IsRequired=true)]
        public Uri Address
        {
            get
            {
                return (Uri)this["address"];
            }
            set
            {
                this["address"] = value;
            }
        }

        [TimeSpanValidator(MinValueString="00:00:00", MaxValueString="00:00:30")]
        [ConfigurationProperty("timeout")]
        public TimeSpan Timeout
        {
            get
            {
                return (TimeSpan)this["timeout"];
            }
            set
            {
                this["timeout"] = value;
            }
        }

        [ConfigurationProperty("modules")]
        [ConfigurationCollection(typeof(HRModuleConfiguration), AddItemName="module")]
        public HRModuleConfigurationCollection Modules
        {
            get
            {
                return (HRModuleConfigurationCollection)this["modules"];
            }
        }

        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
        {
            //return base.OnDeserializeUnrecognizedAttribute(name, value);
            this.ExtendedAttributes.Add(name, value);
            return true;
        }

        protected override bool OnDeserializeUnrecognizedElement(string elementName, System.Xml.XmlReader reader)
        {
            var xml = new XmlDocument();
            xml.Load(reader);
            this.ExtendedElements.Add(elementName, xml.DocumentElement);
            return true;
        }

        public static void Validate(object value)
        {
            var config = value as HRServiceConfigurationSection;

            if (config.Timeout.TotalSeconds > 30)
            {
                throw new ConfigurationErrorsException("Timeout cannot be larger than 30 sec.");
            }
        }
    }
}
