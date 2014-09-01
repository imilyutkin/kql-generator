using System;
using System.Collections.Generic;
using KQLGenerator;
using KQLGenerator.Enums;
using Xunit;

namespace Tests
{
    public class TermTest
    {
        [Fact]
        public void SimpleTestContains()
        {
            Term term = new Term("title", "ivan", Operation.Contains);
            var t = term.Build();
            Assert.Equal(t, "title:ivan");
        }

        [Fact]
        public void SimpleTestNotContains()
        {
            Term term = new Term("title", "ivan", Operation.NotContains);
            var t = term.Build();
            Assert.Equal(t, "-title:ivan");
        }

        [Fact]
        public void SimpleTestNotEqual()
        {
            Term term = new Term("title", "ivan", Operation.NotEqual);
            var t = term.Build();
            Assert.Equal(t, "title<>ivan");
        }

        [Fact]
        public void SimpleTestEqual()
        {
            Term term = new Term("title", "ivan", Operation.Equal);
            var t = term.Build();
            Assert.Equal(t, "title=ivan");
        }

        [Fact]
        public void ManagedPropertyIsNull()
        {
            Term term = new Term(null, "ivan", Operation.Contains);
            Assert.Throws<ArgumentException>(() => term.Build());
        }

        [Fact]
        public void ValuePropertyIsNull()
        {
            Term term = new Term("title", null, Operation.Contains);
            Assert.Throws<ArgumentException>(() => term.Build());
        }

        [Fact]
        public void ValuePropertyIsEmpty()
        {
            Term term = new Term("title", "", Operation.Contains);
            Assert.Throws<ArgumentException>(() => term.Build());
        }

        [Fact]
        public void ManagedPropertyPropertyIsEmpty()
        {
            Term term = new Term("", "ivan", Operation.Contains);
            Assert.Throws<ArgumentException>(() => term.Build());
        }

        [Fact]
        public void WithConcatOperatorAnd()
        {
            Term term = new Term("title", "ivan", Operation.Contains, ConcatOperator.And);
            var t = term.Build();
            Assert.Equal(t, "title:ivan AND ");
        }
    }
}
