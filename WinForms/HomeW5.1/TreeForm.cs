using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeW51
{
    public partial class TreeForm : Form, ITreeView
    {
        public TreeForm()
        {
            InitializeComponent();
        }

        #region ITreeView realization

        List<DriveInfo> driveInfos;

        DirectoryInfo[] dir;

        DirectoryInfo[] subDir;

        public event EventHandler TreeFormInfo;

        public event EventHandler<TreeEventArgs> TreeDir;

        public event EventHandler<TreeEventArgs> TreeDirInDir;

        public List<DriveInfo> DriveInfos
        {
            get => driveInfos;
            set
            {
                driveInfos = new List<DriveInfo>();
                foreach (var item in value)
                    driveInfos.Add(item);
            }
        }

        public DirectoryInfo[] Dir
        {
            get => dir;
            set
            {
                dir = new DirectoryInfo[value.Length];
                for (int i = 0; i < value.Length; i++)
                    dir[i] = value[i];
            }
        }

        public DirectoryInfo[] SubDir
        {
            get => subDir;
            set
            {
                subDir = new DirectoryInfo[value.Length];
                for (int i = 0; i < value.Length; i++)
                    subDir[i] = value[i];
            }
        }

        #endregion


        private void Form1_Load(object sender, EventArgs e)
        {
            TreeFormInfo(sender, e);
            for (int i = 0; i < DriveInfos.Count; i++)
            {
                treeView1.Nodes.Add(new TreeNode(DriveInfos[i].Name + Environment.NewLine));
                TreeDir(sender, new TreeEventArgs(i));
                for (int j = 0; j < dir.Length; j++)
                {
                    treeView1.Nodes[i].Nodes.Add(Dir[j].Name);
                    try
                    {
                        TreeDirInDir(sender,new TreeEventArgs(j));
                        for (int k = 0; k < SubDir.Length; k++)
                        {
                            treeView1.Nodes[i].Nodes[j].Nodes.Add(SubDir[k].Name);
                        }
                    }
                    catch
                    {
                        treeView1.Nodes[i].Nodes[j].Nodes.Add("Close for you");
                    }
                }
            }
                /*
                DriveInfo[] infos = DriveInfo.GetDrives();
                DirectoryInfo[] dird;
                DirectoryInfo directoryInfo;
                DirectoryInfo director;
                for (int i = 0; i < infos.Length; i++)
                {
                    directoryInfo = new DirectoryInfo(infos[i].RootDirectory.FullName);
                    treeView1.Nodes.Add(new TreeNode(infos[i].Name + Environment.NewLine));

                    DirectoryInfo[] dir = directoryInfo.GetDirectories();
                    for (int j = 0; j < dir.Length; j++)
                    {
                        treeView1.Nodes[i].Nodes.Add(dir[j].FullName);
                        director = new DirectoryInfo(dir[j].FullName);
                        try
                        {
                            dird = director.GetDirectories();
                            for (int k = 0; k < dird.Length; k++)
                            {
                                treeView1.Nodes[i].Nodes[j].Nodes.Add(dird[k].FullName);
                            }
                        }
                        catch
                        {
                            treeView1.Nodes[i].Nodes[j].Nodes.Add("Close for you");
                        }
                    }
                }*/
        }
    }
}
