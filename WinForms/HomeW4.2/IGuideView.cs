using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeW4._2
{
    interface IGuideView
    {
        List<DriveInfo> DriverF { get; set; }

        DirectoryInfo[] Dir { get; set; }

        DirectoryInfo[] TreeDir { get; set; }

        event EventHandler MainForm;

        event EventHandler<EventSelect> OpenFile;

    }
}

