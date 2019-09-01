using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsWindow
{
    public interface ISetting
    {
         string SettingName { get; set; }
         object SettingValue { get; set; }
    }
}
