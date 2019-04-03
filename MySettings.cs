using System;
using System.Collections.Generic;
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
        public string test1 { get; set; }
        public bool test2 { get; set; }
        public string test3 { get; set; }
        public string test4 { get; set; }
        public string test5 { get; set; }
        public double test6 { get; set; }

    }
}
