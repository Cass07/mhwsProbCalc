using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mhwsProbCalc
{
    class ItemsFactory
    {
        public static Items CreateItems(ItemEntry[] itemArray)
        {
            return new Items(itemArray);
        }
    }
}
