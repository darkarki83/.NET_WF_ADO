using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeW51
{
    class TreeModel
    {
        public List<DriveInfo> DriveInfos { get; set; }
        public DirectoryInfo[] Dir { get; set; }
        public DirectoryInfo[] SubDir { get; set; }

        public TreeModel()
        {
            Dir = new DirectoryInfo[10];
            SubDir = new DirectoryInfo[10];
        }

        public void InputDrive()
        {
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            DriveInfos = new List<DriveInfo>();
            foreach (var item in driveInfo)
                DriveInfos.Add(item); 
        }

        public void InputDir(int iterat)
        {
            DirectoryInfo directoryInfo;

            directoryInfo = new DirectoryInfo(DriveInfos[iterat].RootDirectory.FullName);
            Dir = directoryInfo.GetDirectories();
        }

        public void InputDirDir(int iterat)
        {
            DirectoryInfo directoryInfo;
            try
            {
                directoryInfo = new DirectoryInfo(Dir[iterat].FullName);
                SubDir = directoryInfo.GetDirectories();
            }
            catch
            {
                SubDir = new DirectoryInfo[0];
            }
        }
    }
}
