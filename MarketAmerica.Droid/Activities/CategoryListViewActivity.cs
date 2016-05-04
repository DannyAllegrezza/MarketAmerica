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
    [Activity(Label = "Automotive Categories", MainLauncher = true)]
    public class CategoryListViewActivity : Activity
    {
        private ListView categoryListView;                  // Stores the ListView
        private List<Category> allCategories;               // What we will bind our data to
        private CategoryRepository categoryRepository;      // Used to get all of the Categories from the service

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Sets the View for this Activity            
            SetContentView(Resource.Layout.CategoryMenuView);                                           
            categoryListView = FindViewById<ListView>(Resource.Id.categoryListView);

            categoryRepository = new CategoryRepository();
            allCategories = await categoryRepository.GetAllAutomotiveSubCategoriesAsync();

            // Now, we need to bind the data to the ListView. We use an Adapter for this
            categoryListView.Adapter = new CategoryListAdapter(this, allCategories);                    
            categoryListView.FastScrollEnabled = true;

            categoryListView.ItemClick += CategoryListView_ItemClick;
        }

        private void CategoryListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var category = allCategories[e.Position]; // Get the "Position" id of the item being clicked

            var intent = new Intent();
            intent.SetClass(this, typeof(ProductListViewActivity));
            intent.PutExtra("selectedCategoryId", category.id);

            StartActivityForResult(intent, 100); // The 2nd param is the "Request Code"
        }

    }
}