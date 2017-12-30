using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Views;

namespace DynamicUI
{
    [Activity(Label = "DynamicUI", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        List<TextView> text = new List<TextView>();
        List<string> tvText;
        Context context;
        private View myView;
        int counter = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            tvText = new List<string>
            {
                "Camera", "Canola", "Chemical",
                "Cow", "Day", "Default shed",
                "Farm", "Favourites", "Fertilisers",
                "Fuel", "Grain", "News"
            };

            var tableView = FindViewById<TableLayout>(Resource.Id.tableLayout1);
            context = tableView.Context;

            for (var i = 0; i < 4; ++i) // row
                for (var j = 0; j < 3; ++j) // box
                    AddAndInflate(i, j);
        }

        private void DisplayText(object sender, EventArgs e)
        {
            var btn = sender as LinearLayout;
            var tag = (int)btn.Tag;
            Toast.MakeText(context, text[tag].Text, ToastLength.Long).Show();
        }

        private void AddAndInflate(int trow, int tcol)
        {
            TableRow row = null;
            ImageView image = null;
            TextView tv = null;
            switch (trow)
            {
                case 0:
                    row = FindViewById<TableRow>(Resource.Id.tableRow1);
                    break;
                case 1:
                    row = FindViewById<TableRow>(Resource.Id.tableRow2);
                    break;
                case 2:
                    row = FindViewById<TableRow>(Resource.Id.tableRow3);
                    break;
                case 3:
                    row = FindViewById<TableRow>(Resource.Id.tableRow4);
                    break;
            }

            var factory = LayoutInflater.From(this);
            myView = factory.Inflate(Resource.Layout.FTImageButton, null);
            image = myView.FindViewById<ImageView>(Resource.Id.imgImage);
            tv = myView.FindViewById<TextView>(Resource.Id.txtText);
            tv.Text = tvText[counter];

            Console.WriteLine("Row = {0}, Col = {1}, Joint = {2}", trow, tcol, trow + tcol);

            switch (counter)
            {
                case 0:
                    image.SetImageResource(Resource.Drawable.settings);
                    break;
                case 1:
                    image.SetImageResource(Resource.Drawable.canola);
                    break;
                case 2:
                    image.SetImageResource(Resource.Drawable.chemicals_toolshed);
                    break;
                case 3:
                    image.SetImageResource(Resource.Drawable.cow);
                    break;
                case 4:
                    image.SetImageResource(Resource.Drawable.day);
                    break;
                case 5:
                    image.SetImageResource(Resource.Drawable.defaultshed);
                    break;
                case 6:
                    image.SetImageResource(Resource.Drawable.farm);
                    break;
                case 7:
                    image.SetImageResource(Resource.Drawable.favourites);
                    break;
                case 8:
                    image.SetImageResource(Resource.Drawable.fertilise_toolshed);
                    break;
                case 9:
                    image.SetImageResource(Resource.Drawable.fuel_level);
                    break;
                case 10:
                    image.SetImageResource(Resource.Drawable.grain_level);
                    break;
                case 11:
                    image.SetImageResource(Resource.Drawable.news);
                    break;
            }

            text.Add(tv);
            myView.Tag = counter;
            myView.LayoutParameters = new TableRow.LayoutParams(tcol);
            myView.Click += DisplayText;
            row.AddView(myView);
            counter++;
        }
    }
}


