using Android.App;
using Android.Icu.Text;
using Android.OS;
using Android.Runtime;
using Android.Text.Method;
using Android.Widget;
using AndroidX.AppCompat.App;
using Java.Lang;
using AlertDialog = Android.App.AlertDialog;
using Android.Views;

namespace NumerosRomanos
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            int miles = 0, restmiles = 0, rescen = 0, resdec = 0, centenas = 0, decenas = 0, unidades = 0, i = 0, x = 0, n = 0, y = 0;

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            EditText numero = FindViewById<EditText>(Resource.Id.numero);
            EditText numero2 = FindViewById<EditText>(Resource.Id.numero2);
            Button boton = FindViewById<Button>(Resource.Id.ejecutar);
            TextView lista = FindViewById<TextView>(Resource.Id.lista);

            Button limpiar = FindViewById<Button>(Resource.Id.ejecutar2);

            
            
            boton.Click += (s, e) =>
            {
                
                if (numero.Text == string.Empty || numero2.Text == string.Empty)
                {
                    AlertDialog.Builder alerta0 = new AlertDialog.Builder(this);

                    alerta0.SetTitle("ERROR");
                    alerta0.SetMessage("Ambos campos deben de contener un valor");

                    alerta0.SetPositiveButton("OK", (senderAlert, args) => { });

                    Dialog dialog0 = alerta0.Create();
                    dialog0.Show();
                }
                else
                {
                    lista.Text = "";
                    n = int.Parse(numero.Text);
                    y = int.Parse(numero2.Text);


                    if (n <= 0 || n > 3999 || y <= 0 || y > 3999)
                    {
                        AlertDialog.Builder alerta = new AlertDialog.Builder(this);

                        alerta.SetTitle("ERROR");
                        alerta.SetMessage("Deben ingresarse numeros entre el 1 y el 3999");

                        alerta.SetPositiveButton("OK", (senderAlert, args) => { });

                        Dialog dialog = alerta.Create();
                        dialog.Show();
                    }
                    else
                    {
                        if (n > y)
                        {
                            AlertDialog.Builder alerta2 = new AlertDialog.Builder(this);

                            alerta2.SetTitle("ERROR");
                            alerta2.SetMessage("El primer valor no debe de ser mayor al segundo");

                            alerta2.SetPositiveButton("OK", (senderAlert, args) => { });

                            Dialog dialog2 = alerta2.Create();
                            dialog2.Show();
                        }
                        else
                        {
                            for (i = n; i <= y; i++)
                            {
                                x = i;
                                miles = x / 1000;
                                restmiles = x % 1000;
                                centenas = restmiles / 100;
                                rescen = restmiles % 100;
                                decenas = rescen / 10;
                                resdec = rescen % 10;
                                unidades = resdec / 1;


                                string ml = "";
                                string cn = "";
                                string dc = "";
                                string un = "";

                                switch (miles)
                                {
                                    case 1:
                                        ml = "M";
                                        break;
                                    case 2:
                                        ml = ("MM");
                                        break;
                                    case 3:
                                        ml = ("MMM");
                                        break;
                                }
                                switch (centenas)
                                {
                                    case 1:
                                        cn = "C";
                                        break;
                                    case 2:
                                        cn = "CC";
                                        break;
                                    case 3:
                                        cn = "CCC";
                                        break;
                                    case 4:
                                        cn = "CD";
                                        break;
                                    case 5:
                                        cn = "D";
                                        break;
                                    case 6:
                                        cn += "DC";
                                        break;
                                    case 7:
                                        cn = "DCC";
                                        break;
                                    case 8:
                                        cn = "DCCC";
                                        break;
                                    case 9:
                                        cn = "CM";
                                        break;
                                }
                                switch (decenas)
                                {
                                    case 1:
                                        dc = "X";
                                        break;
                                    case 2:
                                        dc = "XX";
                                        break;
                                    case 3:
                                        dc = "XXX";
                                        break;
                                    case 4:
                                        dc = "XL";
                                        break;
                                    case 5:
                                        dc = "L";
                                        break;
                                    case 6:
                                        dc = "LX";
                                        break;
                                    case 7:
                                        dc = "LXX";
                                        break;
                                    case 8:
                                        dc = "LXXX";
                                        break;
                                    case 9:
                                        dc = "XC";
                                        break;
                                }
                                switch (unidades)
                                {
                                    case 1:
                                        un = "I";
                                        break;
                                    case 2:
                                        un = "II";
                                        break;
                                    case 3:
                                        un = "III";
                                        break;
                                    case 4:
                                        un = "IV";
                                        break;
                                    case 5:
                                        un = "V";
                                        break;
                                    case 6:
                                        un = "VI";
                                        break;
                                    case 7:
                                        un = "VII";
                                        break;
                                    case 8:
                                        un = "VIII";
                                        break;
                                    case 9:
                                        un = "IX";
                                        break;
                                }

                                lista.Text += ml + cn + dc + un + "\n";
                            }
                        }


                    }
                }
                
            };

            limpiar.Click += (s, e) =>
            {
                lista.Text = "";
                numero.Text = "";
                numero2.Text = "";
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}