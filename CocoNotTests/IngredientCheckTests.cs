using System;
using System.Collections.Generic;
using Xunit;

namespace IngredientCheck.Tests
{
    public class IngredientCheckTests
    {
        private IngredientChecker checker;

        public IngredientCheckTests()
        {
            checker = new IngredientChecker();
        }

        [Fact]
        public void BasicSearch()
        {
            List<string> results = checker.Check("Coconut");
            Assert.Single(results);
            Assert.Contains("Coconut", results);
        }

        [Fact]
        public void LowercaseSearch()
        {
            List<string> results = checker.Check("coconut milk");
            Assert.Single(results);
            Assert.Contains("coconut milk", results);
        }

        [Fact]
        public void MultilineSearch()
        {
            List<string> results = checker.Check("Coconut\n\tOil");
            Assert.Single(results);
            Assert.Contains("Coconut\n\tOil", results);
        }

        [Fact]
        public void MultipleResults()
        {
            List<string> results = checker.Check("THIS IS A lauric acid TEST THAT HAS PEG-100 Stearate MULTIPLE\n\nRESULTS sucrose\ncocoate");
            Assert.Equal(3, results.Count);
            Assert.Contains("lauric acid", results);
            Assert.Contains("PEG-100 Stearate", results);
            Assert.Contains("sucrose\ncocoate", results);
        }
    }
}
