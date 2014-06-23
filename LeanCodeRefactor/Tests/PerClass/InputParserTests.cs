using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeanCodeRefactor.BusinessObjects;
using NUnit.Framework;

namespace LeanCodeRefactor.Tests.PerClass
{
    [TestFixture]
    public class InputParserWithOneItem
    {
        private string[] _result;

        [SetUp]
        public void Setup()
        {
            var subject = new InputParser();
            _result = subject.Parse("something");
        }

        [Test]
        public void OneItemIsReturned()
        {
            Assert.That(_result.Length, Is.EqualTo(1));
        }

        [Test]
        public void ItemReturnedIsItemInputted()
        {
            Assert.That(_result[0], Is.EqualTo("something"));
        }
    }

    [TestFixture]
    public class InputParserWithMultipleItems
    {
        private string[] _result;

        [SetUp]
        public void Setup()
        {
            var subject = new InputParser();
            _result = subject.Parse("something,else,here");
        }

        [Test]
        public void AllItemsAreReturned()
        {
            Assert.That(_result.Length, Is.EqualTo(3));
        }

        [Test]
        public void ItemsReturned()
        {
            Assert.That(_result[0], Is.EqualTo("something"));
            Assert.That(_result[1], Is.EqualTo("else"));
            Assert.That(_result[2], Is.EqualTo("here"));
        }
    }
}
