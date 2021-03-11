using HW.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Views
{
    public interface IAdminFormView : IView
    {
        // add part
        TextBox TextBoxPartName { get; set; }
        TextBox TextBoxPartCost { get; set; }
        ComboBox ComboBoxPartMan { get; set; }
        NumericUpDown NumericPartCount { get; set; }

        ListView ListViewParts { get; set; }

        event EventHandler AddPart;
        /// end

        // add manufacturer
        TextBox TextBoxManName { get; set; }

        event EventHandler AddMan;
        /// end
        
        // add client
        TextBox TextBoxClientName { get; set; }
        TextBox TextBoxClientAddress { get; set; }
        NumericUpDown NumericBonus { get; set; }

        event EventHandler AddCliient;
        //// end

        // add count
        ComboBox ComboBoxPartName { get; set; }
        NumericUpDown NumericCount { get; set; }
        event EventHandler ChangeCount;
        //// end

        // delete part
        event EventHandler DeletePart;
        //// end


        event EventHandler LoadForm;

        // clier all part group
        void ClierPart();
        // clier all manufacturer group
        void ClierMan();
        // clier all client group
        void ClierClient();
        // clier all count group
        void ClierCount();

    }
}
