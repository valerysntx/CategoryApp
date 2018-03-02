using System.Collections.Generic;
using CategoriesApp.Model;

namespace CategoriesApp.Repository
{
    /// <inheritdoc />
    public abstract class AbstractCategoriesRepository<TCategory> : ICategoriesRepository<TCategory> 
                          where TCategory: ICategoryBase
    {
        public abstract TCategory GetById(int id);
        public abstract ICollection<TCategory> CategoryNthLevel(int nth);
    }
}