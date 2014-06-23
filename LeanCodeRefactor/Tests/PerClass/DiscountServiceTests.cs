using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeanCodeRefactor.BusinessObjects;
using NUnit.Framework;

namespace LeanCodeRefactor.Tests.PerClass
{
    [TestFixture]
    public class DiscountServiceTests
    {
        [Test]
        public void BananasBuy1Get1FreeSo150PenceDiscountIsReturned()
        {
            var subject = new DiscountService();
            subject.PriceAdjustment("Bananas");
            var result = subject.PriceAdjustment("Bananas");
            Assert.That(result, Is.EqualTo(150));
        }

        [Test]
        public void CherriesBuy2Save20PenceSo20PenceDiscountIsReturned()
        {
            var subject = new DiscountService();
            subject.PriceAdjustment("Cherries");
            var result = subject.PriceAdjustment("Cherries");
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void PommesBuy3Save1PoundSo100PenceDiscountIsReturned()
        {
            var subject = new DiscountService();
            subject.PriceAdjustment("Pommes");
            subject.PriceAdjustment("Pommes");
            var result = subject.PriceAdjustment("Pommes");
            Assert.That(result, Is.EqualTo(100));
        }

        [Test]
        public void PommesBuy2Save50PenceSo50PenceDiscountIsReturned()
        {
            var subject = new DiscountService();
            subject.PriceAdjustment("Mele");
            var result = subject.PriceAdjustment("Mele");
            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void ApplesBuyAny4Save1PoundSo100PenceDiscountIsReturned()
        {
            var subject = new DiscountService();
            subject.PriceAdjustment("Pommes");
            subject.PriceAdjustment("Pommes");
            subject.PriceAdjustment("Apples");
            var result = subject.PriceAdjustment("Apples");
            Assert.That(result, Is.EqualTo(100));
        }

        [Test]
        public void FruitBuyAny5Save2PoundSo200PenceDiscountIsReturned()
        {
            var subject = new DiscountService();
            subject.PriceAdjustment("Bananas");
            subject.PriceAdjustment("Cherries");
            subject.PriceAdjustment("Pommes");
            subject.PriceAdjustment("Mele");
            var result = subject.PriceAdjustment("Apples");
            Assert.That(result, Is.EqualTo(200));
        }
    }
}
