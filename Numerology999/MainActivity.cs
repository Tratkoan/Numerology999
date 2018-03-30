using Android.App;
using Android.Widget;
using Android.OS;

using Android.Content;
using Android.Runtime;
using Android.Views;

namespace Numerology999
{
    [Activity(Label = "Numerology999", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            // Preparing the button
            Button showButton = FindViewById<Button>(Resource.Id.showButton);

            // set onclick listener here, by deleting some process
            showButton.Click += delegate {
                showButtonClick();
            };

        }

        public void showButtonClick()
        {
            //Toast.MakeText(this, "Procedimento de logon ", ToastLength.Long).Show();
            using (System.IO.Stream xmlFile = Assets.Open("Table.xml"))
            {
                DataWalker walker = new DataWalker(xmlFile);
                TextView text = FindViewById<TextView>(Resource.Id.textViewText);
                text.Text = walker.localTable.Row[0].Cell[1].Data.ToString();
            }
                
        }
    }
    
}

