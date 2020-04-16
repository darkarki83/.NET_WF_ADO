using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeW4._2
{
    class GuideModel
    {
        public List<DriveInfo> Drives { get; set; }

        public DirectoryInfo[] Dir { get; set; }

        public DirectoryInfo[] TreeDir { get; set; }


        public GuideModel()
        {
            Drives = new List<DriveInfo>();

            DriveInfo[] infos = DriveInfo.GetDrives();

            foreach (var item in infos)
            {
                Drives.Add(item);
            }
            Dir = new DirectoryInfo[10];
            TreeDir = new DirectoryInfo[10];
        }

        public void DirectoryInput(Object sender)
        {
            Button b = (Button)sender;
            int tag = int.Parse(b.Tag.ToString());

            int i;
            DirectoryInfo directoryInfo;
            string tmp = sender.ToString().Remove(0, sender.ToString().Length - 3);

            for (i = 0; i < Drives.Count; i++)
            {
                if (i + 1 == tag)
                    break;
            }
            directoryInfo = new DirectoryInfo(Drives[i].RootDirectory.FullName);

            Dir = directoryInfo.GetDirectories();
        }
        public void DirectoryTree(int selection)
        {
            DirectoryInfo directoryInfo;

            directoryInfo = new DirectoryInfo(Dir[selection].FullName);
            try
            {
                TreeDir = directoryInfo.GetDirectories();
            }
            catch(Exception ex)
            {
                TreeDir = null;
            }
        }


    }
}
