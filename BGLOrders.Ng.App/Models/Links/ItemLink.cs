using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGLOrderApp.Models.Links
{
    public class ItemLink : ILink
    {
        private readonly int _itemId;
        public string Href => $"api/item/{_itemId}";
        public string Rel => "items";

        public ItemLink(int itemId)
        {
            _itemId = itemId;
        }
    }
}
