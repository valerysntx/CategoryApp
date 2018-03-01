using System;
using System.Collections.Generic;
using System.Linq;
using CategoriesApp.Extentions;
using CategoriesApp.Model;

namespace CategoriesApp
{
    /// <summary>
    /// Implementation of A and B tasks
    /// </summary>
    public class CategoriesRepository: AbstractCategoriesRepository
    {
        /// <summary>
        /// Categories with level
        /// </summary>
        private readonly ICollection<Tuple<Category,int>> _categories = null;

        public CategoriesRepository(IEnumerable<Category> categories)
        {
           _categories = categories.FlattenWithLevel(x=> x.Child).ToArray();
        }

        /// <summary>
        /// A: 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Category GetById(int id)
        {
            return _categories.FirstOrDefault(x => x.Item1?.Id == id)?.Item1;
        }

        /// <summary>
        /// B:
        /// </summary>
        /// <param name="nth"></param>
        /// <returns></returns>
        public override ICollection<Category> CategoryNthLevel(int nth)
        {
            return _categories.Where(x => x.Item2 == nth).Select(x=> x.Item1).ToArray();
        }
    }
}