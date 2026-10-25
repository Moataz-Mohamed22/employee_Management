using CQRS_lib.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_lib.Repos
{
    public interface IItemsRepo
    {
        public List<Item>  GetItems();
        public Item GetItemById(int id);
        public int AddItem(Item item);
        public int UpdateItem(Item item);
        public int DeleteItem(int id);
    }
}
