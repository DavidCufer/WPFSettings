using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsWindow
{
    public class ComboSetting : ISetting
    {
        public string SettingName { get; set; }
        public object SettingValue { get; set; }

        private Array _values;
        public Array Values
        {
            get
            {
                if (_values == null)
                {
                    _values = Enum.GetValues(SettingValue.GetType());

                    return _values;
                }
                else return _values;
            }
            set
            {
                _values = value;
            }
        }
    }
}
