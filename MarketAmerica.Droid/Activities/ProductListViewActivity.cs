using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MarketAmerica.Core.Models;
using MarketAmerica.Core.Respository;
using MarketAmerica.Droid.Adapters;

namespace MarketAmerica.Droid.Activities
{
    [Activity(Label = "View all Products", MainLauncher = false)]
    public class ProductListViewActivity : Activity
    {
        private ListView productListView; // Stores the ListView
        private List<Product> products; // What we will bind our data to
        private CategoryRepository categoryRepository; // Used to get all of the Categories from the service

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set the Contents View...
            SetContentView(Resource.Layout.CategoryMenuView);

            // Now, find the View we want to use (I named the ListView "categoryListView" in the CategoryMenuView.axml)
            productListView = FindViewById<ListView>(Resource.Id.categoryListView);

            // Instantiate the Repository..
            categoryRepository = new CategoryRepository();

            // Get the Category ID that was just passed in from the previous CategoryListView Activity
            var categoryId = Intent.Extras.GetString("selectedCategoryId");

            // Fetch all the Categories 
            products = categoryRepository.GetAllProductsForCategoryById(categoryId);

            // Now, we need to bind the data to the ListView. We use an Adapter for this
            productListView.Adapter = new ProductListAdapter(this, products);
            productListView.FastScrollEnabled = true;

            productListView.ItemClick += ProductListView_ItemClick;
        }

        private void ProductListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var singleProduct = products[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(ProductDetailViewActivity));
            intent.PutExtra("selectedProductId", singleProduct.id);

            StartActivityForResult(intent, 100);
        }
    }
}