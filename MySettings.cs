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
        public string test1 = "";
        public bool test2 = false;
        public double test3 = 2;
        public string test4 = "";
        public string test5 = "";
        public string test6 = "";
        public int test7 = 23;

    }
}
