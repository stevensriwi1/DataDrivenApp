using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataDrivenApp
{
    public class Products
    {
        private string name;
        public string description { get; set; }
        public float price { get; set; }

        public string Name
        {
            get { return name; }
            set { 
                if(value.Length > 0)
                {
                    name = value;
                }
            }
        }

    }
}