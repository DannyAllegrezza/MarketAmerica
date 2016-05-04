using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAmerica.Core.Models
{

    public class Product
    {
        public string name { get; set; }
        public string maximumPrice { get; set; }
        public string minimumPrice { get; set; }
        public int id { get; set; }
        public string brand { get; set; }
        public string shortDescription { get; set; }
        public string description { get; set; }
        public float cashBack { get; set; }
        public float distributorCashBack { get; set; }
        public int ciPoints { get; set; }
        public int bv { get; set; }
        public float ibv { get; set; }
        public bool freeShipping { get; set; }
        public string catalogName { get; set; }
        public string catalogDescription { get; set; }
        public string catalogLogoImageFileName { get; set; }
        public string imageURL { get; set; }
        public string referralUrl { get; set; }
        public bool autoShip { get; set; }
        public bool onSale { get; set; }
        public object disclaimer { get; set; }
        public Category category { get; set; }
        public Reviewdata reviewData { get; set; }
        public List<Link> links { get; set; }
    }

    public class Reviewdata
    {
        public string count { get; set; }
        public int rating { get; set; }
    }

}
