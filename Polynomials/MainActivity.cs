using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Polynomials.models;

namespace Polynomials
{
    [Activity(Label = "Wielomiany", MainLauncher = true, Icon = "@drawable/polynomial")]
    public class MainActivity : Activity
    {
        GetHorner polynomials = new GetHorner();
        int coefficient_input;
        int degree_polynomials_input;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            TextView Text_Sum = FindViewById<TextView>(Resource.Id.Text_Sum);
            TextView Text_value_degree_polynomials = FindViewById<TextView>(Resource.Id.Text_value_degree_polynomials);
            TextView Argument_value = FindViewById<TextView>(Resource.Id.Argument_value);
            TextView Text_coefficient_polynomials = FindViewById<TextView>(Resource.Id.Text_coefficient_polynomials);
            TextView Sum = FindViewById<TextView>(Resource.Id.Sum);
            EditText degree_polynomials = FindViewById<EditText>(Resource.Id.degree_polynomials);
            EditText argument = FindViewById<EditText>(Resource.Id.argument);
            EditText coefficient = FindViewById<EditText>(Resource.Id.coefficient);
            Button reset = FindViewById<Button>(Resource.Id.reset);
            Button AddCoefficient = FindViewById<Button>(Resource.Id.add);

            reset.Click += delegate
            {
                degree_polynomials.Text = "";
                argument.Text = "";
                coefficient.Text = "";
                coefficient.Enabled = false;
                Text_value_degree_polynomials.Visibility = ViewStates.Invisible;
                Text_coefficient_polynomials.Visibility = ViewStates.Invisible;
                Argument_value.Visibility = ViewStates.Invisible;
                Sum.Visibility = ViewStates.Invisible;
            };

            AddCoefficient.Click += delegate
            {
                try
                {
                    coefficient_input = int.Parse(coefficient.Text);

                    polynomials.Table_coefficient[polynomials.Int_degree_polynomials--] = coefficient_input;
                    Sum.Text += polynomials.Table_coefficient[polynomials.Int_degree_polynomials + 1] + "x^" + (int)(polynomials.Int_degree_polynomials + 1) + "+";
                    Text_coefficient_polynomials.Text = "Podaj wspólczynnik stojacy przy potedze: " + polynomials.Int_degree_polynomials;

                    if (polynomials.Int_degree_polynomials < 0)
                    {
                        Text_coefficient_polynomials.Text = "Mamy wynik!";

                        string length_expression_all = Sum.Text.ToString().Remove(Sum.Text.ToString().Length - 1);

                        Sum.Text = length_expression_all + "=" + polynomials.getSum(degree_polynomials_input);
                    }
                }
                catch
                {
                    Toast.MakeText(ApplicationContext, "Podaj cyfrę!", ToastLength.Short).Show();
                }
            };

            degree_polynomials.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                try
                {
                    degree_polynomials_input = int.Parse(e.Text.ToString());
                    polynomials.Int_degree_polynomials = degree_polynomials_input;
                }
                catch (FormatException)
                {
                    Toast.MakeText(ApplicationContext, "Podaj cyfrę!", ToastLength.Short).Show();
                }

                try { polynomials.Table_coefficient = new int[polynomials.Int_degree_polynomials + 1]; } catch (OverflowException) { }

                Text_value_degree_polynomials.Visibility = ViewStates.Visible;
                Text_coefficient_polynomials.Visibility = ViewStates.Visible;
                Text_value_degree_polynomials.Text = "Stopien wielomianu = " + polynomials.Int_degree_polynomials;
                Text_coefficient_polynomials.Text = "Podaj wspólczynnik stojacy przy potedze: " + polynomials.Int_degree_polynomials;
                coefficient.Enabled = true;

            };

            argument.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                try { polynomials.Int_argument = int.Parse(e.Text.ToString()); }
                catch (FormatException)
                {
                    Toast.MakeText(ApplicationContext, "Podaj cyfrę!", ToastLength.Short).Show();
                }

                Argument_value.Visibility = ViewStates.Visible;
                Sum.Visibility = ViewStates.Visible;
                Argument_value.Text = "x = " + polynomials.Int_argument;
                Sum.Text = "W(" + polynomials.Int_argument + ") = ";

            };

        }

    }

}

