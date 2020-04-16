using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeW51
{
    class TreePresenter
    {
        public ITreeView treeView;
        public TreeModel treeModel;

        public TreePresenter(ITreeView outTreeView, TreeModel outTreeModel)
        {
            treeView = outTreeView;
            treeModel = outTreeModel;
            treeView.TreeFormInfo += DriverIn;
            treeView.TreeDir += DirIn;
            treeView.TreeDirInDir += DirInDir;
        }

        public void DriverIn(object sender, EventArgs e)
        {
            treeModel.InputDrive();
            treeView.DriveInfos = treeModel.DriveInfos;
        }

        public void DirIn(object sender, TreeEventArgs e)
        {
            treeModel.InputDir(e.GetIndex());
            treeView.Dir = treeModel.Dir;
        }

        public void DirInDir(object sender, TreeEventArgs e)
        {
            treeModel.InputDirDir(e.GetIndex());
            treeView.SubDir = treeModel.SubDir;
        }
    }
}
