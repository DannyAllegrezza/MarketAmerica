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
    public class CategoryListAdapter : BaseAdapter<Category>
    {
        public List<Category> items { get; set; }
        public Activity context { get; set; }

        public CategoryListAdapter(Activity context, List<Category> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            // Returns the position of the item in the List.
            return position;
        }

        public override Category this[int position]
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
            //var imageBitmap = ImageHelper.GetImageBitmapFromUrl(item.products.FirstOrDefault().imageURL);

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.CategoryRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.categoryNameTextView).Text = item.name;
            convertView.FindViewById<TextView>(Resource.Id.categoryDescriptionTextView).Text = String.Format("View all {0} {1} products!", item.productCount, item.name);
            //convertView.FindViewById<ImageView>(Resource.Id.categoryImageView).SetImageBitmap(imageBitmap);
            return convertView;
        }

    }
}

