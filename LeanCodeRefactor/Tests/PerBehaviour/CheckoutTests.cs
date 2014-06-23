using LeanCodeRefactor.BusinessObjects;
using NUnit.Framework;

namespace LeanCodeRefactor.Tests.PerBehaviour
{
    //Items
    //Banana - £1.5
    //Apple - £1
    //Mele - £1
    //Pommes - £1
    //Cherries £0.75

    //One per line + CSV

    //2x Cherry = £0.20p off
    //Banana B1G1F
    //3x pommes gives £1 off
    //2x mele give £0.50 off
    //any 4x apples, £1 off
    //any 5 fruit, £2 off

    [TestFixture]
    public class GivenAnEmptyCheckout
    {
        private Checkout _checkout;

        [SetUp]
        public void Setup()
        {
            _checkout = new Checkout();
        }

        [TestCase("Bananas", "150")]
        [TestCase("Cherries", "75")]
        [TestCase("Apples", "100")]
        [TestCase("Mele", "100")]
        [TestCase("Pommes", "100")]
        public void WhenScanningASingleItemThenTheTotalPriceOfTheCheckoutIsThePriceOfTheItem(string input, string expectedTotal)
        {
            var totalPrice = _checkout.Scan(input);
            Assert.That(totalPrice, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void WhenScanningTwoItemsInSequenceThenTheTotalPriceOfTheCheckoutIsThePriceOfBothItems()
        {
            _checkout.Scan("Bananas");
            var totalPrice = _checkout.Scan("Cherries");
            Assert.That(totalPrice, Is.EqualTo("225"));
        }

        [Test]
        public void WhenScanningTwoItemsAtOnceSeperatedByACommaThenTheTotalPriceOfTheCheckoutIsThePriceOfBothItems()
        {
            var totalPrice = _checkout.Scan("Bananas,Cherries");
            Assert.That(totalPrice, Is.EqualTo("225"));
        }

        [TestCase("Bananas,Bananas", "150", Description = "Bananas Buy 1 Get 1 Free")]
        [TestCase("Cherries,Cherries", "130", Description = "Cherries Buy 2 Save 20 pence")]
        [TestCase("Pommes,Pommes,Pommes", "200", Description = "Pommes Buy 3 Save £1")]
        [TestCase("Mele,Mele", "150", Description = "Mele Buy 2 Save 50 pence")]
        [TestCase("Pommes,Pommes,Apples,Apples", "300", Description = "Apples Buy any 4 Save £1")]
        [TestCase("Bananas,Cherries,Pommes,Mele,Apples", "325", Description = "Fruit Buy any 5 Save £2")]
        public void WhenScanningMultipleItemsThatHaveMultibuyDiscountsThenTheTotalPriceOfTheCheckoutIsThePriceOfBothItems(string input, string expectedTotal)
        {
            var totalPrice = _checkout.Scan(input);
            Assert.That(totalPrice, Is.EqualTo(expectedTotal));
        }

        [Test(Description = "Customer Acceptence Test #1")]
        public void WhenScanningMelePommesPommesMeleFollowedByBananasThenTheTotalIs200FollowedBy250()
        {
            var totalPrice1 = _checkout.Scan("Mele,Pommes,Pommes,Mele");
            Assert.That(totalPrice1, Is.EqualTo("250"));
            var totalPrice2 = _checkout.Scan("Bananas");
            Assert.That(totalPrice2, Is.EqualTo("200"));
        }

        [Test(Description = "Customer Acceptence Test #2")]
        public void WhenScanningMelePommesPommesApplesMeleThenTheTotalIs150()
        {
            var totalPrice = _checkout.Scan("Mele,Pommes,Pommes,Apples,Mele");
            Assert.That(totalPrice, Is.EqualTo("150"));
        }
    }
}
