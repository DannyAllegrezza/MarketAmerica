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
using MarketAmerica.Droid.Utility;

namespace MarketAmerica.Droid.Adapters
{
    public class ProductListAdapter : BaseAdapter<Product>
    {
        public List<Product> items { get; set; }
        public Activity context { get; set; }

        public ProductListAdapter(Activity context, List<Product> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            // Returns the position of the item in the List.
            return position;
        }

        public override Product this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var imageBitmap = ImageHelper.GetImageBitmapFromUrl(item.imageURL);

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.ProductRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.productNameTextView).Text = item.name;
            convertView.FindViewById<TextView>(Resource.Id.productDescriptionTextView).Text = item.shortDescription;
            convertView.FindViewById<TextView>(Resource.Id.productPriceTextView).Text = "$" + item.minimumPrice;
            convertView.FindViewById<ImageView>(Resource.Id.productImageView).SetImageBitmap(imageBitmap);
            return convertView;
        }

    }
}

