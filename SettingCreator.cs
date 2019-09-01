using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsWindow
{
    public class SettingCreator
    {
        public ISetting CreateSetting(string propertyName, object value)
        {
            if (value.GetType() == typeof(FilePath))
            {
                return new FilePathSetting() { SettingName = propertyName, SettingValue = value };
            }
            else if (value.GetType() == typeof(FolderPath))
            {
                return new FolderPathSetting() { SettingName = propertyName, SettingValue = value };
            }
            else if (value.GetType().BaseType == typeof(Enum))
            {
                return new ComboSetting() { SettingName = propertyName, SettingValue = value };
            }

            else return new Setting() { SettingName = propertyName, SettingValue = value };
        }
    }
}
