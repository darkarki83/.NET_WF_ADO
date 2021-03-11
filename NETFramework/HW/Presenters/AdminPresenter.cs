using HW.Common;
using HW.Model;
using HW.Model.Tables;
using HW.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.Presenters
{
    public class AdminPresenter : BasePresenter<IAdminFormView>
    {
        public IModel Model { get; set; }

        public AdminPresenter(IModel model, IAdminFormView view)
        {
            Model = model;
            View = view;

            View.LoadForm += LoadForm;

            View.AddPart += AddPart;
            View.AddMan += AddMan;
            View.AddCliient += AddClient;
            View.ChangeCount += ChangeCount;
            View.DeletePart += DeletePart;

            Model.Context.Parts.Load();
            Model.Context.Orders.Load();
            Model.Context.PartsInOrders.Load();
            Model.Context.PartsCountHave.Load();
            Model.Context.Clients.Load();
            Model.Context.Manufacturers.Load();
            Model.Context.Admins.Load();
        }

        public async void LoadForm(object sender, EventArgs e)
        {
            foreach (var item in Model.Context.Manufacturers)       //  add manufacturer list to ComboBox
            {
                View.ComboBoxPartMan.Items.Add(item.Name);
            }

            foreach (var item in Model.Context.Parts)       //  add parts list to ComboBox
            {
                View.ComboBoxPartName.Items.Add(item.Name);
            }

            await Reload();
        }

        public async void AddPart(object sender, EventArgs e)
        {
            Decimal cost;
            try
            {
                cost = Decimal.Parse(View.TextBoxPartCost.Text);
            }
            catch
            {
                cost = 1;
            }

            var newPart = new Part()
            {
                Name = View.TextBoxPartName.Text,
                Cost = cost,

                Manufacturer = Model.Context.Manufacturers.AsNoTracking().SingleOrDefault(u => u.Name == View.ComboBoxPartMan.SelectedItem.ToString())
            };

            var partCountHave = new PartCountHave()
            {
                Count = (int)View.NumericPartCount.Value,
                Part = newPart
            };

            if (MessageBox.Show("Are you sure to add this " + View.TextBoxPartName.Text + " item?", "Confirm added item!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Model.Context.Parts.Add(newPart);
                    Model.Context.PartsCountHave.Add(partCountHave);
                    await Model.Context.SaveChangesAsync();
                    AddPartToListView(newPart, partCountHave);
                    View.ComboBoxPartName.Items.Add(newPart.Name);         //  add new part to ComboBoxPartName
                }
                catch
                {
                    MessageBox.Show("Wrong input try again", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                View.ClierPart();
            }
        }

        public async void AddMan(object sender, EventArgs e)
        {
            var man = new Manufacturer()
            {
                Name = View.TextBoxManName.Text,
            };

            try
            {
                Model.Context.Manufacturers.Add(man);
                await Model.Context.SaveChangesAsync();

                MessageBox.Show("The new manufacturer added successfully ", "New Manufacturer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("New manufacturer was not add", "Not Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            View.ComboBoxPartMan.Items.Add(man.Name);         //  add new manufacturer to ComboBoxPartMan
            View.ClierMan();                        
        }

        public async void AddClient(object sender, EventArgs e)
        {
            var newClient = new Client()
            {
                Name = View.TextBoxClientName.Text,
                Adrress = View.TextBoxClientAddress.Text,
                Bonus = (int)View.NumericBonus.Value
            };

            try
            {
                Model.Context.Clients.Add(newClient);
                await Model.Context.SaveChangesAsync();

                MessageBox.Show("The new Client added successfully ", "New Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("New Client was not add", "Not Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            View.ClierClient();
        }

        public async void ChangeCount(object sender, EventArgs e)
        {
            var count = await Model.Context.PartsCountHave.FirstOrDefaultAsync(u => u.Part.Name == View.ComboBoxPartName.SelectedItem.ToString());
            
            if (count != null)
            {
                count.Count = (int)View.NumericCount.Value;
                try
                {
                    await Model.Context.SaveChangesAsync();
                    await Reload();
                    MessageBox.Show("The count change successfully ", "Change count", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Count was not change", "Not Change", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public async void DeletePart(object sender, EventArgs e)
        {
            var part = await Model.Context.Parts.FindAsync(int.Parse(View.ListViewParts.SelectedItems[0].SubItems[0].Text));
            if (part != null)
            {
                if (MessageBox.Show("Are you sure to delete this item?", "Confirm Delete!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Model.Context.Parts.Remove(part);
                    View.ListViewParts.SelectedItems[0].Remove();
                    await Model.Context.SaveChangesAsync();

                    View.ComboBoxPartName.Items.Remove(part.Name);
                }
            }
        }

        public async void AddPartToListView(Part newPart, PartCountHave partCountHave)
        {
            ListViewItem listItem = new ListViewItem();
            listItem.Text = newPart.Id.ToString();        // Убрать в релизе
            listItem.SubItems.Add(newPart.Name);

            var manufacturers = await Model.Context.Manufacturers.FindAsync(newPart.ManufacturerFk);
            listItem.SubItems.Add(manufacturers.Name);

            listItem.SubItems.Add(newPart.Cost.ToString());

            var counts = await Model.Context.PartsCountHave.FindAsync(partCountHave.Id);
            listItem.SubItems.Add(counts.Count.ToString());

            View.ListViewParts.Items.Add(listItem);
        }

        public async Task Reload()
        {
            if(View.ListViewParts.Items.Count > 0)
                View.ListViewParts.Items.Clear();

            foreach (var item in Model.Context.Parts)
            {
                ListViewItem listItem = new ListViewItem();
                listItem.Text = item.Id.ToString();        // Убрать в релизе
                listItem.SubItems.Add(item.Name);

                var manufacturers = await Model.Context.Manufacturers.FindAsync(item.ManufacturerFk);
                listItem.SubItems.Add(manufacturers.Name);

                listItem.SubItems.Add(item.Cost.ToString());

                var counts = await Model.Context.PartsCountHave.FindAsync(item.Id);
                listItem.SubItems.Add(counts.Count.ToString());

                View.ListViewParts.Items.Add(listItem);
            }
        }
    }
}
