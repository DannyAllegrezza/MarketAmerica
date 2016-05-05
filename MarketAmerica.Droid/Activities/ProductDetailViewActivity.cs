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
using MarketAmerica.Droid.Utility;

namespace MarketAmerica.Droid.Activities
{
    [Activity(Label = "SHOP.com Product Details", MainLauncher = false, Icon = "@drawable/icon")]
    public class ProductDetailViewActivity : Activity
    {
        private ImageView productImageView;
        private TextView productNameTextView, productDescriptionTextView, productPrice;

        private Product selectedProduct;
        private CategoryRepository categoryRepository;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            

            categoryRepository = new CategoryRepository();
            var selectedProductId = Intent.Extras.GetInt("selectedProductId");
            selectedProduct = await categoryRepository.GetProductByIdAsync(selectedProductId);

            SetContentView(Resource.Layout.ProductDetailView);

            FindViews();
            BindProductDataToViews();
        }

        private void FindViews()
        {
            productImageView = FindViewById<ImageView>(Resource.Id.imgProduct);
            productNameTextView = FindViewById<TextView>(Resource.Id.txtViewProductName);
            productDescriptionTextView = FindViewById<TextView>(Resource.Id.txtViewProductDescription);
            productPrice = FindViewById<TextView>(Resource.Id.txtViewPriceValue);
        }

        private void BindProductDataToViews()
        {
            productNameTextView.Text = selectedProduct.name;
            productDescriptionTextView.Text =  selectedProduct.description;
            productPrice.Text = selectedProduct.minimumPrice;

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl(selectedProduct.imageURL);
            productImageView.SetImageBitmap(imageBitmap);
        }

        private void HandleUserEvents()
        {
            // Handle any click events on buttons
            //TODO: handle a "View in Browser" button
            //productImageView.Click += productImageView_Click;
        }

        private void productImageView_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}