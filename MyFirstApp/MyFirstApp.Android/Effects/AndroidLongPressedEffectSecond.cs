using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyFirstApp.Droid.Effects;
using MyFirstApp.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("MyFirstApp")]
[assembly: ExportEffect(typeof(AndroidLongPressedEffectSecond), "LongPressedEffectSecond")]
namespace MyFirstApp.Droid.Effects
{
    public class AndroidLongPressedEffectSecond : PlatformEffect
    {
        private bool _attached;
        private Timer _timer;
        private bool _isLongPressed;
        protected override void OnAttached()
        {
            if (!_attached)
            {
                if (Control != null)
                {
                    Control.Touch += OnTouch;
                }
                else
                {
                    Container.Touch += OnTouch;
                }
                _attached = true;
            }
        }

        private void OnTouch(object sender, Android.Views.View.TouchEventArgs e)
        {
            float x_Mouse_Btn = e.Event.GetX();
            float y_Mouse_Btn = e.Event.GetY();
            float x_Btn_Screen = Control.GetX();
            float y_Btn_Screen = Control.GetY();
            float x_Mouse_Screen = x_Mouse_Btn + x_Btn_Screen;
            float y_Mouse_Screen = y_Mouse_Btn + y_Btn_Screen;
            float HeightBtn = Control.Height;
            float WidthBtn = Control.Width;

            if (e.Event.Action == MotionEventActions.Down)
            {
                Console.WriteLine("Press");
                _isLongPressed = true;
                Control.SetBackgroundColor(Android.Graphics.Color.LightPink);
                Console.WriteLine("");

                Console.WriteLine("Toa do cua Chuot: x, y ({0}, {1})", x_Mouse_Btn, y_Mouse_Btn); //toa do chuot vs btn
                Console.WriteLine("Toa do cua BTN : x1, y1 ({0}, {1})", x_Btn_Screen, y_Btn_Screen); //Toa do btn vs screen
                if (x_Mouse_Screen >= x_Btn_Screen && y_Mouse_Screen >= y_Btn_Screen && x_Mouse_Screen <= (x_Btn_Screen + WidthBtn) && y_Mouse_Screen <= (y_Btn_Screen + HeightBtn))
                    _timer = new Timer(HanldeCallBack, null, 2000, Timeout.Infinite);
            }
            else if (e.Event.Action == MotionEventActions.Up)
            {
                if (!_isLongPressed) return;
                Console.WriteLine("Drop");
                Cancel();
                Control.SetBackgroundColor(Android.Graphics.Color.HotPink);
                _isLongPressed = false;
            }
            else if (e.Event.Action == MotionEventActions.Move)
            {
                //Xử lý Move khỏi btn -> Hủy Event
                Console.WriteLine("x, y ({0}, {1})", x_Mouse_Btn, y_Mouse_Btn);
                if (x_Mouse_Screen > (x_Btn_Screen + WidthBtn) && y_Mouse_Screen > (y_Btn_Screen + HeightBtn) ||
                    x_Mouse_Screen <= (x_Btn_Screen + WidthBtn) && y_Mouse_Screen > (y_Btn_Screen + HeightBtn) ||
                    x_Mouse_Screen > (x_Btn_Screen + WidthBtn) && y_Mouse_Screen <= (y_Btn_Screen + HeightBtn) ||
                    x_Mouse_Screen < (x_Btn_Screen + WidthBtn) && y_Mouse_Screen < (y_Btn_Screen + HeightBtn) ||
                    x_Mouse_Screen < (x_Btn_Screen + WidthBtn) && y_Mouse_Screen >= (y_Btn_Screen + HeightBtn) ||
                    x_Mouse_Screen >= (x_Btn_Screen + WidthBtn) && y_Mouse_Screen > (y_Btn_Screen + HeightBtn))
                    Cancel();
            }
            else if (e.Event.Action == MotionEventActions.Outside)
            {
                Console.WriteLine("Outside");
            }
        }
        private void Cancel()
        {
            if (_timer == null)
            {
                return;
            }
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            _timer.Dispose();
            _timer = null;
            Console.WriteLine("Timer disposed...");
        }

        private void HanldeCallBack(object state)
        {
            var command = LongPressedEffectSecond.GetCommand(Element);
            command?.Execute(LongPressedEffectSecond.GetCommandParameter(Element));
        }

        protected override void OnDetached()
        {
            if (_attached)
            {
                if (Control != null)
                {
                    Control.Touch -= OnTouch;
                }
                else
                {
                    Container.Touch -= OnTouch;
                }
                _attached = false;
            }
        }
    }
}