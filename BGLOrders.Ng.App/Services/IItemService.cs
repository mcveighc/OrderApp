using BGLOrderApp.Models;
using BGLOrderApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGLOrderApp.Services
{
    public interface IItemService
    {
        IEnumerable<ItemDto> GetAll();
        ItemDto GetById(int id);
        void Add(ItemDto item);
        void Update(ItemDto item);
        void Delete(int id);
    }
}
