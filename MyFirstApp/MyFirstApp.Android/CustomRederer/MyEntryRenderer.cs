﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyFirstApp.CustomeRenderer;
using MyFirstApp.Droid.CustomRederer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyCustomeEntry),typeof(MyEntryRenderer))]
namespace MyFirstApp.Droid.CustomRederer
{
    public class MyEntryRenderer : EntryRenderer
    {
        public MyEntryRenderer(Context context):base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}