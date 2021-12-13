using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MyFirstApp.CustomeRenderer;
using MyFirstApp.Droid.CustomRederer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyCustomeButton), typeof(MyButtonRenderer))]
namespace MyFirstApp.Droid.CustomRederer
{
    public class MyButtonRenderer : ButtonRenderer
    {
        public MyButtonRenderer(Context context) : base(context)
        {

        }
        //protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        //{
        //    base.OnElementChanged(e);
        //    if (Control != null)
        //    {
        //        Control.SetShadowLayer(5, 3, 3, Color.Black.ToAndroid());
        //        Control.SetBackgroundColor(Android.Graphics.Color.Pink);
        //        Control.SetTextColor(Android.Graphics.Color.White);
        //    }
        //}
        private GradientDrawable _gradientBackground;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            var view = (MyCustomeButton)Element;
            if (view == null) return;
            Paint(view);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == MyCustomeButton.CustomBorderColorProperty.PropertyName ||
                 e.PropertyName == MyCustomeButton.CustomBorderRadiusProperty.PropertyName ||
                 e.PropertyName == MyCustomeButton.CustomBorderWidthProperty.PropertyName)
            {
                if (Element != null)
                {
                    Paint((MyCustomeButton)Element);
                }
            }
        }
        private void Paint(MyCustomeButton view)
        {
            _gradientBackground = new GradientDrawable();
            _gradientBackground.SetShape(ShapeType.Rectangle);
            _gradientBackground.SetColor(view.CustomBackgroundColor.ToAndroid());
            // Thickness of the stroke line  
            _gradientBackground.SetStroke((int)view.CustomBorderWidth, view.CustomBorderColor.ToAndroid());
            // Radius for the curves  
            _gradientBackground.SetCornerRadius(
                DpToPixels(this.Context, Convert.ToSingle(view.CustomBorderRadius)));
            // set the background of the label  
            Control.SetBackground(_gradientBackground);
        }

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}