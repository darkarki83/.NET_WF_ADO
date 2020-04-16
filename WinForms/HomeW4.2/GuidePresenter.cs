using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeW4._2
{
    class GuidePresenter
    {
        public readonly GuideModel guideModel;
        public readonly IGuideView guideView;

        public GuidePresenter(GuideModel theGuideModel, IGuideView theGuideView)
        {
            guideModel = theGuideModel;
            guideView = theGuideView;
            StartDrivers();
            guideView.MainForm += StartDrivers;
            guideView.OpenFile += TreeDrivers;
        }

        private void StartDrivers()
        {
            guideView.DriverF = guideModel.Drives;
        }

        private void StartDrivers(Object sender, EventArgs e )
        {
                guideModel.DirectoryInput(sender);
                guideView.Dir = guideModel.Dir;
        }

        private void TreeDrivers(Object sender, EventSelect e)
        {
            guideModel.DirectoryTree(e.GetSelection());
            guideView.TreeDir = guideModel.TreeDir;
        }
    }
}
