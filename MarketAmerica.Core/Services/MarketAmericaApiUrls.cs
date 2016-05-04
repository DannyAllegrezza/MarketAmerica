using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAmerica.Core.Services
{
    public class MarketAmericaApiUrls
    {
        /* Get All Auto Categories = BaseURLForProducts + ?publisherID=TEST&locale=en_us&categoryId={categoryId}
         * Specific Product Info (Details) = BaseURL + ProductID + 
         */
        public static readonly string AutoSubCategories = "1-32804";
        public static readonly string BaseURL = "https://api.shop.com/AffiliatePublisherNetwork/v1/products";
        public static readonly string BaseURLForAutoCategories = BaseURL + ParamsForAutoSubCategory;
        public static readonly string BaseURLForSingleProduct = BaseURL + "/";

        public static readonly string ApiKey = "l7xxe159f412c72d4cbfab8a0d892f3bfddd";
        public static Dictionary<string, string> ApiKeyValue
        {
            get
            {
                var apiKeyValuePair = new Dictionary<string, string>();
                apiKeyValuePair.Add("apikey", ApiKey);
                return apiKeyValuePair;
            }
        }

        public static readonly string ParamsForAutoSubCategory = "?publisherID=TEST&locale=en_US&categoryId=";
        public static readonly string ParamsForSingleProduct = "?publisherID=TEST&locale=en_US";
    }
}
