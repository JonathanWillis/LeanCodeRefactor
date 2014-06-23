using LeanCodeRefactor.BusinessObjects;
using Moq;
using NUnit.Framework;

namespace LeanCodeRefactor.Tests.PerClass
{
    [TestFixture]
    public class CheckoutTests
    {
        [Test]
        public void Test()
        {
            var inputParser = new Mock<IInputParser>();
            var itemService = new Mock<IItemService>();
            var discountService = new Mock<IDiscountService>();

            inputParser.Setup(x=>x.Parse("SomeInput,SomeMoreInput")).Returns(new string[] { "SomeInput", "SomeMoreInput"});
            itemService.Setup(x => x.PriceFor("SomeInput")).Returns(100);
            itemService.Setup(x => x.PriceFor("SomeMoreInput")).Returns(150);
            discountService.Setup(x => x.PriceAdjustment("SomeInput")).Returns(0);
            discountService.Setup(x => x.PriceAdjustment("SomeMoreInput")).Returns(50);

            var subject = new Checkout(inputParser.Object, itemService.Object, discountService.Object);
            
            var result = subject.Scan("SomeInput,SomeMoreInput");
            Assert.That(result, Is.EqualTo("200"));

            inputParser.Verify(x => x.Parse("SomeInput,SomeMoreInput"), Times.Once());
            itemService.Verify(x => x.PriceFor("SomeInput"), Times.Once());
            itemService.Verify(x => x.PriceFor("SomeMoreInput"), Times.Once());
            discountService.Verify(x => x.PriceAdjustment("SomeInput"), Times.Once());
            discountService.Verify(x => x.PriceAdjustment("SomeMoreInput"), Times.Once());
        }
    }
}