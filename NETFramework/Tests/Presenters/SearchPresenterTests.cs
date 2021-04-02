using HW.Common;
using HW.Model;
using HW.Views;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Model;

namespace Tests.Presenters
{
    [TestFixture]
    public class SearchPresenterTests : BasePresenter<ISearchFormView>
    {

        public IModel Model { get; set; }

        public SearchPresenterTests()
        {
            Model = new MyModelNew(new MyStoreContext());
            View = new SearchForm();

            //View.ClientIndexCheange += ClientIndexCheangeTest;
            //View.OrderIndexCheange += OrderIndexCheangeTest;

            // Arrange 
            foreach (var item in Model.Context.Clients)       //  add Client list to ComboBox
            {
                View.ComboBoxClient.Items.Add(item.Name);
            }
        }

        [TestCase]
        public void SearchPresenterConstructorTests()
        {
            //Act
            int count = View.ComboBoxClient.Items.Count;

            // Assert
            Assert.AreEqual(6, count);
        }

        [TestCase(1, 2)]
        [TestCase(2, 2)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        [TestCase(5, 2)]
        [TestCase(6, 0)]
        public void ClientIndexCheangeTest(int index, int result)
        {
            View.ComboBoxOrder.Items.Clear();

            // Arrange 
            var client = Model.Context.Clients.Find(index);  //  уже проверили

            //Act
            foreach (var item in Model.Context.Orders)       //  add Client list to ComboBox
            {
                //Act.1
                if (item.ClientFk == client.Id)
                    View.ComboBoxOrder.Items.Add(item.Id);
            }

            // Assert
            Assert.AreEqual(result, View.ComboBoxOrder.Items.Count);
        }

        [TestCase(8, " Do not info Null ")]
        public void OrderIndexCheangeTest(int orderIndex, string result)
        {

            // Arrange 
            var order = Model.Context.Orders.Find(orderIndex);

            //Act
            View.LabelId.Text = order.Id.ToString();
            var Ordete = order.OrderData.Value;

            //Act.1
            if (order.OrderData != null)
            {
                if (order.OrderData > (DateTime.Now.AddDays(-1)))
                {
                    View.LabelStatus.Text = "In Work";
                }
                else if (order.OrderData > (DateTime.Now.AddDays(-3)))
                {
                    View.LabelStatus.Text = "Go";
                }
                else
                {
                    View.LabelStatus.Text = "In The house";
                }
                View.LabelDate.Text = order.OrderData.ToString();
            }
            else if (order.OrderData == null)
            {
                View.LabelDate.Text = "NULL";
                View.LabelStatus.Text = " Do not info Null ";
            }

            // Assert
            Assert.AreEqual(result, View.LabelStatus.Text);
        }
    }
}
