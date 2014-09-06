using KQLGenerator;
using KQLGenerator.Enums;
using KQLGenerator.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSUnitTests
{
    [TestClass]
    public class TermTest
    {
        [TestMethod]
        public void SimpleTestContains()
        {
            Term term = new Term("title", "ivan", Operation.Contains);
            var t = term.Build();
            Assert.AreEqual(t, "title:ivan");
        }

        [TestMethod]
        public void SimpleTestNotContains()
        {
            Term term = new Term("title", "ivan", Operation.NotContains);
            var t = term.Build();
            Assert.AreEqual(t, "-title:ivan");
        }

        [TestMethod]
        public void SimpleTestNotEqual()
        {
            Term term = new Term("title", "ivan", Operation.NotEqual);
            var t = term.Build();
            Assert.AreEqual(t, "title<>ivan");
        }

        [TestMethod]
        public void SimpleTestEqual()
        {
            Term term = new Term("title", "ivan", Operation.Equal);
            var t = term.Build();
            Assert.AreEqual(t, "title=ivan");
        }

        [TestMethod]
        [ExpectedException(typeof(ManagedPropertyNullOrEmptyException))]
        public void ManagedPropertyIsNull()
        {
            Term term = new Term(null, "ivan", Operation.Contains);
            term.Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ValueNullOrEmptyException))]
        public void ValuePropertyIsNull()
        {
            Term term = new Term("title", null, Operation.Contains);
            term.Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ValueNullOrEmptyException))]
        public void ValuePropertyIsEmpty()
        {
            Term term = new Term("title", "", Operation.Contains);
            term.Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ManagedPropertyNullOrEmptyException))]
        public void ManagedPropertyPropertyIsEmpty()
        {
            Term term = new Term("", "ivan", Operation.Contains);
            term.Build();
        }

        [TestMethod]
        public void WithConcatOperatorAnd()
        {
            Term term = new Term("title", "ivan", Operation.Contains, ConcatOperator.And);
            var t = term.Build();
            Assert.AreEqual(t, "title:ivan AND");
        }
    }
}
