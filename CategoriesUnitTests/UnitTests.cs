using System;
using System.Linq;
using Xunit;

using CategoriesApp;
using CategoriesApp.Extentions;
using CategoriesApp.Model;
using CategoriesApp.Repository;

namespace CategoriesUnitTests
{
    public class UnitTests
    {
        [Fact]
        public void ShouldGetCategoriesEnumeration()
        {
            var categories = HierarchicalDatasetProvider.Seed();
            Assert.True(categories.Flatten(category => null).Any());
        }


        [Fact]
        public void ShouldGetCategoriesEnumerationFlatten()
        {
            var categories = HierarchicalDatasetProvider.Seed();
            Assert.True(
                categories.Flatten(
                    category => category.Child )
                  .Any());
        }

        [Fact]
        public void ShoulReturnTopLevelCategories()
        {
            var repository = new CategoriesRepository(HierarchicalDatasetProvider.Seed());
            Assert.True(repository.CategoryNthLevel(1).Any());
        }

        [Fact]
        public void ShoulReturnProperCategoriesForLevels()
        {
            //proper level of categories nesting
            var repository = new CategoriesRepository(HierarchicalDatasetProvider.Seed());
            Assert.True(
                repository.CategoryNthLevel(1)
                            .Select(x => x.Level)
                            .Distinct()
                            .First() == 1);
        }
    }
}
