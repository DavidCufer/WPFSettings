using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsWindow
{
    public class FolderPath
    {
        public string PathString { get; set; }

        public FolderPath()
        {

        }

        public FolderPath(string Path)
        {
            PathString = Path;
        }

    }
}
