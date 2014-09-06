using System;
using System.Collections.Generic;
using KQLGenerator;
using KQLGenerator.Enums;
using KQLGenerator.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSUnitTests
{
    [TestClass]
    public class CompositeTermTest
    {
        /// <summary>
        /// Generates the query for composite term_ without ending.
        /// </summary>
        [TestMethod]
        public void GenerateQueryForCompositeTerm_WithoutEnding()
        {
            var term = new CompositeTerm("title", new List<String> {"ivan", "nadine", "ksenya", "sergei"},
                Operation.Equal, ConcatOperator.Or);
            var t = term.Build();
            var query = "title=ivan OR title=nadine OR title=ksenya OR title=sergei";
            Assert.AreEqual(t, query);
        }

        /// <summary>
        /// Generates the query for composite term_ without ending.
        /// </summary>
        [TestMethod]
        public void GenerateQueryForCompositeTerm_WithEnding()
        {
            var term = new CompositeTerm("title", new List<String> {"ivan", "nadine", "ksenya", "sergei"},
                Operation.Equal, ConcatOperator.Or, ConcatOperator.And);
            var t = term.Build();
            var query = "title=ivan OR title=nadine OR title=ksenya OR title=sergei AND";
            Assert.AreEqual(t, query);
        }

        /// <summary>
        /// Generates the query for composite term_ without ending.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValueNullOrEmptyException))]
        public void GenerateQueryForCompositeTerm_WithNullValues()
        {
            var term = new CompositeTerm("title", null,
                Operation.Equal, ConcatOperator.Or, ConcatOperator.And);
            term.Build();
        }

        /// <summary>
        /// Generates the query for composite term_ without ending.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ManagedPropertyNullOrEmptyException))]
        public void GenerateQueryForCompositeTerm_WithNullManagedProperty()
        {
            var term = new CompositeTerm(null, new List<String> { "ivan", "nadine", "ksenya", "sergei" },
                Operation.Equal, ConcatOperator.Or, ConcatOperator.And);
            term.Build();
        }
    }
}
