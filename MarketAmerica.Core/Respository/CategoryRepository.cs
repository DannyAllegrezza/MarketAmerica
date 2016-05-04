using MarketAmerica.Core.Models;
using MarketAmerica.Core.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarketAmerica.Core.Respository
{
    public class CategoryRepository : ICategoryRepository
    {

        // Used inside of the Repository to hold a List of the Auto sub-categories (MOCK)
        private static List<Category> autoSubCategories = new List<Category>()
        {
            new Category()
            {
                name = "Exterior",
                productCount = 97663,
                id = "2-2193992",
                products = new List<Product>()
                {
                    new Product()
                    {
                        name = "LEVEL-TREK LT80060 Small Wheel Chock",
                        minimumPrice = "14.68",
                        description = "Test test test test test test test",
                        imageURL = "http://edge.shop.com/ccimg.shop.com/220000/226800/226851/products/559024616.jpg",
                        id = 1218141603
                    },
                    new Product()
                    {
                        name = "Speeco 01054100-1542 Ratchet Jack",
                        minimumPrice = "48.84",
                        description = "Completely interchangeable with most clevis mounted hydraulic cylinders. 1-1/4 ft. diameter UNC heavy duty thread, 1 in. Pin diameter. Operator safety assured by a positive stop at the maximum open adjustment. Includes two pins and...",
                        imageURL = "http://edge.shop.com/ccimg.shop.com/250000/251800/251872/products/1120879102.jpg",
                        id = 1088573563
                    }
                }
            },
            new Category()
            {
                name = "Under Car & Hood",
                productCount = 71825,
                id = "2-2194103",
                products = new List<Product>()
                {
                    new Product()
                    {
                        name = "MPT Industries MPT26 MPT THIRTY-K 10W40  100% Synthetic Motor Oil",
                        minimumPrice = "14.68",
                        description = "10W40 Hi-Performance  Fully Synthetic Motor Oil&#44; quart.  100% Synthetic with no petroleum or viscosity modifiers for cooler&#44; smoother running engines.  Extended drain intervals up to 30&#44;000 miles. Longer engine life. Better fuel...",
                        imageURL = "http://edge.shop.com/ccimg.shop.com/250000/251800/251872/products/1386122288.jpg",
                        id = 1354750681
                    },
                    new Product()
                    {
                        name = "Speeco 01054100-1542 Ratchet Jack",
                        minimumPrice = "48.84",
                        description = "Completely interchangeable with most clevis mounted hydraulic cylinders. 1-1/4 ft. diameter UNC heavy duty thread, 1 in. Pin diameter. Operator safety assured by a positive stop at the maximum open adjustment. Includes two pins and...",
                        imageURL = "http://edge.shop.com/ccimg.shop.com/250000/251800/251872/products/1120879102.jpg",
                        id = 1088573563
                    }
                }
            }
        };

        public async Task<IEnumerable<Category>> GetAllAutomotiveSubCategoriesAsync()
        {
            var client = new HttpClient();

            var result = await client.GetStringAsync(MarketAmericaApiUrls.BaseURLForProducts);

            return JsonConvert.DeserializeObject<Category>(result).categories;
        }

        public Product GetProductById(int productId)
        {
            IEnumerable<Product> product =
                from category in autoSubCategories
                from Product in category.products
                where Product.id == productId
                select Product;
            return product.FirstOrDefault();
        }

        public List<Category> GetAllCategories()
        {
            return autoSubCategories;
        }

        public List<Product> GetAllProductsForCategoryById(string categoryId)
        {
            // Get me all the 
            var productsCategory = autoSubCategories.Where(c => c.id == categoryId).FirstOrDefault();
            if (productsCategory != null)
            {
                return productsCategory.products.ToList();
            }
            return null;
        }
    }

    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAutomotiveSubCategoriesAsync();
        Product GetProductById(int productId);
    }
}
