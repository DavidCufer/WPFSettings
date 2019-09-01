using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SettingsWindow
{
    public class FilePath
    {
        public string PathString { get; set; }

        public FilePath()
        {

        }

        public FilePath(string Path)
        {
            PathString = Path;
        }

    }
}
