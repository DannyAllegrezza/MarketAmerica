using MarketAmerica.Core.Models;
using MarketAmerica.Core.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MarketAmerica.Core.Respository
{
    public class CategoryRepository : ICategoryRepository
    {
        private static List<Category> autoSubCategories = new List<Category>();
        private static List<Product> autoProducts = new List<Product>();

        public CategoryRepository()
        {

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

        public async Task<List<Category>> GetAllAutomotiveSubCategoriesAsync()
        {
            var responseJson = "";
            using (var client = new HttpClient())
            {
                var uri = MarketAmericaApiUrls.BaseURLForAutoCategories + MarketAmericaApiUrls.ParamsForAutoSubCategory + MarketAmericaApiUrls.AutoSubCategories;
                client.DefaultRequestHeaders.Add("apikey", MarketAmericaApiUrls.ApiKey);

                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    responseJson = await response.Content.ReadAsStringAsync();
                }
            }
            autoSubCategories = JsonConvert.DeserializeObject<Category>(responseJson).categories.ToList();

            return autoSubCategories;
        }

        public async Task<List<Product>> GetAllProductsForCategoryByIdAsync(string categoryId)
        {
            var responseJson = "";

            using (var client = new HttpClient())
            {
                var uri = MarketAmericaApiUrls.BaseURLForAutoCategories + MarketAmericaApiUrls.ParamsForAutoSubCategory + categoryId;
                client.DefaultRequestHeaders.Add("apikey", MarketAmericaApiUrls.ApiKey);

                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    responseJson = await response.Content.ReadAsStringAsync();
                }
            }
            autoProducts = JsonConvert.DeserializeObject<Product>(responseJson).products.ToList();
            return autoProducts;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var responseJson = "";

            using (var client = new HttpClient())
            {
                var uri = MarketAmericaApiUrls.BaseURLForAutoCategories + "/" + productId + MarketAmericaApiUrls.ParamsForSingleProduct;

                client.DefaultRequestHeaders.Add("apikey", MarketAmericaApiUrls.ApiKey);

                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    responseJson = await response.Content.ReadAsStringAsync();
                }
            }
            var product = JsonConvert.DeserializeObject<Product>(responseJson);
            return product;
        }
    }

    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAutomotiveSubCategoriesAsync();
        Product GetProductById(int productId);
    }
}
