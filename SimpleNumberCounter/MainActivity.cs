using Android.App;
using Android.OS;
using Android.Widget;

namespace SimpleNumberCounter
{
    [Activity(Label = "SimpleNumberCounter", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private int _count;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var plusOneButton = FindViewById<Button>(Resource.Id.Plus1Button);
            var minusOneButton = FindViewById<Button>(Resource.Id.Minus1Button);
            var plusFiveButton = FindViewById<Button>(Resource.Id.Plus5Button);
            var minusFiveButton = FindViewById<Button>(Resource.Id.Minus5Button);
            var resetButton = FindViewById<Button>(Resource.Id.ResetButton);
            var counterText = FindViewById<TextView>(Resource.Id.CountText);

            plusOneButton.Click += (sender, e) => { ChangeCount(1, counterText); };
            minusOneButton.Click += (sender, e) => { ChangeCount(-1, counterText); };
            plusFiveButton.Click += (sender, e) => { ChangeCount(5, counterText); };
            minusFiveButton.Click += (sender, e) => { ChangeCount(-5, counterText); };
            resetButton.Click += (sender, args) => { ChangeCount(-_count, counterText); };
        }

        private void ChangeCount(int amount, TextView counter)
        {
            _count += amount;
            counter.Text = _count.ToString();
        }
    }
}