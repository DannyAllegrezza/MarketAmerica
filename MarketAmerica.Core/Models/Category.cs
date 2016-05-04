using System.Collections.Generic;

namespace MarketAmerica.Core.Models
{
    // A Category is a Group of products

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public int numberOfProducts { get; set; }
        public int productCount { get; set; }
        public IEnumerable<Product> products { get; set; }
        public IEnumerable<Category> categories { get; set; } // Sub-Categories which are nested in a Category...
        public IEnumerable<Brand> brands { get; set; }
        public IEnumerable<Seller> sellers { get; set; }
        public IEnumerable<Pricerange> priceRanges { get; set; }
    }


    public class Brand
    {
        public string name { get; set; }
        public int productCount { get; set; }
        public string id { get; set; }
    }

    public class Seller
    {
        public string name { get; set; }
        public int productCount { get; set; }
        public string id { get; set; }
    }

    public class Pricerange
    {
        public float minPrice { get; set; }
        public float maxPrice { get; set; }
        public int productCount { get; set; }
        public string id { get; set; }
    }

}