using System;
using System.ComponentModel;
using System.IO;
using System.Web.Script.Serialization;

namespace SettingsWindow
{
    public class AppSettings<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.json";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(this));
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(pSettings));
        }

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            T t = new T();
            if (File.Exists(fileName))
                t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(fileName));
            return t;
        }
    }

    public class MySettings : AppSettings<MySettings>
    {
        [PropertyName("First setting")]
        public string stringSetting = "abc";
        public bool isTestEnabled = true;
        public double doubleTest = 21.1;
        [Browsable(false)]
        public int hiddenSetting = 23;
        [PropertyName("The important file")]
        public FilePath filePathSetting = new FilePath(@"C:\\Users\Default\Settings.csproj");
        public FolderPath folderPathSetting = new FolderPath(@"C:\\Users\Default\Settings");
        public Laugh enumeration = Laugh.hehe;
    }

    public class PropertyName : Attribute
    {
        public PropertyName()
        {

        }

        public PropertyName(string _displayName)
        {
            DisplayName = _displayName;
        }

        public string DisplayName { get; set; }
    }
}
