using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopClientDesktop.ModelLayer
{
    public class Order
    {
        private string custId;

        public Order(string pment, string note) { }

        public Order(int customerId, string paymentType, string notes) {
            customerId = customerId;
            paymentType = paymentType;
            notes = notes;
        }

        public Order(string pment, string note, string custId) : this(pment, note)
        {
            this.custId = custId;
        }

        public Order(int customerId, string paymentType, string notes, String fullOrder) : this(customerId, paymentType,fullOrder) {
            notes = notes;
        }
        public int customerId { get; set; }
        public string paymentType { get; set; }
        public string notes { get; set; }
        public String fullOrder { get; set; }


        public override string? ToString()
        {
            string? oText = fullOrder;
            if(notes != null)
            {
                oText += " - Pay attention, there is a note:" + notes;
            }
            return oText;
        }

    }
}
