using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGLOrderApp.Models.Links
{
    public class OrderLink : ILink
    {
        private readonly int _orderId;
        public string Href => $"api/{Rel}/{_orderId}";

        public string Rel => "orders";

        public OrderLink(int orderId)
        {
            _orderId = orderId;
        }
    }
}
