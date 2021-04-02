using HW.Common;
using HW.Model;
using HW.Model.Tables;
using HW.Views;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using Tests.Model;

namespace Tests.Presenters
{
    public class RollbackAttribute : Attribute, ITestAction
    {
        private TransactionScope transaction;

        public void BeforeTest(ITest test)
        {
            transaction = new TransactionScope();
        }

        public void AfterTest(ITest test)
        {
            transaction.Dispose();
        }

        public ActionTargets Targets
        {
            get { return ActionTargets.Test; }
        }
    }

    [TestFixture]
    public class UserPresenterTests : BasePresenter<IUserFormView>
    {
        [TestFixtureSetUp]
        public void Init()
        { /* ... */ }

        [TestFixtureTearDown]
        public void Cleanup()
        { /* ... */ }
        /*public IModel Model { get; set; }

        public UserPresenterTests()
        {
            // Arrange 
            Model = new MyModelNew(new MyStoreContext());
            View = new UserFormView();

            // Act

            LoadlistViewPart();
           
            View.Cost.Text = Model.Totalcost.ToString();     // add Cost to textBox

            foreach (var item in Model.Context.Clients)       //  add Client list to ComboBox
            {
                View.ComboClient.Items.Add(item.Name);
            }
        }

        [TestCase]  //  правильно ли заполняет listView
        public void UserPresenterConstructorListTests()
        {
            // Arrange 

            Assert.AreEqual(6, View.ListViewOrder.Items.Count);
        }

        [TestCase]  //  правильно ли заполняет Cost
        public void UserPresenterConstructorCostTests()
        {
            // Arrange 

            Assert.AreEqual(Model.Totalcost.ToString(), View.Cost.Text);
        }

        [TestCase]  //  правильно ли заполняет ComboClient
        public void UserPresenterConstructorComboTests()
        {
            // Arrange 

            Assert.AreEqual("Энергия сервис", View.ComboClient.Items[4]);
        }

        [TestCase]  // проверка правильно ли считает конечную Сумму
        public void SelectedIndexChangedTest()  
        {
            // Arrange 
            var client = Model.Context.Clients.AsNoTracking().SingleOrDefault(u => u.Name == "ТелеКом");

            View.Bonus.Text = client.Bonus.ToString();
            // Act
            View.TotalCost.Text = (Decimal.Parse(View.Cost.Text) * Decimal.Parse(((100 - client.Bonus) / 100).ToString())).ToString();

            // Arrange 

            Assert.AreEqual((Model.Totalcost * (Decimal)(1 - client.Bonus / 100)).ToString(), View.TotalCost.Text);
        }
        */












        //[TestCase("Ник лтд", 9)]
        /* [TestCase("ТелеКом", 10)]
         [TestCase("АрмТек", 11)]
         [TestCase("Овк комплект", 12)]
         [TestCase("Овк комплект", 13)]*/
        [Test, Rollback]
        public void ConfirmOrderPart1Test()
        {
            var model = new MyModelNew(new MyStoreContext());

            var client = model.Context.Clients.AsNoTracking().SingleOrDefault(u => u.Name == "Ник лтд");

            var newOrder = new Order()
            {
                OrderData = DateTime.Now,
                ClientFk = client.Id
            };
            model.Context.Orders.Add(newOrder);


            /* foreach (ListViewItem item in View.ListViewOrder.Items)
             {
                 var newPartsInOrder = new PartsInOrder()
                 {
                     PartFk = long.Parse(item.SubItems[3].Text),
                     Order = newOrder,
                     Count = int.Parse(item.SubItems[2].Text),
                     TotalCost = Decimal.Parse(View.TotalCost.Text)
                 };

                 Model.Context.PartsInOrders.Add(newPartsInOrder);

                 var count = Model.Context.PartsCountHave.FirstOrDefault(u => u.PartFk == newPartsInOrder.PartFk);
                 if (count != null)
                 {
                     count.Count = count.Count - int.Parse(item.SubItems[2].Text);

                         Model.Context.SaveChanges();
                 }
             }*/
            model.Context.SaveChanges();

            Assert.AreEqual(9, newOrder.Id);
 
        }
        /*
        public void LoadlistViewPart()
        {
            int i = 0;
            foreach (var item in Model.Context.Parts)
            {
                i++;
                ListViewItem listItem = new ListViewItem();
                listItem.Text = item.Name; 
                listItem.SubItems.Add(item.Cost.ToString());
                Model.Totalcost += item.Cost * 3;

                listItem.SubItems.Add(3.ToString());
                listItem.SubItems.Add(item.Id.ToString());

                View.ListViewOrder.Items.Add(listItem);
                if (i > 5)
                    break;
            }
        }*/

    }


}
