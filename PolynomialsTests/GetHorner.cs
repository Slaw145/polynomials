using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PolynomialsTests
{
    class GetHorner
    {
        private int[] table_coefficient;

        public int[] Table_coefficient
        {
            get { return table_coefficient; }
            set { table_coefficient = value; }
        }

        private int int_degree_polynomials;

        public int Int_degree_polynomials
        {
            get { return int_degree_polynomials; }
            set { int_degree_polynomials = value; }
        }

        private int int_argument;

        public int Int_argument
        {
            get { return int_argument; }
            set { int_argument = value; }
        }

        private int horner(int[] wsp, int st, int x)
        {
            if (st == 0)
                return wsp[0];

            return x * horner(wsp, st - 1, x) + wsp[st];
        }

        public int getSum(int degree_polynomials_input)
        {
            int subtract_coefficient = degree_polynomials_input;
            int[] tablica = new int[degree_polynomials_input + 1];

            for (int i = 0; i <= degree_polynomials_input; i++)
            {
                tablica[i] = table_coefficient[subtract_coefficient--];
            }

            int sum = horner(tablica, degree_polynomials_input, int_argument);

            return sum;
        }
    }
}