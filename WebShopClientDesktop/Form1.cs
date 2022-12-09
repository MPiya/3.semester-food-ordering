using System;
using WebShopClientDesktop.ControlLayer;
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

		private async void ButtonGetOrders_Click(object sender, EventArgs e)
		{
			string processText = "OK";
			List<Order>? fetchedOrders = await _orderControl.GetAllOrders();
			if (fetchedOrders != null)
			{
				if (fetchedOrders.Count >= 1)
				{
					processText = "Ok";
				}
				else
				{
					processText = "No persons found";
				}
			}
			else
			{
				processText = "Failure: An error occurred";
			}
			label1.Text = processText;
			listBoxOrders.DataSource = fetchedOrders;

		}

        private void listBoxOrders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}