using Android.App;
using Android.OS;
using Android.Widget;

namespace SimpleNumberCounter
{
    [Activity(Label = "SimpleNumberCounter", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private int _count;

        /// <summary>Launch MainActivity with Main layout and wire up UI button events.</summary>
        /// <param name="bundle">Saved state from destruction - the count.</param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get state from previously destroyed app.
            if (bundle != null)
                _count = bundle.GetInt("count");

            var plusOneButton = FindViewById<Button>(Resource.Id.Plus1Button);
            var minusOneButton = FindViewById<Button>(Resource.Id.Minus1Button);
            var plusFiveButton = FindViewById<Button>(Resource.Id.Plus5Button);
            var minusFiveButton = FindViewById<Button>(Resource.Id.Minus5Button);
            var resetButton = FindViewById<Button>(Resource.Id.ResetButton);
            var counterText = FindViewById<TextView>(Resource.Id.CountText);

            ChangeCount(0, counterText);

            plusOneButton.Click += (sender, e) => { ChangeCount(1, counterText); };
            minusOneButton.Click += (sender, e) => { ChangeCount(-1, counterText); };
            plusFiveButton.Click += (sender, e) => { ChangeCount(5, counterText); };
            minusFiveButton.Click += (sender, e) => { ChangeCount(-5, counterText); };
            resetButton.Click += (sender, args) => { ChangeCount(-_count, counterText); };
        }

        /// <summary>Changes count and updates UI.</summary>
        /// <param name="amount">The amount to add to the count.</param>
        /// <param name="counter">The count UI element.</param>
        private void ChangeCount(int amount, TextView counter)
        {
            _count += amount;
            counter.Text = _count.ToString();
        }

        /// <summary>Save state on destruction.</summary>
        /// <param name="outState">The state save bundle</param>
        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("count", _count);
            base.OnSaveInstanceState(outState);
        }
    }
}