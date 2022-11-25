using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebShopClientDesktop.ControlLayer;
using WebShopClientDesktop.ModelLayer;

namespace WebShopClientDesktop
{
    public partial class Form1 : Form
    {
        readonly OrderControl _orderControl;
        public Form1()
        {
            InitializeComponent();
            _orderControl = new OrderControl();
        }

        private async void buttonGetOrders_Click(object sender, EventArgs e)
        {
            string processText = "Ok";
            List<Order>? fetchedOrders = await _orderControl.GetAllOrders();
            if (fetchedOrders != null)
            {
                if (fetchedOrders.Count >= 1)
                {
                    processText = "OK";
                }
                else
                {
                    processText = "No Orders found";

                }
            }
            else
            {
                processText = "Failure: An error occurred";
            }
            labelProcessText.Text = processText;
            listBoxOrders.DataSource = fetchedOrders;
        }
    }

}
