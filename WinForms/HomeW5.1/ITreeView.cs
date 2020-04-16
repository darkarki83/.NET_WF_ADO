using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeW51
{
    interface ITreeView
    {
        List<DriveInfo> DriveInfos { get; set; }

        DirectoryInfo[] Dir { get; set; }

        DirectoryInfo[] SubDir { get; set; }

        event EventHandler TreeFormInfo;
        event EventHandler<TreeEventArgs> TreeDir;
        event EventHandler<TreeEventArgs> TreeDirInDir;

    }
}
