using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a1.Models
{
    public class ShoppingList
    {
        List<String> MyList = new List<String>();

        public void AddToMyList(string name)
        {
            MyList.Add(name);
        }
    }
}