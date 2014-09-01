using System;
using System.Collections.Generic;
using KQLGenerator;
using KQLGenerator.Enums;
using Xunit;

namespace Tests
{
    public class CompositeTermTest
    {
        /// <summary>
        /// Generates the query for composite term_ without ending.
        /// </summary>
        [Fact]
        public void GenerateQueryForCompositeTerm_WithoutEnding()
        {
            var term = new CompositeTerm("title", new List<String> {"ivan", "nadine", "ksenya", "sergei"},
                Operation.Equal, ConcatOperator.Or);
            var t = term.Build();
            var query = "title=ivan OR title=nadine OR title=ksenya OR title=sergei";
            Assert.Equal(t, query);
        }

        /// <summary>
        /// Generates the query for composite term_ without ending.
        /// </summary>
        [Fact]
        public void GenerateQueryForCompositeTerm_WithEnding()
        {
            var term = new CompositeTerm("title", new List<String> {"ivan", "nadine", "ksenya", "sergei"},
                Operation.Equal, ConcatOperator.Or, ConcatOperator.And);
            var t = term.Build();
            var query = "title=ivan OR title=nadine OR title=ksenya OR title=sergei AND ";
            Assert.Equal(t, query);
        }

        /// <summary>
        /// Generates the query for composite term_ without ending.
        /// </summary>
        [Fact]
        public void GenerateQueryForCompositeTerm_WithNullValues()
        {
            var term = new CompositeTerm("title", null,
                Operation.Equal, ConcatOperator.Or, ConcatOperator.And);
            Assert.Throws<ArgumentException>(() => term.Build());
        }

        /// <summary>
        /// Generates the query for composite term_ without ending.
        /// </summary>
        [Fact]
        public void GenerateQueryForCompositeTerm_WithNullManagedProperty()
        {
            var term = new CompositeTerm(null, new List<String> { "ivan", "nadine", "ksenya", "sergei" },
                Operation.Equal, ConcatOperator.Or, ConcatOperator.And);
            Assert.Throws<ArgumentException>(() => term.Build());
        }
    }
}
