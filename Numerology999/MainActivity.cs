using Android.App;
using Android.Widget;
using Android.OS;

using Android.Content;
using Android.Runtime;
using Android.Views;

namespace Numerology999
{
    [Activity(
        Label = "Numerology999", 
        MainLauncher = true, 
        Icon = "@drawable/icon", 
        Theme = "@android:style/Theme.DeviceDefault.Light.NoActionBar"
        )]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            
            // get viewes
            EditText input = FindViewById<EditText>(Resource.Id.editTextUserInput);
            TextView text = FindViewById<TextView>(Resource.Id.textViewText);

            // remove sample text
            input.Text = "";
            text.Text = "";

            // set event action
            input.KeyPress += (object sender, View.KeyEventArgs e) => {
                e.Handled = false;
                showText();
            };
        }

        public void showText()
        {
            //Toast.MakeText(this, "Procedimento de logon ", ToastLength.Long).Show();
            using (System.IO.Stream xmlFile = Assets.Open("table.xml"))
            {
                DataWalker walker = new DataWalker(xmlFile);
                EditText input = FindViewById<EditText>(Resource.Id.editTextUserInput);
                TextView text = FindViewById<TextView>(Resource.Id.textViewText);
                text.Text = walker.GetText(input.Text);
            }
                
        }
    }
    
}

