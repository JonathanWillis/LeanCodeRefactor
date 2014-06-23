using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeanCodeRefactor.BusinessObjects;
using NUnit.Framework;

namespace LeanCodeRefactor.Tests.PerClass
{
    [TestFixture]
    public class ItemServiceTests
    {
        [TestCase("Bananas", 150)]
        [TestCase("Cherries", 75)]
        [TestCase("Melon", 200)]
        [TestCase("Apples", 100)]
        [TestCase("Mele", 100)]
        [TestCase("Pommes", 100)]
        public void EachIndividualItemIsPricedCorrectly(string item, int price)
        {
            var subject = new ItemService();
            var result = subject.PriceFor(item);
            Assert.That(result, Is.EqualTo(price));
        }

        [Test]
        public void UnknownItemsReturnAPriceOfZero()
        {
            var subject = new ItemService();
            var result = subject.PriceFor("something");
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
