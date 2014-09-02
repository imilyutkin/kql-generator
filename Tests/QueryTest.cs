using System;
using System.Collections.Generic;
using KQLGenerator;
using KQLGenerator.Enums;
using KQLGenerator.Exceptions;
using Xunit;

namespace Tests
{
    public class QueryTest
    {
        [Fact]
        public void QueryBuildWithOneTerm()
        {
            var query = new Query().AddTerm("title", "ivan", Operation.Equal).Build();
            Assert.Equal("title=ivan", query);
        }

        [Fact]
        public void QueryBuildWithOneCompositeTerm()
        {
            var compositeQuery =
                new Query().AddCompositeQuery("title", new List<String> {"ivan", "nadine"}, Operation.Equal,
                    ConcatOperator.Or).Build();
            Assert.Equal("title=ivan OR title=nadine", compositeQuery);
        }

        [Fact]
        public void QueryBuildWithTwoTerms()
        {
            var query = new Query().AddTerm("title", "ivan", Operation.Equal, ConcatOperator.Or)
                .AddTerm("title", "nadine", Operation.Equal).Build();
            Assert.Equal("title=ivan OR title=nadine", query);
        }

        [Fact]
        public void QueryBuildWithTwoTerms_WithoutConcat()
        {
            var query = new Query().AddTerm("title", "ivan", Operation.Equal, ConcatOperator.Or)
                .AddTerm("title", "john", Operation.Equal)
                .AddTerm("title", "nadine", Operation.Equal);
            Assert.Throws<ConcatTermsException>(() => query.Build());
        }

        [Fact]
        public void QueryBuildWithThreeTerms()
        {
            var query = new Query().AddTerm("title", "ivan", Operation.Equal, ConcatOperator.Or)
                .AddTerm("title", "john", Operation.Contains, ConcatOperator.And)
                .AddTerm("title", "nadine", Operation.Equal);
            var buildedQuery = String.Empty;
            Assert.DoesNotThrow(() => buildedQuery = query.Build());
            Assert.Equal("title=ivan OR title:john AND title=nadine", buildedQuery);
        }
    }
}
