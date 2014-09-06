using System;
using System.Collections.Generic;
using KQLGenerator;
using KQLGenerator.Enums;
using KQLGenerator.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSUnitTests
{
    [TestClass]
    public class QueryTest
    {
        [TestMethod]
        public void QueryBuildWithOneTerm()
        {
            var query = new KQLQuery().AddTerm("title", "ivan", Operation.Equal).Build();
            Assert.AreEqual("title=ivan", query);
        }

        [TestMethod]
        public void QueryBuildWithOneCompositeTerm()
        {
            var compositeQuery =
                new KQLQuery().AddCompositeQuery("title", new List<String> {"ivan", "nadine"}, Operation.Equal,
                    ConcatOperator.Or).Build();
            Assert.AreEqual("title=ivan OR title=nadine", compositeQuery);
        }

        [TestMethod]
        public void QueryBuildWithTwoTerms()
        {
            var query = new KQLQuery().AddTerm("title", "ivan", Operation.Equal, ConcatOperator.Or)
                .AddTerm("title", "nadine", Operation.Equal).Build();
            Assert.AreEqual("title=ivan OR title=nadine", query);
        }

        [TestMethod]
        [ExpectedException(typeof(ConcatTermsException))]
        public void QueryBuildWithTwoTerms_WithoutConcat()
        {
            var query = new KQLQuery().AddTerm("title", "ivan", Operation.Equal, ConcatOperator.Or)
                .AddTerm("title", "john", Operation.Equal)
                .AddTerm("title", "nadine", Operation.Equal);
            query.Build();
        }

        [TestMethod]
        public void QueryBuildWithThreeTerms()
        {
            var query = new KQLQuery().AddTerm("title", "ivan", Operation.Equal, ConcatOperator.Or)
                .AddTerm("title", "john", Operation.Contains, ConcatOperator.And)
                .AddTerm("title", "nadine", Operation.Equal);
            var buildedQuery = String.Empty;
            Assert.AreEqual("title=ivan OR title:john AND title=nadine", buildedQuery);
        }
    }
}
