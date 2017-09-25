using System;
using NUnit.Framework;


namespace PolynomialsTests
{
    [TestFixture]
    public class TestsSample
    {

        [SetUp]
        public void Setup() { }

        [Test]
        public void checkThatSumIsValid()
        {
            GetHorner horner = new GetHorner();

            horner.Int_degree_polynomials = 2;
            int deggrePolynomialsInput = horner.Int_degree_polynomials;

            horner.Int_argument = 2;
            horner.Table_coefficient = new int[horner.Int_degree_polynomials + 1];
            horner.Table_coefficient[horner.Int_degree_polynomials--] = 1;
            horner.Table_coefficient[horner.Int_degree_polynomials--] = 1;
            horner.Table_coefficient[horner.Int_degree_polynomials--] = 1;

            int sumka = horner.getSum(deggrePolynomialsInput);

            Assert.AreEqual(7, sumka);
        }

 
    }
}