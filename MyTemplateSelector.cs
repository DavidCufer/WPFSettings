using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SettingsWindow
{
    //it selects template for datagrid 
    public class MyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BoolTemplate { get; set; }
        public DataTemplate StringTemplate { get; set; }
        public DataTemplate DoubleTemplate { get; set; }
        public DataTemplate IntTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
            {
                return StringTemplate;
            }

            var convertedItem = item as Setting;
            var type = convertedItem.SettingValue.GetType();

            if (type == typeof(Boolean))
            {
                return BoolTemplate;

            }
            else if (type == typeof(Double))
            {
                return DoubleTemplate;
            }
            else if (type == typeof(Int32))
            {
                return IntTemplate;
            }
            else return StringTemplate;
        }
    }

}
