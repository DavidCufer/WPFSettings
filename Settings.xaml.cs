using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SettingsWindow
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public MySettings settings { get; set; }
        public List<Setting> SettingItems { get; set; }
        private MySettings mySettings;

        public Settings()
        {
            this.DataContext = this;
            SettingItems = new List<Setting>();
            mySettings = MySettings.Load();
            this.ConvertSettingsToDisplay();
            InitializeComponent();
        }

        //convert settings to List<Setting> which is displayed
        private void ConvertSettingsToDisplay()
        {
            var settingProperties = mySettings.GetType().GetProperties();
            List<object> settings = new List<object>();

            foreach(var property in settingProperties)
            {
                var value = property.GetValue(mySettings);
                SettingItems.Add(new Setting() { SettingName = property.Name, SettingValue = value });
            }
        }

        //convert settings back to format ready to be saved
        private void ConvertSettingsFromDisplay()
        {
            var settingProperties = mySettings.GetType().GetProperties();

            for (int i = 0; i < settingProperties.Count(); i++)
            {
               var settingType= settingProperties[i].GetValue(mySettings).GetType();
               var value = SettingItems[i].SettingValue;


                if (settingType == typeof(System.Double))
                {
                    double convertedValue;
                    double.TryParse(value.ToString(), out convertedValue);
                    settingProperties[i].SetValue(mySettings, convertedValue);
                }
                else if(settingType == typeof(System.Boolean))
                {
                    bool convertedValue;
                    bool.TryParse(value.ToString(), out convertedValue);
                    settingProperties[i].SetValue(mySettings, convertedValue);
                }
                else
                {
                    settingProperties[i].SetValue(mySettings, value);
                }

            }
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
            this.ConvertSettingsFromDisplay();
            this.mySettings.Save();
            this.Close();
        }
    }
}
